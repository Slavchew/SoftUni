namespace _02.LegionSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _02.LegionSystem.Interfaces;

    public class Legion : IArmy
    {
        private SortedDictionary<int , IEnemy> dictionary;

        public Legion()
        {
            this.dictionary = new SortedDictionary<int, IEnemy>();
        }

        public int Size => dictionary.Count;

        public bool Contains(IEnemy enemy)
        {
            return dictionary.ContainsKey(enemy.AttackSpeed);
        }

        public void Create(IEnemy enemy)
        {
            if (!dictionary.ContainsKey(enemy.AttackSpeed))
            {
                dictionary[enemy.AttackSpeed] = enemy;
            }
        }

        public IEnemy GetByAttackSpeed(int speed)
        {
            if (!dictionary.ContainsKey(speed))
            {
                return null;
            }

            return dictionary[speed];
        }

        public List<IEnemy> GetFaster(int speed)
        {
            var result = new List<IEnemy>();

            foreach (var enemy in dictionary)
            {
                if (enemy.Key > speed)
                {
                    result.Add(enemy.Value);
                }
            }

            return result;
        }

        public IEnemy GetFastest()
        {
            if (dictionary.Count == 0)
            {
                throw new InvalidOperationException("Legion has no enemies!");
            }

            var enemy = dictionary.Last().Value;

            return enemy;
        }

        public IEnemy[] GetOrderedByHealth()
        {
            var result = new List<IEnemy>();

            foreach (var enemy in dictionary.OrderByDescending(x => x.Value.Health))
            {
                result.Add(enemy.Value);
            }

            return result.ToArray();
        }

        public List<IEnemy> GetSlower(int speed)
        {
            var result = new List<IEnemy>();

            foreach (var enemy in dictionary)
            {
                if (enemy.Key < speed)
                {
                    result.Add(enemy.Value);
                }
            }

            return result;
        }

        public IEnemy GetSlowest()
        {
            if (dictionary.Count == 0)
            {
                throw new InvalidOperationException("Legion has no enemies!");
            }

            var enemy = dictionary.First().Value;

            return enemy;
        }

        public void ShootFastest()
        {
            if (dictionary.Count == 0)
            {
                throw new InvalidOperationException("Legion has no enemies!");
            }

            var enemy = dictionary.Last().Value;

            dictionary.Remove(enemy.AttackSpeed);
        }

        public void ShootSlowest()
        {
            if (dictionary.Count == 0)
            {
                throw new InvalidOperationException("Legion has no enemies!");
            }

            var enemy = dictionary.First().Value;

            dictionary.Remove(enemy.AttackSpeed);
        }
    }
}
