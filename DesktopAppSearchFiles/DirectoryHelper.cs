using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DesktopAppSearchFiles
{
    public class DirectoryHelper
    {
        public static void Fill(TreeNode directoryNode, string directory, string searchPattern, 
            out int countFiles, out int countFoundFiles)
        {
            var fileEntries = Directory.GetFiles(directory);

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
                var subDirNode = new TreeNode { Text = Path.GetFileName(subdirectory) };

                Fill(subDirNode, subdirectory, searchPattern, out var countSubFiles, out var countSubFoundFiles);

                countFiles += countSubFiles;
                countFoundFiles += countSubFoundFiles;

                directoryNode.Nodes.Add(subDirNode);
            }
        }
    }
}