 namespace _02.Data
{
    using _02.Data.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Data : IRepository
    {
        private PriorityQueue<IEntity> queue;
        private Dictionary<int, IEntity> dictionary;

        private Dictionary<int, List<IEntity>> parents;

        public Data()
        {
            this.queue = new PriorityQueue<IEntity>();
            this.dictionary = new Dictionary<int,IEntity>();
            this.parents = new Dictionary<int,List<IEntity>>();
        }
        public Data(PriorityQueue<IEntity> queue, 
            Dictionary<int, IEntity> dictionary, 
            Dictionary<int, List<IEntity>> parents)
        {
            this.queue = queue;
            this.dictionary = dictionary;
            this.parents = parents;
        }

        public int Size => queue.Size;

        public void Add(IEntity entity)
        {
            queue.Add(entity);
            dictionary.Add(entity.Id, entity);


            if (entity != null)
            {
                if (!parents.ContainsKey(entity.ParentId.Value))
                {
                    parents[entity.ParentId.Value] = new List<IEntity>();
                }

                parents[entity.ParentId.Value].Add(entity);
            }
        }

        public IRepository Copy()
        {
            return new Data(queue, dictionary, parents);
        }

        public IEntity DequeueMostRecent()
        {
            if (queue.Size == 0)
            {
                throw new InvalidOperationException("Operation on empty Data");
            }

            var element = queue.Dequeue();
            dictionary.Remove(element.Id);

            return element;
        }

        public List<IEntity> GetAll()
        {
            return new List<IEntity>(queue.GetAsList);
        }

        public List<IEntity> GetAllByType(string type)
        {
            if (!(type == "User" || type == "StoreClient" || type == "Invoice"))
            {
                throw new InvalidOperationException("Invalid type: " + type);
            }

            return queue.GetAsList.Where(x => x.GetType().Name == type).ToList();
        }

        public IEntity GetById(int id)
        {
            // O(n)
            // return queue.GetAsList.Find(x => x.Id == id);

            // O(1)
            if (!dictionary.ContainsKey(id))
            {
                return null;
            }
            return dictionary[id];
        }

        public List<IEntity> GetByParentId(int parentId)
        {
            if (!parents.ContainsKey(parentId))
            {
                return new List<IEntity>();
            }

            return parents[parentId];
        }

        public IEntity PeekMostRecent()
        {
            if (queue.Size == 0)
            {
                throw new InvalidOperationException("Operation on empty Data");
            }
            return queue.Peek();
        }
    }
}
