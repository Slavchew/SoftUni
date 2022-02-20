namespace _01.RoyaleArena
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class RoyaleArena : IArena
    {
        private Dictionary<int, BattleCard> deck = new Dictionary<int, BattleCard>();

        private Dictionary<CardType, Table<BattleCard>> cardTypeSortedByDamage = 
            new Dictionary<CardType, Table<BattleCard>>();

        private Dictionary<string, Table<BattleCard>> nameSortedBySwag = 
            new Dictionary<string, Table<BattleCard>>();

        private Table<BattleCard> sortBySwag = new Table<BattleCard>(new SwagIndex());

        public void Add(BattleCard card)
        {
            if (deck.ContainsKey(card.Id))
            {
                throw new InvalidOperationException();
            }
            deck[card.Id] = card;
            AddToSearchableCollection<DamageIndex>(cardTypeSortedByDamage, card, (c) => c.Type);
            AddToSearchableCollection<SwagIndex>(nameSortedBySwag, card, (c) => c.Name);
            sortBySwag.Add(card);
        }

        private void AddToSearchableCollection<T>(IDictionary dict, 
            BattleCard card, Func<BattleCard, object> getKey)
            where T : Index<double>, new()
        {
            var key = getKey(card);
            if (dict[key] == null)
            {
                dict[key] = new Table<BattleCard>(new T());
            }
            (dict[key] as Table<BattleCard>).Add(card);
        }

        public bool Contains(BattleCard card)
        {
            return deck.ContainsKey(card.Id);
        }

        public int Count { get => deck.Keys.Count; }

        public void ChangeCardType(int id, CardType type)
        {
            if (!deck.ContainsKey(id))
            {
                throw new InvalidOperationException();
            }

            RemoveFromSearchableCollection(cardTypeSortedByDamage, deck[id], (c) => c.Damage);
            deck[id].Type = type;

            AddToSearchableCollection<DamageIndex>(cardTypeSortedByDamage, deck[id], (c) => c.Type);
        }

        private void RemoveFromSearchableCollection(IDictionary dict,
            BattleCard card, Func<BattleCard, object> getKey)
        {
            var key = getKey(card);
            if (dict[key] != null)
            {
                var items = (dict[key] as Table<BattleCard>);
                items.Remove(card);
                if (items.Count() == 0)
                {
                    dict.Remove(key);
                }
            }
        }

        public BattleCard GetById(int id)
        {
            if (!deck.ContainsKey(id))
            {
                throw new InvalidOperationException();
            }
            return deck[id];
        }

        public void RemoveById(int id)
        {
            if (!deck.ContainsKey(id))
            {
                throw new InvalidOperationException();
            }
            RemoveFromSearchableCollection(cardTypeSortedByDamage, deck[id], (c) => c.Type);
            RemoveFromSearchableCollection(nameSortedBySwag, deck[id], (c) => c.Name);
            sortBySwag.Remove(deck[id]);
            deck.Remove(id);
        }

        public IEnumerable<BattleCard> GetByCardType(CardType type)
        {
            if (!cardTypeSortedByDamage.ContainsKey(type))
            {
                throw new InvalidOperationException();
            }
            return cardTypeSortedByDamage[type];
        }

        public IEnumerable<BattleCard> GetByTypeAndDamageRangeOrderedByDamageThenById(CardType type, int lo, int hi)
        {
            if (!cardTypeSortedByDamage.ContainsKey(type))
            {
                throw new InvalidOperationException();
            }
            return cardTypeSortedByDamage[type]?.GetViewBetween(lo, hi)
                .OrderBy(c => c);
        }

        public IEnumerable<BattleCard> GetByCardTypeAndMaximumDamage(CardType type, double damage)
        {
            if (!cardTypeSortedByDamage.ContainsKey(type))
            {
                throw new InvalidOperationException();
            }
            return cardTypeSortedByDamage[type]?
                .GetViewBetween(cardTypeSortedByDamage[type].MinKey, damage)
                .OrderBy(c => c);
        }

        public IEnumerable<BattleCard> GetByNameOrderedBySwagDescending(string name)
        {
            if (!nameSortedBySwag.ContainsKey(name))
            {
                throw new InvalidOperationException();
            }
            return nameSortedBySwag[name].Reverse();
        }

        public IEnumerable<BattleCard> GetByNameAndSwagRange(string name, double lo, double hi)
        {
            if (!nameSortedBySwag.ContainsKey(name))
            {
                throw new InvalidOperationException();
            }
            return nameSortedBySwag[name]?.GetViewBetween(lo, hi);
        }

        public IEnumerable<BattleCard> FindFirstLeastSwag(int n)
        {
            if (n > Count)
            {
                throw new InvalidOperationException();
            }
            return sortBySwag.GetFirstN(n, c => c.Id);
        }

        public IEnumerable<BattleCard> GetAllInSwagRange(double lo, double hi)
        {
            return sortBySwag.GetViewBetween(lo, hi);
        }


        public IEnumerator<BattleCard> GetEnumerator()
        {
            return deck.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}