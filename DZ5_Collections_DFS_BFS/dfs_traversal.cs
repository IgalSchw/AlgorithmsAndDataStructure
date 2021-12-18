using System;
using System.Collections.Generic;
using System.Text;

namespace DZ5_Collections_DFS_BFS
{
    partial class Program
    {
        static void dfs_traversal(Node node)
        {
            if (node == null)
                return;
            Console.Write(node.data + " ");
            dfs_traversal(node.left);
            dfs_traversal(node.Right);
        }
    }
}
