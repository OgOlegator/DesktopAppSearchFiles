using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DesktopAppSearchFiles
{
    public class DirectoryTreeHelper
    {
        public static void Fill(TreeNode directoryNode, string directory, string searchPattern = null)
        {
            var fileEntries = Directory.GetFiles(directory, searchPattern);

            foreach (var fileName in fileEntries.Select(name => Path.GetFileName(name)))
                directoryNode.Nodes.Add(fileName);//, Path.GetFileName(fileName));

            var subdirectories = Directory.GetDirectories(directory);

            // Рекурсивный поиск файлов в sub-директории 
            if (subdirectories.Count() == 0)
                return;

            foreach (var subdirectory in subdirectories)
            {
                var subDirNode = new TreeNode { Text = Path.GetFileName(subdirectory) };

                Fill(subDirNode, subdirectory, searchPattern);

                directoryNode.Nodes.Add(subDirNode);
            }
        }

        public static TreeNode GetNode(TreeNodeCollection nodes, string searchName)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Text == searchName)
                {
                    return node;
                }
                else
                {
                    if (node.Nodes.Count == 0)
                        continue;

                    try
                    {
                        var changeNode = GetNode(node.Nodes, searchName);
                        return changeNode;
                    }
                    catch (NodeNotFound ex)
                    {
                        continue;
                    }
                }
            }

            throw new NodeNotFound();
        }
    }
}