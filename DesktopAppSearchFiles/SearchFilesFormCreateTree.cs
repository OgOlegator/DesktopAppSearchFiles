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
        private CancellationTokenSource _cancel;

        private void ResetTree()
        {
            filesTreeView.Nodes.Clear();

            _cancel = new CancellationTokenSource();
            var token = _cancel.Token;
            
            var task = new Task(() => SetDirectoryTreeView(), token);
            task.Start();

            void SetDirectoryTreeView()
            {
                try
                {
                    var directoryTree = new DirectoryTreeNode(StartDirectory, SearchFilesPattern).AddCancel(token);
                    var tree = directoryTree.Get();

                    if (token.IsCancellationRequested)
                        return;

                    filesTreeView.Invoke(new Action(() => filesTreeView.Nodes.Add(tree)));

                    CountFiles = directoryTree.GetCountFiles().ToString();
                    CountFilesFound = directoryTree.GetCountFoundFiles().ToString();
                }
                finally
                {
                    _cancel?.Dispose();
                    SetEventFileSystemWatcher();    //Начало отслеживания обновлений указанной директории
                }
            }
        }

        private class DirectoryTreeNode
        {
            private readonly string _directorySearch;
            private readonly string _searchPattern;
            private CancellationToken _token;
            private int _countFiles = 0;
            private int _countFoundFiles = 0;

            public DirectoryTreeNode(string directorySearch, string searchPattern = null)
            {
                _directorySearch = directorySearch;
                _searchPattern = searchPattern;
            }

            public DirectoryTreeNode AddCancel(CancellationToken token)
            {
                _token = token;
                return this;
            }

            public TreeNode Get()
            {
                var treeNode = new TreeNode { Text = Path.GetFileName(_directorySearch) };

                GetChildNode(treeNode, _directorySearch);

                return treeNode;
            }

            public int GetCountFiles()
                => _countFiles;

            public int GetCountFoundFiles()
                => _countFoundFiles;

            private void GetChildNode(TreeNode directoryNode, string directory)
            {
                string[] fileEntries;

                try
                {
                    fileEntries = Directory.GetFiles(directory);
                }
                catch (UnauthorizedAccessException ex)
                {
                    return;
                }

                _countFiles += fileEntries.Count();

                foreach (var fileName in fileEntries
                    .Where(name => Regex.IsMatch(name, _searchPattern))
                    .Select(name => Path.GetFileName(name)))
                {
                    directoryNode.Nodes.Add(fileName);
                    _countFoundFiles++;
                }

                var subdirectories = Directory.GetDirectories(directory);

                // Рекурсивный поиск файлов в sub-директории 
                if (subdirectories.Count() == 0)
                    return;

                foreach (var subdirectory in subdirectories)
                {
                    if (_token.IsCancellationRequested)
                        return;

                    var subDirNode = new TreeNode { Text = Path.GetFileName(subdirectory) };

                    GetChildNode(subDirNode, subdirectory);

                    directoryNode.Nodes.Add(subDirNode);
                }
            }
        }
    }
}
