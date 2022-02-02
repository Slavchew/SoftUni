namespace _01.Loader
{
    using _01.Loader.Interfaces;
    using _01.Loader.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Loader : IBuffer
    {
        private List<IEntity> entities;

        public Loader()
        {
            this.entities = new List<IEntity>();
        }

        public int EntitiesCount => entities.Count;

        // O(1)
        public void Add(IEntity entity)
        {
            entities.Add(entity);
        }

        // O(n)
        public void Clear()
        {
            entities.Clear();
        }

        // O(1) O(logn)
        // O(n)
        public bool Contains(IEntity entity)
        {
            return entities.Contains(entity);
        }

        // O(1) O(logn)
        // O(n)
        public IEntity Extract(int id)
        {
            var entity = FindById(id);
            if (entity != null)
            {
                entities.Remove(entity);
            }
            return entity;
        }

        // O(1) O(logn) O(n)
        public IEntity Find(IEntity entity)
        {
            return FindByEntity(entity);
        }

        // O(n)
        public List<IEntity> GetAll()
        {
            return new List<IEntity>(entities);
        }

        // O(1)
        public IEnumerator<IEntity> GetEnumerator()
        {
            return entities.GetEnumerator();
        }

        // O(n)
        public void RemoveSold()
        {
            List<IEntity> withoutSold = new List<IEntity>();
            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i].Status != BaseEntityStatus.Sold)
                {
                    withoutSold.Add(entities[i]);
                }
            }

            entities = withoutSold;
        }

        // O(n) O(logn) O(1)
        public void Replace(IEntity oldEntity, IEntity newEntity)
        {
            int oldIndex = entities.IndexOf(oldEntity);
            this.ValidateIndex(oldIndex, "Entity not found");

            entities[oldIndex] = newEntity;
        }
        // O(n)
        public List<IEntity> RetainAllFromTo(BaseEntityStatus lowerBound, BaseEntityStatus upperBound)
        {
            List<IEntity> inBounds = new List<IEntity>();
            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i].Status >= lowerBound &&
                    entities[i].Status <= upperBound)
                {
                    inBounds.Add(entities[i]);
                }
            }

            return inBounds;
        }

        // O(n) O(logn)
        public void Swap(IEntity first, IEntity second)
        {
            int firstElementIndex = entities.IndexOf(first);
            this.ValidateIndex(firstElementIndex, "Entity not found");

            int secondElementIndex = entities.IndexOf(second);
            this.ValidateIndex(secondElementIndex, "Entity not found");

            IEntity temp = entities[firstElementIndex];
            entities[firstElementIndex] = entities[secondElementIndex];
            entities[secondElementIndex] = temp;
        }

        // O(n)
        public IEntity[] ToArray()
        {
            return entities.ToArray();
        }

        // O(n)
        public void UpdateAll(BaseEntityStatus oldStatus, BaseEntityStatus newStatus)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i].Status == oldStatus)
                {
                    entities[i].Status = newStatus;
                }
            }
        }

        // O(1)
        IEnumerator IEnumerable.GetEnumerator()
        {
            return entities.GetEnumerator();
        }

        private IEntity FindById(int id)
        {
            IEntity entity = null;
            for (int i = 0; i < this.entities.Count; i++)
            {
                if (entities[i].Id == id)
                {
                    entity = entities[i];
                }
            }

            return entity;
        }

        private IEntity FindByEntity(IEntity entity)
        {
            int index = entities.IndexOf(entity);
            if (index >= 0)
            {
                return entities[index];
            }

            return null;
        }

        private void ValidateIndex(int index, string message)
        {
            if (index < 0)
            {
                throw new  InvalidOperationException(message);
            }
        }
    }
}
