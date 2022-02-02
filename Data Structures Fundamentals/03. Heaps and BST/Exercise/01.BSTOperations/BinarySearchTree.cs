namespace _01.BSTOperations
{
    using System;
    using System.Collections.Generic;

    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {
        public BinarySearchTree()
        {
        }

        public BinarySearchTree(Node<T> root)
        {
            this.CopyNode(root);
        }

        private void CopyNode(Node<T> node)
        {
            if (node != null)
            {
                this.Insert(node.Value);
                this.CopyNode(node.LeftChild);
                this.CopyNode(node.RightChild);
            }
        }

        public Node<T> Root { get; private set; }

        public int Count { get; private set; }

        public bool Contains(T element)
        {
            // DFS Solution
            // return Contains(element, this.Root);

            var node = this.Root;

            while (node != null)
            {
                if (node.Value.CompareTo(element) > 0)
                {
                    node = node.LeftChild;
                }
                else if (node.Value.CompareTo(element) < 0)
                {
                    node = node.RightChild;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        public bool Contains(T element, Node<T> node)
        {
            if (node == null)
            {
                return false;
            }
            if (node.Value.CompareTo(element) == 0)
            {
                return true;
            }

            if (node.Value.CompareTo(element) > 0)
            {
                return Contains(element, node.LeftChild);
            }
            else
            {
                return Contains(element, node.RightChild);
            }
        }

        public void Insert(T element)
        {
            Insert(element, this.Root);
        }

        public void Insert(T element, Node<T> node)
        {
            if (node == null)
            {
                this.Root = new Node<T>(element, null, null);
                this.Count++;
                return;
            }

            if (node.Value.CompareTo(element) > 0)
            {
                if (node.LeftChild == null)
                {
                    node.LeftChild = new Node<T>(element, null, null);
                    this.Count++;
                    return;
                }
                Insert(element, node.LeftChild);
            }
            else
            {
                if (node.RightChild == null)
                {
                    node.RightChild = new Node<T>(element, null, null);
                    this.Count++;
                    return;
                }
                Insert(element, node.RightChild);
            }
        }

        public IAbstractBinarySearchTree<T> Search(T element)
        {
            // DFS Solution
            // return Search(element, this.Root);

            var node = this.Root;

            while (node != null)
            {
                if (node.Value.CompareTo(element) > 0)
                {
                    node = node.LeftChild;
                }
                else if (node.Value.CompareTo(element) < 0)
                {
                    node = node.RightChild;
                }
                else
                {
                    return new BinarySearchTree<T>(node);
                }
            }

            return null;
        }

        public IAbstractBinarySearchTree<T> Search(T element, Node<T> node)
        {
            if (node == null)
            {
                return null;
            }
            if (node.Value.CompareTo(element) == 0)
            {
                return new BinarySearchTree<T>(node);
            }

            if (node.Value.CompareTo(element) > 0)
            {
                return Search(element, node.LeftChild);
            }
            else
            {
                return Search(element, node.RightChild);
            }
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(action, this.Root);
        }

        private void EachInOrder(Action<T> action, Node<T> node)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(action, node.LeftChild);

            action.Invoke(node.Value);

            this.EachInOrder(action, node.RightChild);
        }

        public List<T> Range(T lower, T upper)
        {
            var result = new List<T>();

            this.Range(lower, upper, this.Root, result);

            return result;
        }

        private void Range(T startRange, T endRange, Node<T> node, List<T> result)
        {
            if (node == null)
            {
                return;
            }

            var inStartRange = startRange.CompareTo(node.Value);
            var inEndRange = endRange.CompareTo(node.Value);

            if (inStartRange < 0)
            {
                this.Range(startRange, endRange, node.LeftChild, result);
            }

            if (inStartRange <= 0 && inEndRange >= 0)
            {
                result.Add(node.Value);
            }

            if (inEndRange > 0)
            {
                this.Range(startRange, endRange, node.RightChild, result);
            }
        }

        public void DeleteMin()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            this.Root.LeftChild = this.DeleteMin(this.Root.LeftChild);
        }

        private Node<T> DeleteMin(Node<T> node)
        {
            if (node.LeftChild == null)
            {
                this.Count--;
                return node.RightChild;
            }

            node.LeftChild = this.DeleteMin(node.LeftChild);
            return node;
        }

        public void DeleteMax()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            this.Root.RightChild = this.DeleteMax(this.Root.RightChild);
        }

        private Node<T> DeleteMax(Node<T> node)
        {
            if (node.RightChild == null)
            {
                this.Count--;
                return node.LeftChild;
            }

            node.RightChild = this.DeleteMax(node.RightChild);
            return node;
        }

        public int GetRank(T element)
        {
            int rank = 0;

            this.GetRank(element, this.Root, ref rank);

            return rank;
        }

        private void GetRank(T element, Node<T> node, ref int rank)
        {
            if (node == null)
            {
                return;
            }

            if (element.CompareTo(node.Value) > 0)
            {
                this.GetRank(element, node.LeftChild, ref rank);
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                this.GetRank(element, node.LeftChild, ref rank);
            }

            if (element.CompareTo(node.Value) >= 0)
            {
                rank++;
            }

            if (element.CompareTo(node.Value) > 0)
            {
                this.GetRank(element, node.RightChild, ref rank);
            }
        }
    }
}
