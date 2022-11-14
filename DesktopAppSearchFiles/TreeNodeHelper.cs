using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopAppSearchFiles
{
    public class TreeNodeHelper
    {

        public static TreeNode GetNode(TreeNodeCollection nodes, string searchName)
        {
            //todo У TreeNode есть свойство содержащее путь к файлу, нужно сделать так, чтобы поиск осуществлялся по этому пути
            //сейчас поиск происходит по имени файла
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
