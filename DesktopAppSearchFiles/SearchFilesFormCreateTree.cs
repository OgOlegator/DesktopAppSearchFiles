using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DesktopAppSearchFiles
{
    public partial class SearchFilesForm
    {

        private void ResetTree()
        {
            filesTreeView.Nodes.Clear();

            //todo Выделить в отдельный поток и добавить учет cancelToken
            var cancelTokenSource = new CancellationTokenSource();
            var token = cancelTokenSource.Token;

            var task = new Task(() => SetDirectoryTreeView(), token);
            task.Start();

            void SetDirectoryTreeView()
            {
                var treeNode = new TreeNode { Text = Path.GetFileName(StartDirectory) };

                Fill(treeNode, token, StartDirectory, SearchFilesPattern, out var countFiles, out var countFilesFound);

                if (token.IsCancellationRequested)
                    return;

                filesTreeView.Invoke(new Action(() => filesTreeView.Nodes.Add(treeNode)));
                labelCountFiles.Invoke(new Action(() => CountFiles = countFiles.ToString()));
                labelCountFilesFound.Invoke(new Action(() => CountFilesFound = countFilesFound.ToString()));

                SetEventFileSystemWatcher();    //Начало отслеживания обновлений указанной директории
            }
        }

        private void Fill(TreeNode directoryNode, CancellationToken token, string directory, string searchPattern,
                            out int countFiles, out int countFoundFiles)
        {
            countFoundFiles = 0;
            countFiles = 0;
            string[] fileEntries;

            try
            {
                fileEntries = Directory.GetFiles(directory);
            }
            catch (UnauthorizedAccessException ex)
            {
                return;
            }

            countFoundFiles = 0;
            countFiles = fileEntries.Count();

            foreach (var fileName in fileEntries
                .Where(name => Regex.IsMatch(name, searchPattern))
                .Select(name => Path.GetFileName(name)))
            {
                directoryNode.Nodes.Add(fileName);
                countFoundFiles++;
            }

            var subdirectories = Directory.GetDirectories(directory);

            // Рекурсивный поиск файлов в sub-директории 
            if (subdirectories.Count() == 0)
                return;

            foreach (var subdirectory in subdirectories)
            {
                if (token.IsCancellationRequested)
                    return;

                var subDirNode = new TreeNode { Text = Path.GetFileName(subdirectory) };

                Fill(subDirNode, token, subdirectory, searchPattern, out var countSubFiles, out var countSubFoundFiles);

                countFiles += countSubFiles;
                countFoundFiles += countSubFoundFiles;

                directoryNode.Nodes.Add(subDirNode);
            }
        }
    }
}
