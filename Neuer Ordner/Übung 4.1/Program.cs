using System;
using System.Collections.Generic;
using System.Linq;

namespace _4_1_aufgabe
{
    public class TreeNode<T>
    {
        public T Data;
        public List<TreeNode<T>> Children = new List<TreeNode<T>>();

        public TreeNode<T> CreateNode(T data)
        {
            TreeNode<T> newNode = new TreeNode<T>
            {
                Data = data
            };
            return newNode;
        }

        public void AppendChild(TreeNode<T> child)
        {
            Children.Add(child);
        }

        public void RemoveChild(TreeNode<T> child)
        {
            Children.Remove(child);
        }

        public void PrintTree(String AddTree = "")
        {
            Console.WriteLine(AddTree + Data);
            foreach (TreeNode<T> child in Children)
            {
                child.PrintTree(AddTree + "*");
            }
        }

        public List<TreeNode<T>> FindChild(T search, List<TreeNode<T>> Nodes = null)
        {
            if (Nodes == null)
            {
                Nodes = new List<TreeNode<T>>();
            }
            if (Data.Equals(search))
            {
                Nodes.Add(this);
            }
            foreach (TreeNode<T> child in Children)
            {
                child.FindChild(search, Nodes);
            }
            return Nodes;
        }
        
        public override string ToString()
        {
            return Data.ToString();
        }
    
    }


    class Program
    {
        static void Main(string[] args)
        {
            var root = new TreeNode<string>("I am Zeus");
            var child1 = new TreeNode<string>("Iam the son of Zeus", root);
            var child2 = new TreeNode<string>("I am the daughter of Zeus", root);
            var child3 = new TreeNode<string>("I am Perseus, son of Zeus and the strongest half god on earth", root);
            var gchild11 = new TreeNode<string>("I am the daughter of the son of Zeus", child1);
            var gchild12 = new TreeNode<string>("I am the son of the daughter of Zeus", child1);
            var gchild13 = new TreeNode<string>("Zeus is my Grandfather", child1);
            var ggchild121 = new TreeNode<string>("Zeus is my great grandfather", gchild12);
            var gggchild1211 = new TreeNode<string>("I am a descendant of Zeus", ggchild121);

            root.PrintTree();

            Console.WriteLine("");
            ggchild121.RemoveChild(gggchild1211);
            gchild11.AppendChild(gggchild1211);
            root.PrintTree();

        }
    }
}

