namespace _01.Inventory
{
    using _01.Inventory.Interfaces;
    using _01.Inventory.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Inventory : IHolder
    {
        public int Capacity => throw new NotImplementedException();

        public void Add(IWeapon weapon)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(IWeapon weapon)
        {
            throw new NotImplementedException();
        }

        public void EmptyArsenal(Category category)
        {
            throw new NotImplementedException();
        }

        public bool Fire(IWeapon weapon, int ammunition)
        {
            throw new NotImplementedException();
        }

        public IWeapon GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int Refill(IWeapon weapon, int ammunition)
        {
            throw new NotImplementedException();
        }

        public IWeapon RemoveById(int id)
        {
            throw new NotImplementedException();
        }

        public int RemoveHeavy()
        {
            throw new NotImplementedException();
        }

        public List<IWeapon> RetrieveAll()
        {
            throw new NotImplementedException();
        }

        public List<IWeapon> RetriveInRange(Category lower, Category upper)
        {
            throw new NotImplementedException();
        }

        public void Swap(IWeapon firstWeapon, IWeapon secondWeapon)
        {
            throw new NotImplementedException();
        }
    }
}
