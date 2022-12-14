namespace _02.BinarySearchTree
{
    using System;

    public class BinarySearchTree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }

        public BinarySearchTree() { }
        private BinarySearchTree(Node node)
        {
            this.PreOrderCopy(node);
        }

        private void PreOrderCopy(Node node)
        {
            if (node == null)
            {
                return;
            }

            this.Insert(node.Value);
            this.PreOrderCopy(node.Left);
            this.PreOrderCopy(node.Right);
        }

        private Node root;

        public bool Contains(T element)
        {
            return this.FindNode(element) != null;
        }

        private Node FindNode(T element)
        {
            var node = this.root;

            while (node != null)
            {
                if (element.CompareTo(node.Value) < 0)
                {
                    node = node.Left;
                }
                else if (element.CompareTo(node.Value) > 0)
                {
                    node = node.Right;
                }
                else
                {
                    break;
                }
            }

            return node;
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(action, this.root);
        }

        private void EachInOrder(Action<T> action, Node root)
        {
            if (root == null)
            {
                return;
            }

            this.EachInOrder(action, root.Left);
            action(root.Value);
            this.EachInOrder(action, root.Right);
        }

        public void Insert(T element)
        {
            this.root = this.Insert(element, this.root);
        }

        private Node Insert(T element, Node root)
        {
            if (root == null)
            {
                root = new Node(element);
            }
            else if (element.CompareTo(root.Value) < 0)
            {
                root.Left = this.Insert(element, root.Left);
            }
            else if (element.CompareTo(root.Value) > 0)
            {
                root.Right = this.Insert(element, root.Right);
            }

            return root;
        }

        public IBinarySearchTree<T> Search(T element)
        {
            var node = this.FindNode(element);

            if (node is null)
            {
                return null;
            }

            return new BinarySearchTree<T>(node);
        }
    }
}
