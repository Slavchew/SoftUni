namespace _01.Red_Black_Tree
{
    using System;
    using System.Collections.Generic;

    public class RedBlackTree<T> 
        : IBinarySearchTree<T> where T : IComparable
    {
        private const bool Red = true;
        private const bool Black = false;
        private Node root;

        public RedBlackTree()
        {
        }

        public int Count { get => this.root != null ? this.root.Count : 0; }

        public void Insert(T element)
        {
            this.root = Insert(this.root, element);
            this.root.Color = Black;
        }

        private Node Insert(Node node, T element)
        {
            if (node == null)
            {
                return new Node(element) { Count = 1 };
            }

            var cmp = element.CompareTo(node.Value);
            if (cmp > 0)
            {
                node.Right = Insert(node.Right, element);
            }
            if (cmp < 0)
            {
                node.Left = Insert(node.Left, element);
            }

            if (this.IsRed(node.Right) && !this.IsRed(node.Left))
            {
                node = this.RotateLeft(node);
            }
            if (this.IsRed(node.Left) && this.IsRed(node.Left.Left))
            {
                node = this.RotateRight(node);
            }
            if (this.IsRed(node.Left) && this.IsRed(node.Right))
            {
                this.FlipColors(node);
            }

            node.Count = 1 + GetCount(node.Left) + GetCount(node.Right);
            return node;
        }

        private void FlipColors(Node node)
        {
            node.Color = Red;
            node.Left.Color = Black;
            node.Right.Color = Red;
        }

        private Node RotateRight(Node node)
        {
            var temp = node.Left;
            node.Left = temp.Right;
            temp.Right = node;

            temp.Color = node.Color;
            node.Color = Red;
            node.Count = 1 + GetCount(node.Left) + GetCount(node.Right);

            return temp;
        }

        private Node RotateLeft(Node node)
        {
            var temp = node.Right;
            node.Right = temp.Left;
            temp.Left = node;

            temp.Color = node.Color;
            node.Color = Red;
            node.Count = 1 + GetCount(node.Left) + GetCount(node.Right);

            return temp;
        }

        private bool IsRed(Node node)
        {
            if (node == null)
            {
                return false;
            }
            return node.Color;
        }

        private int GetCount(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Count;
        }

        public T Select(int rank)
        {
            var node = Select(this.root, rank);

            if (node == null)
            {
                throw new InvalidOperationException();
            }

            return node.Value;
        }

        private Node Select(Node node, int rank)
        {
            if (node == null)
            {
                return null;
            }

            var leftCount = GetCount(node.Left);
            if (leftCount == rank)
            {
                return node;
            }
            if (leftCount > rank)
            {
                return Select(node.Left, rank);
            }

            return Select(node.Right, rank - (leftCount - 1));
        }

        public int Rank(T element)
        {
            return Rank(this.root, element);
        }

        private int Rank(Node node, T element)
        {
            if (node == null)
            {
                return 0;
            }

            var cmp = element.CompareTo(node.Value);
            if (cmp < 0)
            {
                return this.Rank(node.Left, element);
            }
            if (cmp > 0)
            {
                return this.Rank(node.Right, element) + GetCount(node.Left) + 1;
            }

            return GetCount(node.Left);
        }

        public bool Contains(T element)
        {
            var node = FindElement(element);
            return node != null;
        }

        private Node FindElement(T element)
        {
            var current = this.root;

            while (current != null)
            {
                var cmp = current.Value.CompareTo(element);
                if (cmp > 0)
                {
                    current = current.Left;
                }
                else if (cmp < 0)
                {
                    current = current.Right;
                }
                else
                {
                    return current;
                }

            }

            return null;
        }

        public IBinarySearchTree<T> Search(T element)
        {
            var node = this.FindElement(element);
            var tree = new RedBlackTree<T>();
            tree.root = node;

            return tree;
        }

        public void DeleteMin()
        {
            if (this.root == null)
            {
                throw new InvalidOperationException();
            }

            this.root = DeleteMin(this.root);
        }

        private Node DeleteMin(Node node)
        {
            if (node.Left == null)
            {
                return node.Right;
            }

            node.Left = DeleteMin(node.Left);
            node.Count = 1 + GetCount(node.Left) + GetCount(node.Right);

            return node;
        }

        public void DeleteMax()
        {
            if (this.root == null)
            {
                throw new InvalidOperationException();
            }

            this.root = DeleteMax(this.root);
        }

        private Node DeleteMax(Node node)
        {
            if (node.Right == null)
            {
                return node.Left;
            }

            node.Right = DeleteMin(node.Right);
            node.Count = 1 + GetCount(node.Left) + GetCount(node.Right);

            return node;
        }

        public IEnumerable<T> Range(T startRange, T endRange)
        {
            return null;
        }

        public  void Delete(T element)
        {
            this.root = Delete(this.root, element);
        }

        private Node Delete(Node node, T element)
        {
            if (node == null)
            {
                return null;
            }

            var cmp = element.CompareTo(node.Value);
            if (cmp > 0)
            {
                node.Right = Delete(node.Right, element);
            }
            else if (cmp < 0)
            {
                node.Left = Delete(node.Left, element);
            }
            else
            {
                if (node.Right == null)
                {
                    return node.Left;
                }

                if (node.Left == null)
                {
                    return node.Right;
                }

                Node temp = node;
                node = FindMin(temp.Right);
                node.Right = DeleteMin(temp.Right);
                node.Left = temp.Left;
            }

            node.Count = 1 + GetCount(node.Right) + GetCount(node.Left);

            return node;
        }

        private Node FindMin(Node node)
        {
            if (node.Left == null)
            {
                return node;
            }

            return FindMin(node.Left);
        }

        public T Ceiling(T element)
        {
            return Select(Rank(element) + 1);
        }

        public T Floor(T element)
        {
            return Select(Rank(element) - 1);
        }

        public void EachInOrder(Action<T> action)
        {
            EachInOrder(this.root, action);
        }

        private void EachInOrder(Node node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            EachInOrder(node.Left, action);
            action.Invoke(node.Value);
            EachInOrder(node.Right, action);
        }

        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
                this.Color = Red;
            }

            public T Value { get; }

            public Node Left { get; set; }

            public Node Right { get; set; }

            public int Count { get; set; }

            public bool Color { get; set; }
        }
    }
}