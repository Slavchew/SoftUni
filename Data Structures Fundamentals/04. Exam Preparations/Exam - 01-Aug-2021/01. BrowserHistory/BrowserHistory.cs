namespace _01._BrowserHistory
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using _01._BrowserHistory.Interfaces;

    public class BrowserHistory : IHistory
    {
        // private DoublyLinkedList<ILink> history;
        private List<ILink> list;

        public BrowserHistory()
        {
            // this.history = new DoublyLinkedList<ILink>();
            this.list = new List<ILink>();
        }

        public int Size => list.Count;

        public void Clear()
        {
            list.Clear();
        }

        public bool Contains(ILink link)
        {
            return list.Contains(link);
        }

        public ILink DeleteFirst()
        {
            ValidateIfEmpty();

            var firstLink = list[0];
            list.RemoveAt(0);
            return firstLink;
            // return history.RemoveLast();
        }

        public ILink DeleteLast()
        {
            ValidateIfEmpty();
            var lastLink = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return lastLink;
            // return history.RemoveFirst();
        }

        public ILink GetByUrl(string url)
        {
            return list.Find(x => x.Url == url);
        }

        public ILink LastVisited()
        {
            ValidateIfEmpty();
            return list[list.Count - 1];
            // return history.GetFirst();
        }

        public void Open(ILink link)
        {
            // history.AddFirst(link);
            list.Add(link);
        }

        public int RemoveLinks(string url)
        {
            var count = list.RemoveAll(x => x.Url.Contains(url));
            if (count == 0)
            {
                throw new InvalidOperationException();
            }

            return count;
        }

        public ILink[] ToArray()
        {
            list.Reverse();
            return list.ToArray();
        }

        public List<ILink> ToList()
        {
            list.Reverse();
            return list;
        }

        public string ViewHistory()
        {
            if (list.Count == 0)
            {
                return "Browser history is empty!";
            }

            list.Reverse();
            StringBuilder result = new StringBuilder();
            foreach (ILink link in list)
            {
                result.Append(link.ToString() + "\r\n");
            }

            return result.ToString();
        }

        private void ValidateIfEmpty()
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
