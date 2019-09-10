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

            foreach(DirectoryInfo child in children)
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
            while(visitedDirQueue.Count > 0)
            {
                DirectoryInfo currentDir = visitedDirQueue.Dequeue();
                Console.WriteLine(currentDir.FullName);
                DirectoryInfo[] children = currentDir.GetDirectories();
                foreach(DirectoryInfo child in children)
                {
                    visitedDirQueue.Enqueue(child);
                }

            }
            


        }

        static void Main()
        {
            TraverseDir("C:\\Users\\NJ050685\\Documents\\OCRTessaract\\OCRTesseract");
        }
    }


   




}
