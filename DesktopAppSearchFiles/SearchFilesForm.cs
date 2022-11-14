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

        private int CountFiles = 0;
        private int CountFilesFound = 0;

        private bool _stopSearching = true;
        private Stopwatch _stopwatch = new Stopwatch();                     // секундомер

        public SearchFilesForm()
        {
            InitializeComponent();

            LoadSearchParameters();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            _stopSearching = false;

            StartTimer();

            SetEventFileSystemWatcher();

            SetDirectoryTreeView();

            FillAdditionalInfo();
        }

        private FileSystemWatcher _watcher;

        private void SetDirectoryTreeView()
        {
            filesTreeView.Nodes.Clear();

            var treeNode = new TreeNode { Text = Path.GetFileName(StartDirectory) };

            DirectoryTreeHelper.Fill(treeNode, StartDirectory, SearchFilesPattern);

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
            labelCountFiles.Text = "";
            labelCountFilesFound.Text = filesTreeView.Nodes.Count.ToString();
        }

        private void StartTimer()
        {
            _stopwatch.Reset();
            _stopwatch.Start();
            timerAfterSearch.Start();
        }

        private void timerAfterSearch_Tick(object sender, EventArgs e)
        {
            if(_stopSearching)
            {
                _stopwatch.Stop();
                timerAfterSearch.Stop();
                return;
            }

            labelTimeAfterSearch.Text = _stopwatch.Elapsed.ToString("mm\\:ss");
        }
    }
}