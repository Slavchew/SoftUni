using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.RoyaleArena
{
    public class Table<TValue> : IEnumerable<TValue>
        where TValue : BattleCard
    {
        private Index<double> index;
        private Dictionary<IComparable, List<TValue>> records;

        public Table(Index<double> index)
        {
            records = new Dictionary<IComparable,List<TValue>>();
            this.index = index;
        }

        public List<TValue> Max
        {
            get
            {
                if (index.Count > 0)
                {
                    return records[index.Max];
                }
                else
                {
                    return new List<TValue>();
                }
            }
        }

        public List<TValue> Min
        {
            get
            {
                if (index.Count > 0)
                {
                    return records[index.Min];
                }
                else
                {
                    return new List<TValue>();
                }
            }
        }

        public double MaxKey => index.Max;

        public double MinKey => index.Min;

        public void Add(TValue item)
        {
            var key = index.GetKey(item);
            if (!records.ContainsKey(key))
            {
                records[key] = new List<TValue>();
            }
            records[key].Add(item);
            index.Add(key);
        }

        public void Remove(TValue item)
        {
            var key = index.GetKey(item);
            if (!records.ContainsKey(key))
            {
                return;
            }
            records[key].Remove(item);
            if (records[key].Count == 0)
            {
                records.Remove(key);
                index.Remove(key);
            }
        }

        public IEnumerable<TValue> GetViewBetween(double min, double max)
        {
            var set = index.GetViewBetween(min, max);
            return set.SelectMany(k => records[k]);
        }

        public IEnumerable<TValue> GetFirstN(int n, Func<TValue, object> orderBy)
        {
            int count = 0;
            foreach (var key in index.Take(n))
            {
                foreach (var item in records[key].OrderBy(orderBy))
                {
                    if (count < n)
                    {
                        yield return item;
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public IEnumerator<TValue> GetEnumerator()
        {
            return records.Values.SelectMany(x => x).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
