using System.Diagnostics;

namespace DesktopAppSearchFiles
{
    public partial class SearchFilesForm : Form
    {
        public string StartDirectory
        {
            get => startDirectoryTextBox.Text;
            set => startDirectoryTextBox.Text = value;
        }

        public string SearchFilesPattern
        {
            get => searchFilesTextBox.Text;
            set => searchFilesTextBox.Text = value;
        }

        private string CountFiles
        {
            get => labelCountFiles.Text;
            set => labelCountFiles.Text = value;
        }

        private string CountFilesFound
        {
            get => labelCountFilesFound.Text;
            set => labelCountFilesFound.Text = value;
        }

        private bool _stopSearching = true;
        private Stopwatch _stopwatch = new Stopwatch();                     // секундомер

        public SearchFilesForm()
        {
            InitializeComponent();

            LoadSearchParameters();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(StartDirectory))
            {
                MessageBox.Show("Перед началом поиска установите значение стартовой директории");
                return;
            }    

            if(!Directory.Exists(StartDirectory))
            {
                MessageBox.Show("Установите корректное значение стартовой директории");
                return;
            }
            
            _stopSearching = false;

            StartTimer();

            //todo Выделить в отдельный поток и добавить учет cancelToken
            SetEventFileSystemWatcher();

            SetDirectoryTreeView();

            FillAdditionalInfo();
        }

        private FileSystemWatcher _watcher;

        private void SetDirectoryTreeView()
        {
            filesTreeView.Nodes.Clear();

            var treeNode = new TreeNode { Text = Path.GetFileName(StartDirectory) };

            DirectoryHelper.Fill(treeNode, StartDirectory, SearchFilesPattern, out var countFiles, out var countFilesFound);

            CountFiles = countFiles.ToString();
            CountFilesFound = countFilesFound.ToString();

            filesTreeView.Nodes.Add(treeNode);
        }

        private void stopSearchButton_Click(object sender, EventArgs e)
        {
            _stopSearching = true;
            _watcher.Dispose();
        }

        private void SearchFilesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSearchParameters();
        }

        private void SaveSearchParameters()
        {
            using (BinaryWriter file = new BinaryWriter(File.Create(Constants.LastSearchParametersFileName)))
            {
                file.Write(StartDirectory);
                file.Write(SearchFilesPattern);
            }
        }

        private void LoadSearchParameters()
        {
            try
            {
                using (BinaryReader file = new BinaryReader(File.OpenRead(Constants.LastSearchParametersFileName)))
                {
                    StartDirectory = file.ReadString();
                    SearchFilesPattern = file.ReadString();
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void FillAdditionalInfo()
        {
            labelNameSearchDirectory.Text = StartDirectory;
        }

        private void StartTimer()
        {
            _stopwatch.Reset();
            _stopwatch.Start();
            timerAfterStartSearch.Start();
        }

        private void timerAfterStartSearch_Tick(object sender, EventArgs e)
        {
            if(_stopSearching)
            {
                _stopwatch.Stop();
                timerAfterStartSearch.Stop();
                return;
            }

            labelTimeAfterStartSearch.Text = _stopwatch.Elapsed.ToString("mm\\:ss");
        }

        private void buttonSelectFileInPC_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    StartDirectory = folderBrowserDialog.SelectedPath;
            }
        }
    }
}