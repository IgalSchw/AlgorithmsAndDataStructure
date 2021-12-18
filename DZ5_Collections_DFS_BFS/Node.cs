using System;
using System.Collections.Generic;
using System.Text;

namespace DZ5_Collections_DFS_BFS
{
    public class Node
    {
        public Node left;
        public Node Right;
        public String data;

        public Node(String data, Node left, Node right)
        {
            this.data = data;
            this.left = left;
            Right = right;
        }

        public Node(String data)
        {
            this.data = data;
            this.left = null;
            this.Right = null;        
        }

    }
}
