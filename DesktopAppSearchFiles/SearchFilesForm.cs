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
            set
            {
                if (labelCountFiles.InvokeRequired)
                    labelCountFiles.Invoke(new Action(() => labelCountFiles.Text = value));
                else
                    labelCountFiles.Text = value;
            }
        }

        private string CountFilesFound
        {
            get => labelCountFilesFound.Text;
            set 
            {
                if (labelCountFilesFound.InvokeRequired)
                    labelCountFiles.Invoke(new Action(() => labelCountFilesFound.Text = value));
                else
                    labelCountFilesFound.Text = value;
            }
        }

        private FileSystemWatcher _watcher;

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
                MessageBox.Show("ѕеред началом поиска установите значение стартовой директории");
                return;
            }    

            if(!Directory.Exists(StartDirectory))
            {
                MessageBox.Show("”становите корректное значение стартовой директории");
                return;
            }
            
            _stopSearching = false;

            StartTimer();

            ResetTree();

            FillAdditionalInfo();
        }

        private void stopSearchButton_Click(object sender, EventArgs e)
        {
            _stopSearching = true;
            _watcher?.Dispose();
            
            try
            {
                _cancel?.Cancel();
            }
            catch (ObjectDisposedException ex)
            {
                //OK
            }
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