using System.Text;

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

            ChangeTreeView(DeleteNode, e.Name, null);
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Created)
                return;

            var parent = Path.GetFileName(Path.GetDirectoryName(e.FullPath));
            var newNode = Path.GetFileName(e.FullPath);

            ChangeTreeView(CreateNode, parent, newNode);
        }

        private void OnRenamed(object source, RenamedEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Renamed)
                return;

            ChangeTreeView(RenameNode, e.OldName, e.Name);
        }

        private void RenameNode(TreeNode changeNode, string newName)
            => changeNode.Text = newName;

        private void CreateNode(TreeNode changeNode, string newName)
            => changeNode.Nodes.Add(newName);

        private void DeleteNode(TreeNode changeNode, string _)
            => changeNode.Nodes.Remove(changeNode);

        private void ChangeTreeView(Action<TreeNode, string> changeAction, string searchNode, string newNode)
        {
            if (filesTreeView.InvokeRequired)
                filesTreeView.Invoke(new Action(() => Change()));
            else
                Change();

            void Change()
            {
                var changeNode = DirectoryTreeHelper.GetNode(filesTreeView.Nodes, searchNode);

                filesTreeView.BeginUpdate();
                changeAction.Invoke(changeNode, newNode);
                filesTreeView.EndUpdate();
            }
        }
    }
}
