namespace _02.DOM
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using _02.DOM.Interfaces;
    using _02.DOM.Models;

    public class DocumentObjectModel : IDocument
    {
        public DocumentObjectModel(IHtmlElement root)
        {
            this.Root = root;
        }

        public DocumentObjectModel()
        {
            this.Root = new HtmlElement(ElementType.Document,
                new IHtmlElement[]
                {
                    new HtmlElement(ElementType.Html, new IHtmlElement[]
                    {
                        new HtmlElement(ElementType.Head, null),
                        new HtmlElement(ElementType.Body, null),
                    })
                });
        }

        public IHtmlElement Root { get; private set; }

        public IHtmlElement GetElementByType(ElementType type)
        {
            return BFSType(this.Root, type);
        }

        public List<IHtmlElement> GetElementsByType(ElementType type)
        {
            var result = new List<IHtmlElement>();

            this.GetElementsByTypeDFS(this.Root, type, result);

            return result;
        }

        public void GetElementsByTypeDFS(IHtmlElement node, ElementType type, List<IHtmlElement> result)
        {
            foreach (var child in node.Children)
            {
                GetElementsByTypeDFS(child, type, result);
            }

            if (node.Type == type)
            {
                result.Add(node);
            }
        }

        public bool Contains(IHtmlElement htmlElement)
        {
            /* BFS Solution
            var node = BFS(this.Root, htmlElement);
            if (node == null)
            {
                return false;
            }
            return true;
            */
            var isExist = false;
            DFS(this.Root, htmlElement, ref isExist);

            return isExist;
        }

        public void DFS(IHtmlElement tree, IHtmlElement node, ref bool isExist)
        {
            if (tree == node)
            {
                isExist = true;
                return;
            }

            foreach (var child in tree.Children)
            {
                DFS(child, node, ref isExist);
                if (isExist)
                {
                    return;
                }
            }
        }

        public IHtmlElement BFSType(IHtmlElement tree, ElementType type)
        {
            Queue<IHtmlElement> queue = new Queue<IHtmlElement>();
            queue.Enqueue(tree);

            while (queue.Count > 0)
            {
                IHtmlElement node = queue.Dequeue();
                if (node.Type == type)
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

        public void InsertFirst(IHtmlElement parent, IHtmlElement child)
        {
            var isDone = InsertFistBFS(this.Root, parent, child);
            if (!isDone)
            {
                throw new InvalidOperationException();
            }
        }

        public bool InsertFistBFS(IHtmlElement tree, IHtmlElement parent, IHtmlElement child)
        {
            Queue<IHtmlElement> queue = new Queue<IHtmlElement>();
            queue.Enqueue(tree);

            while (queue.Count > 0)
            {
                IHtmlElement node = queue.Dequeue();
                if (node == parent)
                {
                    child.Parent = parent;
                    node.Children.Insert(0, child);
                    return true;
                }
                foreach (var nodeChild in node.Children)
                {
                    queue.Enqueue(nodeChild);
                }
            }

            return false;
        }

        public void InsertLast(IHtmlElement parent, IHtmlElement child)
        {
            var isDone = InsertLastBFS(this.Root, parent, child);
            if (!isDone)
            {
                throw new InvalidOperationException();
            }
        }

        public bool InsertLastBFS(IHtmlElement tree, IHtmlElement parent, IHtmlElement child)
        {
            Queue<IHtmlElement> queue = new Queue<IHtmlElement>();
            queue.Enqueue(tree);

            while (queue.Count > 0)
            {
                IHtmlElement node = queue.Dequeue();
                if (node == parent)
                {
                    child.Parent = parent;
                    node.Children.Add(child);
                    return true;
                }
                foreach (var nodeChild in node.Children)
                {
                    queue.Enqueue(nodeChild);
                }
            }

            return false;
        }

        public void Remove(IHtmlElement htmlElement)
        {
            var isRemoved = RemoveElementBFS(this.Root, htmlElement);
            if (!isRemoved)
            {
                throw new InvalidOperationException();
            }
        }

        public bool RemoveElementBFS(IHtmlElement tree, IHtmlElement htmlElement)
        {
            Queue<IHtmlElement> queue = new Queue<IHtmlElement>();
            queue.Enqueue(tree);

            while (queue.Count > 0)
            {
                IHtmlElement node = queue.Dequeue();
                foreach (var child in node.Children)
                {
                    if (child == htmlElement)
                    {
                        node.Children.Remove(child);
                        child.Parent = null;
                        child.Children.Clear();
                        return true;
                    }
                    queue.Enqueue(child);
                }
            }

            return false;
        }

        public void RemoveAll(ElementType elementType)
        {
            RemoveAllElementBFS(this.Root, elementType);
        }

        public void RemoveAllElementBFS(IHtmlElement tree, ElementType elementType)
        {
            Queue<IHtmlElement> queue = new Queue<IHtmlElement>();
            queue.Enqueue(tree);

            while (queue.Count > 0)
            {
                IHtmlElement node = queue.Dequeue();
                for (int i = 0; i < node.Children.Count; i++)
                {
                    var child = node.Children[i];
                    if (child.Type == elementType)
                    {
                        node.Children.RemoveAt(i);
                        child.Parent = null;
                        child.Children.Clear();
                        i--;
                    }
                    else
                    {
                        queue.Enqueue(child);
                    }
                }
            }
        }

        public bool AddAttribute(string attrKey, string attrValue, IHtmlElement htmlElement)
        {
            var temp = AddAttributeBFS(this.Root, htmlElement, attrKey, attrValue);

            if (temp < 0)
            {
                throw new InvalidOperationException();
            }
            else if (temp > 0)
            {
                return true;
            }

            return false;
        }

        public int AddAttributeBFS(IHtmlElement tree, IHtmlElement htmlElement, string attrKey, string attrValue)
        {
            Queue<IHtmlElement> queue = new Queue<IHtmlElement>();
            queue.Enqueue(tree);

            while (queue.Count > 0)
            {
                IHtmlElement node = queue.Dequeue();
                if (node == htmlElement)
                {
                    if (htmlElement.Attributes.ContainsKey(attrKey))
                    {
                        return 0;
                    }
                    else
                    {
                        htmlElement.Attributes[attrKey] = attrValue;
                        return 1;
                    }
                }
                foreach (var nodeChild in node.Children)
                {
                    queue.Enqueue(nodeChild);
                }
            }

            return -1;
        }

        public bool RemoveAttribute(string attrKey, IHtmlElement htmlElement)
        {
            var temp = RemoveAttributeBFS(this.Root, htmlElement, attrKey);

            if (temp < 0)
            {
                throw new InvalidOperationException();
            }
            else if (temp > 0)
            {
                return true;
            }

            return false;
        }

        public int RemoveAttributeBFS(IHtmlElement tree, IHtmlElement htmlElement, string attrKey)
        {
            Queue<IHtmlElement> queue = new Queue<IHtmlElement>();
            queue.Enqueue(tree);

            while (queue.Count > 0)
            {
                IHtmlElement node = queue.Dequeue();
                if (node == htmlElement)
                {
                    if (htmlElement.Attributes.ContainsKey(attrKey))
                    {
                        htmlElement.Attributes.Remove(attrKey);
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                foreach (var nodeChild in node.Children)
                {
                    queue.Enqueue(nodeChild);
                }
            }

            return -1;
        }

        public IHtmlElement GetElementById(string idValue)
        {
            return GetElementByIdBFS(this.Root, idValue);
        }

        public IHtmlElement GetElementByIdBFS(IHtmlElement tree, string idValue)
        {
            Queue<IHtmlElement> queue = new Queue<IHtmlElement>();
            queue.Enqueue(tree);

            while (queue.Count > 0)
            {
                IHtmlElement node = queue.Dequeue();
                if (node.Attributes.ContainsKey("id"))
                {
                    if (node.Attributes["id"] == idValue)
                    {
                        return node;
                    }
                }
                foreach (var nodeChild in node.Children)
                {
                    queue.Enqueue(nodeChild);
                }
            }

            return null;
        }

        public string ToStringBFS(IHtmlElement tree)
        {
            StringBuilder result = new StringBuilder();
            Queue<IHtmlElement> queue = new Queue<IHtmlElement>();
            queue.Enqueue(tree);
            int indent = 0;

            result.AppendLine($"{new string(' ', indent)}{tree.Type}");

            while (queue.Count > 0)
            {
                IHtmlElement node = queue.Dequeue();
                foreach (var nodeChild in node.Children)
                {
                    indent = 0;
                    var child = nodeChild;
                    while (child.Parent != null)
                    {
                        indent += 2;
                        child = child.Parent;
                    }
                    queue.Enqueue(nodeChild);
                    result.AppendLine($"{new string(' ', indent)}{nodeChild.Type}");
                }
            }

            return result.ToString();
        }

        public override string ToString()
        {
            return ToStringBFS(this.Root);
        }
    }
}
