namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T element, IAbstractBinaryTree<T> left, IAbstractBinaryTree<T> right)
        {
            this.Value = element;
            this.LeftChild = left;
            this.RightChild = right;
        }

        public T Value { get; private set; }

        public IAbstractBinaryTree<T> LeftChild { get; private set; }

        public IAbstractBinaryTree<T> RightChild { get; private set; }

        public string AsIndentedPreOrder(int indent)
        {
            var sb = new StringBuilder();

            this.PreOrderDfs(sb, indent, this);

            return sb.ToString();
        }

        private void PreOrderDfs(StringBuilder sb, int indent, IAbstractBinaryTree<T> binaryTree)
        {
            sb.Append(new string(' ', indent)).AppendLine(binaryTree.Value.ToString());

            if (binaryTree.LeftChild != null)
            {
                this.PreOrderDfs(sb, indent + 2, binaryTree.LeftChild);
            }
            if (binaryTree.RightChild != null)
            {
                this.PreOrderDfs(sb, indent + 2, binaryTree.RightChild);
            }
        }

        public void ForEachInOrder(Action<T> action)
        {
            this.LeftChild.ForEachInOrder(action);
            action(this.Value);
            this.RightChild.ForEachInOrder(action);
        }

        public IEnumerable<IAbstractBinaryTree<T>> InOrder()
        {
            var resultList = new List<IAbstractBinaryTree<T>>();

            if (this.LeftChild != null)
            {
                resultList.AddRange(this.LeftChild.InOrder());
            }

            resultList.Add(this);

            if (RightChild != null)
            {
                resultList.AddRange(this.RightChild.InOrder());
            }

            return resultList;
        }

        public IEnumerable<IAbstractBinaryTree<T>> PostOrder()
        {
            var resultList = new List<IAbstractBinaryTree<T>>();

            if (this.LeftChild != null)
            {
                resultList.AddRange(this.LeftChild.PostOrder());
            }
            if (RightChild != null)
            {
                resultList.AddRange(this.RightChild.PostOrder());
            }

            resultList.Add(this);

            return resultList;
        }

        public IEnumerable<IAbstractBinaryTree<T>> PreOrder()
        {
            var resultList = new List<IAbstractBinaryTree<T>>();

            resultList.Add(this);
            if (this.LeftChild != null)
            {
                resultList.AddRange(this.LeftChild.PreOrder());
            }
            if (RightChild != null)
            {
                resultList.AddRange(this.RightChild.PreOrder());
            }

            return resultList;
        }
    }
}
