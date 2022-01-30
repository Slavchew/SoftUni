namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;

        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            this.children = new List<Tree<T>>();

            foreach (var child in children)
            {
                this.AddChild(child);
                child.AddParent(this);
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }


        public IReadOnlyCollection<Tree<T>> Children
            => this.children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this.children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string GetAsString()
        {
            return this.GetAsString(0).Trim();
        }

        private string GetAsString(int indentation)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(new string(' ', indentation) + this.Key);

            foreach (var child in this.Children)
            {
                sb.AppendLine(child.GetAsString(indentation + 2));
            }

            return sb.ToString().TrimEnd();
        }

        public Tree<T> GetDeepestLeftomostNode()
        {
            return ReverseBFS();
        }

        public Tree<T> ReverseBFS()
        {
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            Tree<T> node = null;

            while (queue.Count > 0)
            {
                node = queue.Dequeue();

                for (int i = node.children.Count - 1; i >= 0; i--)
                {
                    queue.Enqueue(node.children[i]);
                }
            }

            return node;
        }

        public List<T> GetLeafKeys()
        {
            return this.GetLeafNodes().Select(x => x.Key).ToList();
        }

        private ICollection<Tree<T>> GetLeafNodes()
        {
            var result = new List<Tree<T>>();
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                Tree<T> node = queue.Dequeue();
                if (node.Children.Count == 0)
                {
                    result.Add(node);
                }
                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public List<T> GetMiddleKeys()
        {
            return this.GetMiddleNodes().Select(x => x.Key).ToList();
        }

        private ICollection<Tree<T>> GetMiddleNodes()
        {
            var result = new List<Tree<T>>();
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                Tree<T> node = queue.Dequeue();
                if (node.Children.Count != 0 && node.Parent != null)
                {
                    result.Add(node);
                }
                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public List<T> GetLongestPath()
        {
            Stack<T> result = new Stack<T>();

            var deepestNode = GetDeepestLeftomostNode();

            while (deepestNode != null)
            {
                result.Push(deepestNode.Key);
                deepestNode = deepestNode.Parent;
            }

            return result.ToList();
        }

        public List<List<T>> PathsWithGivenSum(int sum)
        {
            var leafNodes = this.GetLeafNodes();
            var result = new List<List<T>>();

            foreach (var leaf in leafNodes)
            {
                var node = leaf;
                var currentSum = 0;
                var currentNodes = new List<T>();

                while (node != null)
                {
                    currentNodes.Add(node.Key);
                    currentSum += int.Parse(node.Key.ToString());
                    node = node.Parent;
                }

                if (currentSum == sum)
                {
                    currentNodes.Reverse();
                    result.Add(currentNodes);
                }
            }

            return result;
        }

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            var roots = new List<Tree<T>>();

            SubTreeSumDFS(this, sum, roots);

            return roots;
        }

        private int SubTreeSumDFS(Tree<T> node, int targetSum, List<Tree<T>> roots)
        {
            var currentSum = Convert.ToInt32(node.Key);
            foreach (var child in node.Children)
            {
                currentSum += SubTreeSumDFS(child, targetSum, roots);
            }

            if (currentSum == targetSum)
            {
                roots.Add(node);
            }

            return currentSum;
        }
    }
}
