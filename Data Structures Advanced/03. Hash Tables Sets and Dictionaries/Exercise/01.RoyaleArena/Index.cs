using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _01.RoyaleArena
{
    public abstract class Index<TKey> : IComparer<BattleCard>, IEnumerable<TKey>
        where TKey : IComparable<TKey>
    {
        public abstract Func<BattleCard, TKey> GetKey { get; }

        protected abstract SortedSet<TKey> Keys { get; }

        public TKey Min => Keys.Min;

        public TKey Max => Keys.Max;

        public int Count => Keys.Count;

        public void Add(TKey key)
        {
            Keys.Add(key);
        }

        public void Remove(TKey key)
        {
            Keys.Remove(key);
        }

        public IEnumerable<TKey> GetViewBetween(TKey min, TKey max)
        {
            return Keys.GetViewBetween(min, max);
        }

        public virtual int Compare(BattleCard x, BattleCard y)
        {
            return GetKey(x).CompareTo(GetKey(y));
        }

        public IEnumerator<TKey> GetEnumerator()
        {
            return Keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class SwagIndex : Index<double>
    {
        private SortedSet<double> keys = new SortedSet<double>();

        public override Func<BattleCard, double> GetKey => (card) => card.Swag;

        protected override SortedSet<double> Keys => keys;
    }

    public class DamageIndex : Index<double>
    {
        private SortedSet<double> keys = new SortedSet<double>();

        public override Func<BattleCard, double> GetKey => (card) => card.Damage;

        protected override SortedSet<double> Keys => keys;

        public override int Compare(BattleCard x, BattleCard y)
        {
            int compare = base.Compare(x, y);

            if (compare == 0)
            {
                compare = x.Id.CompareTo(y.Id);
            }

            return compare;
        }
    }
}
