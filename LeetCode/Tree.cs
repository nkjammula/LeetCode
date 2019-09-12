using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LeetCode
{
    class TreeNode<T>
    {
        private T Value;

        private bool HasParent;

        private List<TreeNode<T>> children;

        public TreeNode(T val)
        {
            if (val == null)
            {
                throw new ArgumentNullException("Cannot insert null");
            }
            this.Value = val;
            this.children = new List<TreeNode<T>>();
        }

        public T value
        {
            get
            {
                return this.Value;
            }

            set
            {
                this.Value = value;
            }
        }

        public int ChildreCount
        {
            get
            {
                return this.children.Count;
            }
        }

        public void AddChild(TreeNode<T> child)
        {
            if (child == null)
            {
                throw new ArgumentException("Cannot add null value");
            }

            if (child.HasParent)
            {
                throw new ArgumentException("THis node already has a parent");
            }

            child.HasParent = true;
            children.Add(child);
        }

        public TreeNode<T> getChild(int index)
        {
            return this.children[index];
        }
    }

    class Tree<T>
    {
        private TreeNode<T> root;

        public Tree(T value)
        {
            if (value == null)
            {
                throw new ArgumentException("Cannot insert null value");
            }

            this.root = new TreeNode<T>(value);
        }

        public Tree(T value, params Tree<T>[] children) : this(value)
        {
            foreach (Tree<T> child in children)
            {
                this.root.AddChild(child.root);
            }
        }


        public TreeNode<T> Root
        {
            get
            {
                return this.root;
            }
        }


        public void PrintDFS(TreeNode<T> root, string spaces)
        {
            if (this.root == null)
            {
                return;
            }

            Console.WriteLine(spaces + root.value);
            Console.ReadLine();
            TreeNode<T> child = null;

            for (int i = 0; i < root.ChildreCount; i++)
            {
                child = root.getChild(i);
                PrintDFS(child, spaces + " ");
            }

        }

        public void TraverseDFS()
        {
            this.PrintDFS(this.root, string.Empty);
        }
    }

    public static class TreeExample
    {
        //public static void Main(String[] args)
        //{
        //    Tree<int> tree =

        //   new Tree<int>(7,

        //       new Tree<int>(19,

        //           new Tree<int>(1),

        //           new Tree<int>(12),

        //           new Tree<int>(31)),

        //       new Tree<int>(21),

        //       new Tree<int>(14,

        //           new Tree<int>(23),

        //           new Tree<int>(6))

        //   );
        //    tree.TraverseDFS();
        //}
    }

    public static class DirectoryTraverserDFS
    {
        private static void TraverseDir(DirectoryInfo dir, string spaces)
        {
            Console.WriteLine(spaces + dir.FullName);
            Console.ReadLine();

            DirectoryInfo[] children = dir.GetDirectories();

            foreach (DirectoryInfo child in children)
            {
                TraverseDir(child, spaces + " ");
            }
        }

        static void TraverseDir(string directoryPath)
        {
            TraverseDir(new DirectoryInfo(directoryPath), string.Empty);
        }

        //static void Main()
        //{
        //    TraverseDir("C:\\Users\\NJ050685\\Documents\\OCRTessaract\\OCRTesseract");
        //}
    }


    public static class DirectoryTraverserBFS
    {
        static void TraverseDir(string directoryPath)
        {
            //Queue<DirectoryInfo> visitedDirsQueue = new Queue<DirectoryInfo>();
            //visitedDirsQueue.Enqueue(new DirectoryInfo(directoryPath));

            //while(visitedDirsQueue.Count >0)
            //{
            //    DirectoryInfo currentDirectory = visitedDirsQueue.Dequeue();
            //    Console.WriteLine(currentDirectory.FullName);

            //}
            Queue<DirectoryInfo> visitedDirQueue = new Queue<DirectoryInfo>();
            visitedDirQueue.Enqueue(new DirectoryInfo(directoryPath));
            while (visitedDirQueue.Count > 0)
            {
                DirectoryInfo currentDir = visitedDirQueue.Dequeue();
                Console.WriteLine(currentDir.FullName);
                DirectoryInfo[] children = currentDir.GetDirectories();
                foreach (DirectoryInfo child in children)
                {
                    visitedDirQueue.Enqueue(child);
                }

            }



        }

        //static void Main()
        //{
        //    TraverseDir("C:\\Users\\NJ050685\\Documents\\OCRTessaract\\OCRTesseract");
        //}
    }

    public class BinaryTree<T>
    {
        public T Value { get; set; }

        public BinaryTree<T> leftChild { get; set; }

        public BinaryTree<T> rightChild { get; set; }

        public BinaryTree(T Value, BinaryTree<T> leftChild, BinaryTree<T> rightChild)
        {
            this.leftChild = leftChild;
            this.rightChild = rightChild;
            this.Value = Value;
        }

        public BinaryTree(T value) : this(value, null, null)
        {

        }

        public void PrintInOrder()
        {
            if(this.leftChild != null)
            {
                this.leftChild.PrintInOrder();
            }

            Console.WriteLine(this.Value);

            if(this.rightChild != null)
            {
                this.rightChild.PrintInOrder();
            }
        }


        public void PrintPreOrder()
        {
            Console.WriteLine(this.Value);

            if(this.leftChild != null)
            {
                this.leftChild.PrintPreOrder();
            }

            if(this.rightChild != null)
            {
                this.rightChild.PrintPreOrder();
            }
        }

        public void PrintPostOrder()
        {
            if(this.leftChild != null)
            {
                this.leftChild.PrintPostOrder();
            }

            if(this.rightChild != null)
            {
                this.rightChild.PrintPostOrder();
            }

            Console.WriteLine(this.Value);
        }

       

    }

    class BinaryTreeExample
    {
        //static void Main()
        //{
        //    BinaryTree<int> binaryTree =

        //   new BinaryTree<int>(14,

        //           new BinaryTree<int>(19,

        //                 new BinaryTree<int>(23),

        //                 new BinaryTree<int>(6,

        //                         new BinaryTree<int>(10),

        //                         new BinaryTree<int>(21))),

        //           new BinaryTree<int>(15,

        //                 new BinaryTree<int>(3),

        //                 null));



        //    // Traverse and print the tree in in-order manner

        //    binaryTree.PrintInOrder();

        //    binaryTree.PrintPreOrder();

        //    binaryTree.PrintPostOrder();

        //    Console.WriteLine();
        //}
    }
}
