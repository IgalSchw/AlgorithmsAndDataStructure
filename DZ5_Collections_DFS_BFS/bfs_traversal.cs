using System;
using System.Collections.Generic;
using System.Text;

namespace DZ5_Collections_DFS_BFS
{
    partial class Program
    { 
        static void bfs_traversal(Node node)
        {
            // תור
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(node);

            while (q.Count > 0)
            {
                node = q.Dequeue();
                Console.Write(node.data + " ");

                if (node.left != null)
                    q.Enqueue(node.left);

                if (node.Right != null)
                    q.Enqueue(node.Right);
            }        
        }
    }
}
