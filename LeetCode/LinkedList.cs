using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class LinkedList
    {
        int Data;
        LinkedList Next;

        public LinkedList(int d)
        {
            Data = d;
            Next = null;
        }

        //static void Main(string[] args)
        //{
         
        //    Console.ReadLine();
        //}

        public static void SingleLinkedList()
        {

        }

    }

     public class Node1
    {
       public int data;
       internal Node1 next;
        public Node1(int d)
        {
            data = d;
            next = null;
        }
    }

    public class DNode
    {
        public int Data;
        internal DNode Prev;
        internal DNode next;
        public DNode(int d)
        {
            Data = d;
            Prev = null;
            next = null;
        }
    }

    public class SingleLinkedList
    {
        Node1 head;

        public void InsertFront(SingleLinkedList singleLinked, int data)
        {
            Node1 new_Node = new Node1(data);
            new_Node.data = data;
            new_Node.next = singleLinked.head;
            singleLinked.head = new_Node;
        }

        public void InsertLast(SingleLinkedList singleLinkedList, int Data)
        {
            Node1 New_Node = new Node1(Data);
            New_Node.data = Data;
            if(singleLinkedList == null)
            {
                singleLinkedList.head = New_Node;
                return;
            }
            Node1 lastNode = GetLasNode(singleLinkedList);
            lastNode.next = New_Node;
        }

        public Node1 GetLasNode(SingleLinkedList sList)
        {
            Node1 temp = sList.head;
            if(temp.next != null)
            {
               temp = temp.next;
            }
            return temp;
        }

        public void InsertNodeAt(Node1 PrevNode, int data)
        {
            Node1 new_Node = new Node1(data);
            if(PrevNode == null)
            {
                Console.WriteLine("New node cannot be null");
                return;
            }
            new_Node.next = PrevNode.next;
            PrevNode.next = new_Node;

        }

        public void DeleteByKey(SingleLinkedList singleLinkedList, int key)
        {
            Node1 temp = singleLinkedList.head;
            Node1 prev = null;
           
            if(temp !=null && temp.data == key)
            {
                singleLinkedList.head = temp.next;
                return;
            }

            while(temp !=null && temp.data != key)
            {
                prev = temp;
                temp = temp.next;
            }

            if (temp == null)
            {
                return;

            }

            prev.next = temp.next;
        }
    }

    public class DoubleLinkedList
    {
        DNode head;
        public static DNode GetLasNode(DoubleLinkedList sList)
        {
            DNode temp = sList.head;
            if (temp.next != null)
            {
                temp = temp.next;
            }
            return temp;
        }
        public static void insertFront(DoubleLinkedList dLinkedList, int data)
        {
            DNode new_Node = new DNode(data);
            new_Node.next = dLinkedList.head;
            new_Node.Prev = null;
            if(dLinkedList.head != null)
            {
                dLinkedList.head.Prev = new_Node;
            }
            dLinkedList.head = new_Node;
        }

        public static void insertBack(DoubleLinkedList doubleLinked, int data)
        {
            DNode new_Node = new DNode(data);
            if(doubleLinked.head == null)
            {
                new_Node.Prev = null;
                doubleLinked.head = new_Node;
                return;
            }
            DNode lastNode = GetLasNode(doubleLinked);
            lastNode.next = new_Node;
            new_Node.Prev = lastNode;
        }

        public static void InsertAtNode(DNode prevNode, int data)
        {
            DNode new_Node = new DNode(data);
            if(prevNode == null)
            {
                Console.WriteLine("prevNode is null");
                return;
            }
            new_Node.next = prevNode.next;
            prevNode.next = new_Node;
            new_Node.Prev = prevNode;
            if(new_Node.next != null)
            {
                new_Node.next.Prev = new_Node;
            }
        }

        public static void DeleteByKey(DoubleLinkedList doubleLinked, int Key)
        {
            DNode temp = doubleLinked.head;
            if(temp != null && temp.Data == Key)
            {
                doubleLinked.head = temp.next;
                doubleLinked.head.Prev = null;
            }
        }
    }


}
