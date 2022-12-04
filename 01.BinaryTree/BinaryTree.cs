﻿namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;

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
            throw new NotImplementedException();
        }

        public void ForEachInOrder(Action<T> action)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IAbstractBinaryTree<T>> InOrder()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IAbstractBinaryTree<T>> PostOrder()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IAbstractBinaryTree<T>> PreOrder()
        {
            var resultList = new List<IAbstractBinaryTree<T>>();

            resultList.Add(this);
            resultList.AddRange(this.LeftChild.PreOrder());
            resultList.AddRange(this.RightChild.PreOrder());

            return resultList;
        }
    }
}
