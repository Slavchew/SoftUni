namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TreeFactory
    {
        private Dictionary<int, Tree<int>> nodesBykeys;

        public TreeFactory()
        {
            this.nodesBykeys = new Dictionary<int, Tree<int>>();
        }

        public Tree<int> CreateTreeFromStrings(string[] input)
        {
            foreach (var line in input)
            {
                var lineArgs = line.Split().Select(int.Parse).ToArray();

                var parentNodeKey = lineArgs[0];
                var childNodeKey = lineArgs[1];

                this.CreateNodeByKey(parentNodeKey);
                this.CreateNodeByKey(childNodeKey);

                this.AddEdge(parentNodeKey, childNodeKey);
            }

            return this.GetRoot();
        }

        public Tree<int> CreateNodeByKey(int key)
        {
            Tree<int> node = null;
            if (!this.nodesBykeys.ContainsKey(key))
            {
                node = new Tree<int>(key);
                this.nodesBykeys.Add(key, node);
            }

            return node;
        }

        public void AddEdge(int parent, int child)
        {
            this.nodesBykeys[parent].AddChild(this.nodesBykeys[child]);
            this.nodesBykeys[child].AddParent(this.nodesBykeys[parent]);
        }

        private Tree<int> GetRoot()
        {
            var node = this.nodesBykeys.FirstOrDefault().Value;

            while (node.Parent != null)
            {
                node = node.Parent;
            }

            return node;
        }
    }
}
