namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T value
            , IAbstractBinaryTree<T> leftChild
            , IAbstractBinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public T Value { get; private set; }

        public IAbstractBinaryTree<T> LeftChild { get; private set; }

        public IAbstractBinaryTree<T> RightChild { get; private set; }

        public string AsIndentedPreOrder(int indent)
        {
            return AsIndentedPreOrder(this, indent);
        }

        private string AsIndentedPreOrder(IAbstractBinaryTree<T> tree, int indent)
        {
            string result = new string(' ', indent) + tree.Value + "\r\n";

            if (tree.LeftChild != null)
            {
                result += AsIndentedPreOrder(tree.LeftChild, indent + 2);
            }

            if (tree.RightChild != null)
            {
                result += AsIndentedPreOrder(tree.RightChild, indent + 2);
            }

            return result;
        }

        public List<IAbstractBinaryTree<T>> InOrder()
        {
            return InOrder(this, new List<IAbstractBinaryTree<T>>());
        }

        public List<IAbstractBinaryTree<T>> InOrder(IAbstractBinaryTree<T> tree, List<IAbstractBinaryTree<T>> result)
        {
            if (tree.LeftChild != null)
            {
                InOrder(tree.LeftChild, result);
            }

            result.Add(tree);

            if (tree.RightChild != null)
            {
                InOrder(tree.RightChild, result);
            }

            return result;
        }

        public List<IAbstractBinaryTree<T>> PostOrder()
        {
            return PostOrder(this, new List<IAbstractBinaryTree<T>>());
        }

        public List<IAbstractBinaryTree<T>> PostOrder(IAbstractBinaryTree<T> tree, List<IAbstractBinaryTree<T>> result)
        {
            if (tree.LeftChild != null)
            {
                PostOrder(tree.LeftChild, result);
            }

            if (tree.RightChild != null)
            {
                PostOrder(tree.RightChild, result);
            }

            result.Add(tree);

            return result;
        }

        public List<IAbstractBinaryTree<T>> PreOrder()
        {
            return PreOrder(this, new List<IAbstractBinaryTree<T>>());
        }
        public List<IAbstractBinaryTree<T>> PreOrder(IAbstractBinaryTree<T> tree, List<IAbstractBinaryTree<T>> result)
        {
            result.Add(tree);

            if (tree.LeftChild != null)
            {
                PreOrder(tree.LeftChild, result);
            }

            if (tree.RightChild != null)
            {
                PreOrder(tree.RightChild, result);
            }

            return result;
        }


        public void ForEachInOrder(Action<T> action)
        {
            if (this.LeftChild != null)
            {
                this.LeftChild.ForEachInOrder(action);
            }

            action.Invoke(this.Value);

            if (this.RightChild != null)
            {
                this.RightChild.ForEachInOrder(action);
            }
        }
    }
}
