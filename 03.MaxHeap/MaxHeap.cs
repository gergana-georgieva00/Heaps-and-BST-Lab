namespace _03.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T> where T : IComparable<T>
    {
        private List<T> elements;

        public MaxHeap()
        {
            this.elements = new List<T>();
        }

        public int Size => this.elements.Count;

        public void Add(T element)
        {
            this.elements.Add(element);
            this.HeapUp(this.elements.Count - 1);
        }

        private void HeapUp(int index)
        {
            var parentIndex = this.GetParentIndex(index);

            while (index > 0 && IsGreater(index, parentIndex))
            {
                this.Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = this.GetParentIndex(index);
            }
        }

        private void Swap(int index, int parentIndex)
        {
            var temp = this.elements[index];
            this.elements[index] = this.elements[parentIndex];
            this.elements[parentIndex] = temp;
        }

        private bool IsGreater(int index, int parentIndex)
            => this.elements[index].CompareTo(this.elements[parentIndex]) > 0;

        private int GetParentIndex(int index)
            => (index - 1) / 2;

        public T ExtractMax()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException();
            }

            T element = this.elements[0];
            this.Swap(0, this.elements.Count - 1);
            this.elements.RemoveAt(this.elements.Count - 1);
            this.HeapDown(0);

            return element;
        }

        private void HeapDown(int index)
        {
            var biggerChildIndex = this.GetBiggerChildIndex(index);

            while (IsIndexValid(index) && this.IsGreater(biggerChildIndex, index))
            {
                this.Swap(biggerChildIndex, index);
                index = biggerChildIndex;
                biggerChildIndex = this.GetBiggerChildIndex(index);
            }
        }

        private bool IsIndexValid(int index)
            => index >= 0 && index < this.elements.Count;

        private int GetBiggerChildIndex(int index)
        {
            var firstChildIndex = index * 2 + 1;
            var secondChildIndex = index * 2 + 2;

            if (secondChildIndex < this.elements.Count)
            {
                if (this.IsGreater(firstChildIndex, secondChildIndex))
                {
                    return firstChildIndex;
                }

                return secondChildIndex;
            }
            else if (firstChildIndex < this.elements.Count)
            {
                return firstChildIndex;
            }
            else
            {
                return 1;
            }
        }

        public T Peek()
        {
            throw new NotImplementedException();
        }
    }
}
