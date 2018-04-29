using System;
using System.Collections.Generic;
using System.Linq;

namespace Übung_4
{
    class TreeNode<T>
    {
        private T _Content;
        private TreeNode<T> Parent;
        private List<TreeNode<T>> Children = new List<TreeNode<T>>();

        public TreeNode(T content)
        {
            _Content = content;
        }

        public TreeNode(T content, TreeNode<T> parent)
        {
            _Content = content;
            parent.AppendChild(this);
        }

        public void AppendChild(TreeNode<T> node)
        {
            Children.Add(node);
            node.Parent = this;
        }

        public void RemoveChild(TreeNode<T> node)
        {
            Children.Remove(node);
        }

        public void PrintTree()
        {
            Console.WriteLine(GetTreeString());
        }

        private string GetTreeString(string prefix = "")
        {
            string result = _Content.ToString();

            if (Children.Count != 0)
            {
                TreeNode<T> lastChild = Children.Last();
                foreach (TreeNode<T> child in Children)
                {
                    if (lastChild == child)
                    {
                        result += "\n" + prefix + "└─ " + child.GetTreeString(prefix + "   ");
                    }
                    else
                    {
                        result += "\n" + prefix + "├─ " + child.GetTreeString(prefix + "|  ");
                    }
                }
            }
            return result;
        }

        public override string ToString()
        {
            return _Content.ToString();
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
