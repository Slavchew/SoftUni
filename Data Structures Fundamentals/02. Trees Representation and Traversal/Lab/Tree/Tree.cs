namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;

        public Tree(T value)
        {
            this.Value = value;
            this.Parent = null;
            this.children = new List<Tree<T>>();
            this.IsRootDeleted = false;
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.Parent = this;
                this.children.Add(child);
            }
        }

        public T Value { get; private set; }
        public Tree<T> Parent { get; private set; }
        public IReadOnlyCollection<Tree<T>> Children => this.children.AsReadOnly();

        public bool IsRootDeleted { get; private set; }

        public ICollection<T> OrderBfs()
        {
            var result = new List<T>();
            Queue<Tree<T>> queue = new Queue<Tree<T>>();

            if (this.IsRootDeleted == true)
            {
                return result;
            }

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                Tree<T> node = queue.Dequeue();
                result.Add(node.Value);
                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public ICollection<T> OrderDfs()
        {
            var result = new List<T>();

            this.DFS(this, result);

            return result;
        }

        public void DFS(Tree<T> tree, List<T> result)
        {
            foreach (var child in tree.Children)
            {
                DFS(child, result);
            }

            result.Add(tree.Value);
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            var searchedNode = FindBfs(parentKey);

            CheckEmptyNode(searchedNode);

            searchedNode.children.Add(child);
        }

        public void RemoveNode(T nodeKey)
        {
            var searchedNode = FindBfs(nodeKey);
            CheckEmptyNode(searchedNode);

            foreach (var child in searchedNode.children)
            {
                child.Parent = null;
            }

            searchedNode.children.Clear();

            Tree<T> searchedParent = searchedNode.Parent;

            if (searchedParent == null)
            {
                this.IsRootDeleted = true;
            }
            else
            {
                searchedParent.children.Remove(searchedNode);
            }

            searchedNode.Value = default(T);
        }

        public void Swap(T firstKey, T secondKey)
        {
            Tree<T> firstNode = FindBfs(firstKey);
            Tree<T> secondNode = FindBfs(secondKey);
            CheckEmptyNode(firstNode);
            CheckEmptyNode(secondNode);

            Tree<T> firstParent = firstNode.Parent;
            Tree<T> secondParent = secondNode.Parent;

            if (firstParent == null)
            {
                SwapRoot(secondNode);
                return;
            }
            
            if (secondParent == null)
            {
                SwapRoot(firstNode);
                return;
            }

            firstNode.Parent = secondParent;
            secondNode.Parent = firstParent;

            int indexOfFirst = firstParent.children.IndexOf(firstNode);
            int indexOfSecond = secondParent.children.IndexOf(secondNode);

            firstParent.children[indexOfFirst] = secondNode;
            secondParent.children[indexOfSecond] = firstNode;
        }

        private void SwapRoot(Tree<T> subtree)
        {
            this.Value = subtree.Value;
            this.children.Clear();
            foreach (var child in subtree.children)
            {
                this.children.Add(child);
            }
        }

        public Tree<T> FindBfs(T parentKey)
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                Tree<T> node = queue.Dequeue();
                if (node.Value.Equals(parentKey))
                {
                    return node;
                }
                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        public void CheckEmptyNode(Tree<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }
        }

        private ICollection<T> DfsWithStack()
        {
            var result = new Stack<T>();
            var toTraverse = new Stack<Tree<T>>();

            toTraverse.Push(this);
            while (toTraverse.Count != 0)
            {
                var current = toTraverse.Pop();

                foreach (var child in current.Children)
                {
                    toTraverse.Push(child);
                }

                result.Push(current.Value);
            }

            return new List<T>(result);
        }
    }
}
