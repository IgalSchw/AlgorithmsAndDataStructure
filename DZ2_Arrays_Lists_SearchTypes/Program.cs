using AlgoDataSructure.Lesson2;
using DZ2_Arrays_Lists_SearchTypes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoDataSructure
{

    // test case for binary search
    class TestCase
    {
        public int[] arr { get; set; }
        public int searchValue { get; set; }
        public int ExpectedIndex { get; set; }
        public Exception ExpectedException { get; set; }
    }


    // for single linked list
    internal sealed class Node
    {
        public int Value { get; set; }
        public Node NextItem { get; set; }
        public Node(int value)
        {
            Value = value;
            NextItem = null;
        }
    }

    // single linked list class
    internal sealed class SingleLinkedList
    {
        public Node head;

        public void InsertLast(SingleLinkedList singlyList, int new_data)
        {
            Node new_node = new Node(new_data);
            if (singlyList.head == null)
            {
                singlyList.head = new_node;
                return;
            }
            Node lastNode = GetLastNode(singlyList);
            lastNode.NextItem = new_node;
        }

        // insert to from of lit
        public void InsertFront(SingleLinkedList singlyList, int new_data)
        {
            Node new_node = new Node(new_data);
            new_node.NextItem = singlyList.head;
            singlyList.head = new_node;
        }

        // get last node in list
        public Node GetLastNode(SingleLinkedList singlyList)
        {
            Node temp = singlyList.head;
            while (temp.NextItem != null) // log (n)
            {
                temp = temp.NextItem;
            }
            return temp;
        }

        // insert after target node (prev)
        public void InsertAfter(Node prev_node, int new_data)
        {
            if (prev_node == null)
            {
                Console.WriteLine("The given previous node Cannot be null");
                return;
            }
            Node new_node = new Node(new_data);
            new_node.NextItem = prev_node.NextItem;
            prev_node.NextItem = new_node;
        }

        // find node by value
        public Node FindNode(SingleLinkedList singlyList, int searchValue)
        {
            Node temp = singlyList.head;
            while (temp.NextItem != null)
            {
                if (temp.Value == searchValue)
                    return temp;

                temp = temp.NextItem;
            }

            return temp;
        }

        // delete node by value
        public void DeleteNodebyValue(SingleLinkedList singlyList, int value)
        {
            Node temp = singlyList.head;
            Node prev = null;
            if (temp != null && temp.Value == value)
            {
                singlyList.head = temp.NextItem;
                return;
            }
            while (temp != null && temp.Value != value)
            {
                prev = temp;
                temp = temp.NextItem;
            }
            if (temp == null)
            {
                return;
            }

            prev.NextItem = temp.NextItem;
        }
    }

    // for double linked list
    internal sealed class DNode
    {
        public int Value { get; set; }

        public DNode NextItem { get; set; }

        public DNode PrevItem { get; set; }

        public DNode(int value)
        {
            Value = value;
            NextItem = null;
            PrevItem = null;
        }
        public override string ToString()
        {

            return "{" + this.Value + "}";
        }
    }

    // double linked list class
    internal class DoubleLinkedList : ILinkedList
    {
        internal DNode head;

        // add to front of linked list
        public void AddFrontNode(int value)
        {
            DNode newNode = new DNode(value); // create new node 
            newNode.NextItem = this.head; // set current head to next item of new node
            newNode.PrevItem = null;

            if (this.head != null)
            {
                this.head.PrevItem = newNode; // if not first element set to head prev new node
            }

            this.head = newNode; // new head is the new created node
        }

        // add to last
        public void AddNode(int value)
        {
            DNode newNode = new DNode(value); // create new node

            if (this.head == null)
            {
                newNode.PrevItem = null;
                this.head = newNode; // update head node
                return;
            }

            DNode lastNode = GetLastNode(this);
            lastNode.NextItem = newNode;
            newNode.PrevItem = lastNode;
        }

        // get last node
        public DNode GetLastNode(DoubleLinkedList DoubleLinkedList)
        {
            DNode temp = DoubleLinkedList.head;

            while (temp.NextItem != null)
            {
                temp = temp.NextItem;
            }

            return temp;
        }

        // add after target node
        public void AddNodeAfter(DNode node, int value)
        {
            if (node == null) // cant be null (target node)
            {
                Console.WriteLine("Previous node can't be null");
                return;
            }

            DNode newNode = new DNode(value); // new node
            newNode.NextItem = node.NextItem; // change place newnode.nextItem <-> old.nextitem
            node.NextItem = newNode;          // old node next item -> new node
            newNode.PrevItem = node;          // prev item -> old node

            if (newNode.NextItem != null)     // have next item and it not was last
            {
                newNode.NextItem.PrevItem = newNode; // next item.previtem -> new created node
            }
        }

        // find node by value
        public DNode FindNode(int searchValue)
        {
            DNode temp = this.head;

            while (temp != null)
            {
                if (temp.Value == searchValue)
                    return temp;

                temp = temp.NextItem; // like iterator
            }

            return null;
        }

        // get number of nodes
        public int GetCount()
        {
            int count = 0;

            DNode tempNode = this.head; // save current list

            while (tempNode != null)
            {
                count++;
                tempNode = tempNode.NextItem;
            }

            return count;
        }

        // remove node by index
        public void RemoveNode(int index)
        {
            int counter = 1;

            DNode temp = this.head;

            // delete first element (set first element)
            if (temp != null && counter == index)
            {
                this.head = temp.NextItem;
                this.head.PrevItem = null;
                return;
            }
            // stop when found index or end of linked node
            while (temp != null && counter != index)
            {
                temp = temp.NextItem;
                counter++;
            }
            // not found any node return;
            if (temp == null)
                return;
            if (temp.NextItem != null)
            {
                temp.NextItem.PrevItem = temp.PrevItem;
            }

            if (temp.PrevItem != null)
            {
                temp.PrevItem.NextItem = temp.NextItem;
            }
        }

        // Remove node by node object
        public void RemoveNode(DNode node)
        {
            DNode temp = this.head;

            while (temp != null)
            {
                if (temp.Equals(node))
                    break;

                temp = temp.NextItem;
            }

            if (temp == null)
                return;

            if (temp.NextItem != null)
            {
                temp.NextItem.PrevItem = temp.PrevItem;
            }

            if (temp.PrevItem != null)
            {
                temp.PrevItem.NextItem = temp.NextItem;
            }
        }

        public void PrintDoubleLinkedList()
        {
            DNode node = this.head;

            while (node != null)
            {
                Console.WriteLine(node);
                node = node.NextItem;
            }
        }
    }

    class program
    {
        static void Main(string[] args)
        {
            #region single linked list

            /*
            SingleLinkedList singlelinkedList = new SingleLinkedList();

            // insert last
            singlelinkedList.InsertLast(singlelinkedList, 1);

            singlelinkedList.InsertLast(singlelinkedList, 2);

            singlelinkedList.InsertLast(singlelinkedList, 3);

            // insert first
            singlelinkedList.InsertFront(singlelinkedList, 0);

            // insert after node default after null
            singlelinkedList.InsertAfter(singlelinkedList.FindNode(singlelinkedList, 2), 2); // same exist value

            // remove first node by value
            singlelinkedList.DeleteNodebyValue(singlelinkedList, 2);
            */
            #endregion



            #region double linked list
            DoubleLinkedList doubleLinkedList = new DoubleLinkedList();
            doubleLinkedList.AddFrontNode(10);

            Console.WriteLine("Amount of nodes: " + doubleLinkedList.GetCount());

            doubleLinkedList.AddNode(5);

            Console.WriteLine("Amount of nodes: " + doubleLinkedList.GetCount());

            doubleLinkedList.AddNodeAfter(doubleLinkedList.FindNode(10), 7);

            Console.WriteLine("Amount of nodes: " + doubleLinkedList.GetCount());

            // e.g 1 == first element
            doubleLinkedList.RemoveNode(2);
            Console.WriteLine("Amount of nodes: " + doubleLinkedList.GetCount());


            DNode targetNode = doubleLinkedList.FindNode(5);
            doubleLinkedList.RemoveNode(targetNode);

            Console.WriteLine("Amount of nodes: " + doubleLinkedList.GetCount());
            Console.WriteLine("\n\n");

            Console.WriteLine("Double linked list:");
            doubleLinkedList.PrintDoubleLinkedList();
            #endregion


            #region Binary search
            // 2. Двоичный поиск
            int[] arr = new int[] { 10, 4, 5, 23, 12, 6, 8, 3, 10 };

            Array.Sort(arr); // O(n)

            Console.WriteLine("Sorted Array:");

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }

            Console.WriteLine("Array index:" + SearchTypes.BinarySearch(arr, 6));



            // Test case for binary search function
            TestCase testcase1 = new TestCase()
            {
                arr = arr,
                searchValue = 12,
                ExpectedIndex = 7,
                ExpectedException = null
            };


            // Test case for binary search function (Invalid Test)
            TestCase testcase2 = new TestCase()
            {
                arr = arr,
                searchValue = 12,
                ExpectedIndex = 6,
                ExpectedException = null
            };

            TestBinarySearch(testcase1);
            TestBinarySearch(testcase2);
            #endregion



            #region type os Sorts


            int[] arrTemp = { 3,4,6,2,1,34,32,12,33,33};

            SortTypes.IntArrayBubbleSort(arrTemp);

            arrTemp =new int [] { 3,4,6,2,1,34,32,12,33,33};

            SortTypes.IntArraySelectionSort(arrTemp);

            arrTemp = new int[] { 3, 4, 6, 2, 1, 34, 32, 12, 33, 33 };

            SortTypes.IntArrayInsertionSort(arrTemp);

            arrTemp = new int[] { 3, 4, 6, 2, 1, 34, 32, 12, 33, 33 };
            
            int[] intervals = { 1, 2, 4, 8,16 };

            SortTypes.IntArrayShellSort(arrTemp, intervals);






            #endregion
        }


        // Test prime number
        private static void TestBinarySearch(TestCase testCase)
        {
            try
            {
                var actual = SearchTypes.BinarySearch(testCase.arr, testCase.searchValue);

                if (actual == testCase.ExpectedIndex)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
            catch (Exception ex)
            {
                if (testCase.ExpectedException != null)
                {
                    //TODO add type exception tests;
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("Description: " + ex.Message);
                    Console.WriteLine("INVALID TEST");
                }
            }
        }
    }



    //interface
    internal interface ILinkedList
    {
        int GetCount(); // done
        void AddNode(int value); // done
        void AddNodeAfter(DNode node, int value); // done
        void RemoveNode(int index);
        void RemoveNode(DNode node);
        DNode FindNode(int searchValue); // done
    }

}



