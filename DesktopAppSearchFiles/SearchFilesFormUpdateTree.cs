using System.Text.RegularExpressions;

namespace DesktopAppSearchFiles
{
    public partial class SearchFilesForm
    {
        private void SetEventFileSystemWatcher()
        {
            _watcher = new FileSystemWatcher(StartDirectory);

            _watcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;

            _watcher.Deleted += OnDeleted;
            _watcher.Created += OnCreated;
            _watcher.Renamed += OnRenamed;

            _watcher.IncludeSubdirectories = true;
            _watcher.EnableRaisingEvents = true;
        }

        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Deleted)
                return;

            var pathChange = GetPathInTree(e.FullPath);

            ChangeTreeView(DeleteNode, pathChange, null);
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Created)
                return;

            var newNode = Path.GetFileName(e.FullPath);

            if (CheckChangeObject(e.FullPath, newNode))
                return;

            var pathChange = GetPathInTree(Path.GetDirectoryName(e.FullPath));

            ChangeTreeView(CreateNode, pathChange, newNode);
        }

        private void OnRenamed(object source, RenamedEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Renamed)
                return;

            var newName = Path.GetFileName(e.FullPath);

            if (CheckChangeObject(e.FullPath, newName))
                    return;

            var pathChange = GetPathInTree(e.OldFullPath);

            ChangeTreeView(RenameNode, pathChange, newName);
        }

        private void RenameNode(TreeNode changeNode, string newName)
            => changeNode.Text = newName;

        private void CreateNode(TreeNode changeNode, string newName)
            => changeNode.Nodes.Add(newName);

        private void DeleteNode(TreeNode changeNode, string _)
            => changeNode.Nodes.Remove(changeNode);

        private void ChangeTreeView(Action<TreeNode, string> changeAction, string pathChange, string newNode)
        {
            if (filesTreeView.InvokeRequired)
                filesTreeView.Invoke(new Action(() => Change()));
            else
                Change();

            void Change()
            {
                try
                {
                    var changeNode = TreeNodeHelper.GetNode(filesTreeView.Nodes, pathChange);
                    filesTreeView.BeginUpdate();
                    changeAction.Invoke(changeNode, newNode);
                    filesTreeView.EndUpdate();
                }
                catch (NodeNotFound ex)
                {
                    var result = MessageBox.Show("Не удалось обновить дерево файлов. Обновить повторно?", "Error", MessageBoxButtons.OKCancel);
                    
                    if(result == DialogResult.OK)
                        SetDirectoryTreeView(); // В случае ошибки по решению пользователя происходит глобальное обновление дерева.
                }
            }
        }

        private bool CheckChangeObject(string path, string node)
            => File.Exists(path) && !Regex.IsMatch(node, SearchFilesPattern);

        private string GetPathInTree(string path) 
        {
            var nameStart = Path.GetFileName(StartDirectory);

            return path.Substring(path.IndexOf(nameStart));
        }
    }
}
