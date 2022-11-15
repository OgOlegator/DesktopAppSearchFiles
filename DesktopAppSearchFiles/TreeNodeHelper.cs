using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopAppSearchFiles
{
    public class TreeNodeHelper
    {

        public static TreeNode GetNode(TreeNodeCollection nodes, string searchPath)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.FullPath == searchPath)
                {
                    return node;
                }
                else
                {
                    if (node.Nodes.Count == 0)
                        continue;

                    try
                    {
                        var changeNode = GetNode(node.Nodes, searchPath);
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
