namespace _05.TopView
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(T value, BinaryTree<T> left, BinaryTree<T> right)
        {
            this.Value = value;
            this.LeftChild = left;
            this.RightChild = right;
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public List<T> TopView()
        {
            var dictionary = new Dictionary<int, (T nodeValue, int nodeLevel)>();

            this.TopView(this, 0, 0, dictionary);

            return dictionary.Values.Select(x => x.nodeValue).ToList();
        }

        private void TopView
            (BinaryTree<T> node, int distance, int level, 
            Dictionary<int, (T nodeValue, int nodeLevel)> dictionary)
        {
            if (node == null)
            {
                return;
            }

            if (dictionary.ContainsKey(distance))
            {
                if (dictionary[distance].nodeLevel > level)
                {
                    dictionary[distance] = (node.Value, level);
                }
            }
            else
            {
                dictionary.Add(distance, (node.Value, level));
            }

            this.TopView(node.LeftChild, distance - 1, level + 1, dictionary);
            this.TopView(node.RightChild, distance + 1, level + 1, dictionary);
        }
    }
}
