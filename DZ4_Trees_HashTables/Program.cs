using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DZ4_Trees_HashTables
{
        /// <summary>
        /// Расположения узла относительно родителя
        /// </summary>
    public enum Side // left or right
    {
        Left,
        Right
    }

    /// <summary>
    /// Узел бинарного дерева
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryTreeNode<T> where T : IComparable
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="data">Данные</param>
        public BinaryTreeNode(T data)
        {
            Data = data;
        }

        /// <summary>
        /// Данные которые хранятся в узле
        /// </summary>
        public T Data { get; set; }                       // Data

        /// <summary>
        /// Левая ветка
        /// </summary>
        public BinaryTreeNode<T> LeftNode { get; set; }   // Left Node

        /// <summary>
        /// Правая ветка
        /// </summary>
        public BinaryTreeNode<T> RightNode { get; set; }  // Right Node

        /// <summary>
        /// Родитель
        /// </summary>
        public BinaryTreeNode<T> ParentNode { get; set; } // Parent Node

        /// <summary>
        /// Расположение узла относительно его родителя
        /// </summary>
        public Side? NodeSide =>
            ParentNode == null
            ? (Side?)null
            : ParentNode.LeftNode == this
                ? Side.Left
                : Side.Right;

        /// <summary>
        /// Преобразование экземпляра класса в строку
        /// </summary>
        /// <returns>Данные узла дерева</returns>
        public override string ToString() => Data.ToString();
    }


    /// <summary>
    /// Бинарное дерево
    /// </summary>
    /// <typeparam name="T">Тип данных хранящихся в узлах</typeparam>
    public class BinaryTree<T> where T : IComparable
    {
        /// <summary>
        /// Корень бинарного дерева
        /// </summary>
        public BinaryTreeNode<T> RootNode { get; set; }

        /// <summary>
        /// Добавление нового узла в бинарное дерево
        /// </summary>
        /// <param name="node">Новый узел</param>
        /// <param name="currentNode">Текущий узел</param>
        /// <returns>Узел</returns>
        public BinaryTreeNode<T> Add(BinaryTreeNode<T> node, BinaryTreeNode<T> currentNode = null)
        {
            if (RootNode == null)
            {
                node.ParentNode = null;
                return RootNode = node;
            }

            currentNode = currentNode ?? RootNode;
            node.ParentNode = currentNode;
            int result;
            return (result = node.Data.CompareTo(currentNode.Data)) == 0
                ? currentNode
                : result < 0
                    ? currentNode.LeftNode == null
                        ? (currentNode.LeftNode = node)
                        : Add(node, currentNode.LeftNode)
                    : currentNode.RightNode == null
                        ? (currentNode.RightNode = node)
                        : Add(node, currentNode.RightNode);
        }


        /// <summary>
        /// Добавление данных в бинарное дерево
        /// </summary>
        /// <param name="data">Данные</param>
        /// <returns>Узел</returns>
        public BinaryTreeNode<T> Add(T data)
        {
            return Add(new BinaryTreeNode<T>(data));
        }

        /// <summary>
        /// Поиск узла по значению
        /// </summary>
        /// <param name="data">Искомое значение</param>
        /// <param name="startWithNode">Узел начала поиска</param>
        /// <returns>Найденный узел</returns>
        public BinaryTreeNode<T> FindNode(T data, BinaryTreeNode<T> startWithNode = null)
        {
            startWithNode = startWithNode ?? RootNode;
            int result;
            return (result = data.CompareTo(startWithNode.Data)) == 0
                ? startWithNode
                : result < 0
                    ? startWithNode.LeftNode == null
                        ? null
                        : FindNode(data, startWithNode.LeftNode)
                    : startWithNode.RightNode == null
                        ? null
                        : FindNode(data, startWithNode.RightNode);
        }


        /// <summary>
        /// Удаление узла бинарного дерева
        /// </summary>
        /// <param name="node">Узел для удаления</param>
        public void Remove(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }

            var currentNodeSide = node.NodeSide;
            //если у узла нет подузлов, можно его удалить
            if (node.LeftNode == null && node.RightNode == null)
            {
                if (currentNodeSide == Side.Left)
                {
                    node.ParentNode.LeftNode = null;
                }
                else
                {
                    node.ParentNode.RightNode = null;
                }
            }
            //если нет левого, то правый ставим на место удаляемого 
            else if (node.LeftNode == null)
            {
                if (currentNodeSide == Side.Left)
                {
                    node.ParentNode.LeftNode = node.RightNode;
                }
                else
                {
                    node.ParentNode.RightNode = node.RightNode;
                }

                node.RightNode.ParentNode = node.ParentNode;
            }
            //если нет правого, то левый ставим на место удаляемого 
            else if (node.RightNode == null)
            {
                if (currentNodeSide == Side.Left)
                {
                    node.ParentNode.LeftNode = node.LeftNode;
                }
                else
                {
                    node.ParentNode.RightNode = node.LeftNode;
                }

                node.LeftNode.ParentNode = node.ParentNode;
            }
            //если оба дочерних присутствуют, 
            //то правый становится на место удаляемого,
            //а левый вставляется в правый
            else
            {
                switch (currentNodeSide)
                {
                    case Side.Left:
                        node.ParentNode.LeftNode = node.RightNode;
                        node.RightNode.ParentNode = node.ParentNode;
                        Add(node.LeftNode, node.RightNode);
                        break;
                    case Side.Right:
                        node.ParentNode.RightNode = node.RightNode;
                        node.RightNode.ParentNode = node.ParentNode;
                        Add(node.LeftNode, node.RightNode);
                        break;
                    default:
                        var bufLeft = node.LeftNode;
                        var bufRightLeft = node.RightNode.LeftNode;
                        var bufRightRight = node.RightNode.RightNode;
                        node.Data = node.RightNode.Data;
                        node.RightNode = bufRightRight;
                        node.LeftNode = bufRightLeft;
                        Add(bufLeft, node);
                        break;
                }
            }
        }

        /// <summary>
        /// Удаление узла дерева
        /// </summary>
        /// <param name="data">Данные для удаления</param>
        public void Remove(T data)
        {
            var foundNode = FindNode(data);
            Remove(foundNode);
        }

        /// <summary>
        /// Вывод бинарного дерева
        /// </summary>
        public void PrintTree()
        {
            PrintTree(RootNode);
        }

        /// <summary>
        /// Вывод бинарного дерева начиная с указанного узла
        /// </summary>
        /// <param name="startNode">Узел с которого начинается печать</param>
        /// <param name="indent">Отступ</param>
        /// <param name="side">Сторона</param>
        private void PrintTree(BinaryTreeNode<T> startNode, string indent = "", Side? side = null)
        {
            if (startNode != null)
            {
                var nodeSide = side == null ? "+" : side == Side.Left ? "L" : "R";
                Console.WriteLine($"{indent} [{nodeSide}]- {startNode.Data}");
                indent += new string(' ', 3);
                //рекурсивный вызов для левой и правой веток
                PrintTree(startNode.LeftNode, indent, Side.Left);
                PrintTree(startNode.RightNode, indent, Side.Right);
            }
        }
    }

    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode LeftChild { get; set; }
        public TreeNode RightChild { get; set; }
        public override bool Equals(object obj)
        {
            var node = obj as TreeNode;
            if (node == null)
                return false;
            return node.Value == Value;
        }
    }

    public interface ITree
    {
        TreeNode GetRoot();
        void AddItem(int value); // добавить узел
        void RemoveItem(int value); // удалить узел по значению
        TreeNode GetNodeByValue(int value); //получить узел дерева по значению
        void PrintTree(); //вывести дерево в консоль
    }

    public class NodeInfo
    {
        public int Depth { get; set; }
        public TreeNode Node { get; set; }
    }

    public static class TreeHelper
    {
        public static NodeInfo[] GetTreeInLine(ITree tree)
        {
            var bufer = new Queue<NodeInfo>();
            var returnArray = new List<NodeInfo>();
            var root = new NodeInfo() { Node = tree.GetRoot() };
            bufer.Enqueue(root);
            while (bufer.Count != 0)
            {
                var element = bufer.Dequeue();
                returnArray.Add(element);
                var depth = element.Depth + 1;
                if (element.Node.LeftChild != null)
                {
                    var left = new NodeInfo()
                    {
                        Node = element.Node.LeftChild,
                        Depth = depth,
                    };
                    bufer.Enqueue(left);
                }
                if (element.Node.RightChild != null)
                {
                    var right = new NodeInfo()
                    {
                        Node = element.Node.RightChild,
                        Depth = depth,
                    };
                    bufer.Enqueue(right);
                }
            }
            return returnArray.ToArray();
        }
    }


    public class Program
    {
        static void Main(string[] args)
        {
            //2. Реализуйте двоичное дерево и метод вывода его в консоль
            var binaryTree = new BinaryTree<int>();

            binaryTree.Add(8);
            binaryTree.Add(3);
            binaryTree.Add(10);
            binaryTree.Add(1);
            binaryTree.Add(6);
            binaryTree.Add(4);
            binaryTree.Add(7);
            binaryTree.Add(14);
            binaryTree.Add(16);

            binaryTree.PrintTree();

            Console.WriteLine(new string('-', 40));
            binaryTree.Remove(3);
            binaryTree.PrintTree();

            Console.WriteLine(new string('-', 40));
            binaryTree.Remove(8);
            binaryTree.PrintTree();

            Console.ReadLine();




            // 1. Протестируйте поиск строки в HashSet и в массиве (Diagnose with benchmark)
            /*
            InitRandomString(5,10000);
            
            BenchmarkSwitcher.FromAssembly(typeof(SearchClass).Assembly).Run(args);

            SearchClass search = new SearchClass();

            search.SearchValueInArray();
            search.SearchValueInHashSet();
            */






            /*Hash set example
            var hashSet = new HashSet<User>();
            var user = new User() { FirstName = "Barbara", SecondName = "Santa" };
            hashSet.Add(user);
            var searchUsser = new User()
            {
                FirstName = "Barbara1",
                SecondName = "Santa"
            };

            Console.WriteLine($"contains user {hashSet.Contains(user)}, contains search User " + hashSet.Contains(searchUsser));
            */
        }


        private static Random random = new Random();
        private static HashSet<string> RndHashset = new HashSet<string>();
        private static string[] RndArray = new string[10000];
        private static string lastString = string.Empty;


        // create random string and add to hashset and array
        public static void InitRandomString(int lengthString, int nElements)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string strTemp = string.Empty;

            for (int i = 0; i < nElements; i++)
            {
                strTemp = new string(Enumerable.Repeat(chars, lengthString).Select(s => s[random.Next(s.Length)]).ToArray());
                RndArray[i] = strTemp;   //Array
                RndHashset.Add(strTemp); // Hashset
                lastString = strTemp;
            }
        }

        public class SearchClass
        {
            [Benchmark]
            public void SearchValueInArray()
            {
                //for (int i = 0; i < 10000; i++)
                //{
                //    if (RndArray[i] == lastString)
                //    {
                //        var result = RndArray[i];
                //    }
                //}

                var result = Array.Find(RndArray, x => x == lastString);
            }

            // in 27 thousand mls faster than array search
            [Benchmark]
            public  void SearchValueInHashSet()
            {
                var result = RndHashset.Contains(lastString);
            }
        }

        /// <summary>
        /// Example of ovveride function of hashset (object)
        /// </summary>
        public class User
        {
            public string FirstName { get; set; }
            public string SecondName { get; set; }
            public override bool Equals(object obj)
            {
                var user = obj as User;

                if (user == null)
                    return false;
                return FirstName == user.FirstName && SecondName == user.SecondName;
            }

            public override int GetHashCode()
            {
                int firtsNameHashCode = FirstName?.GetHashCode() ?? 0;
                int secondNameHashCode = SecondName?.GetHashCode() ?? 0;
                return firtsNameHashCode ^ secondNameHashCode;
            }
        }


        // *** Not relevant for binary tree
        // Method to generate random values of integers
        private static void GenerateNumberForArray(int nElements, int[] Parr)
        {
            Random rnd = new Random();

            for (int i = 0; i < nElements; i++)
            {
                Parr[i] = rnd.Next(0, 100);
            }
        }
    }
}
