namespace _01.Hierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;

    public class Hierarchy<T> : IHierarchy<T>
    {
        private Node<T> root;
        private Dictionary<T, Node<T>> elements = new Dictionary<T, Node<T>>();

        public Hierarchy(T root)
        {
            this.root = CreateNode(root);
        }

        public int Count => elements.Count;

        public void Add(T element, T child)
        {
            ValidateExistence(element);
            if (elements.ContainsKey(child))
            {
                throw new ArgumentException();
            }

            var node = CreateNode(child);
            node.Parent = elements[element];
            elements[element].Children.Add(node);
        }

        private Node<T> CreateNode(T element)
        {
            var node = new Node<T>(element);
            elements[element] = node;
            return node;
        }

        public void Remove(T element)
        {
            if (this.root.Value.Equals(element))
            {
                throw new InvalidOperationException();
            }
            ValidateExistence(element);
            DestroyElement(element);
        }

        private void DestroyElement(T element)
        {
            var node = elements[element];
            node.Parent?.Children.Remove(node);
            if (node.Parent != null && node.Children.Count > 0)
            {
                foreach (var child in node.Children)
                {
                    child.Parent = node.Parent;
                    node.Parent.Children.Add(child);
                }
            }

            elements.Remove(element);
        }

        public IEnumerable<T> GetChildren(T element)
        {
            ValidateExistence(element);
            return elements[element].Children.Select(n => n.Value);
        }

        public T GetParent(T element)
        {
            ValidateExistence(element);
            var node = elements[element];
            if (node.Parent != null)
            {
                return node.Parent.Value;
            }

            return default(T);
        }

        public bool Contains(T element)
        {
            return elements.ContainsKey(element);
        }

        public IEnumerable<T> GetCommonElements(Hierarchy<T> other)
        {
            foreach (var element in elements)
            {
                if (other.Contains(element.Value.Value))
                {
                    yield return element.Value.Value;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var queue = new Queue<Node<T>>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                yield return node.Value;

                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }


        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void ValidateExistence(T element)
        {
            if (!Contains(element))
            {
                throw new ArgumentException();
            }
        }
    }
}