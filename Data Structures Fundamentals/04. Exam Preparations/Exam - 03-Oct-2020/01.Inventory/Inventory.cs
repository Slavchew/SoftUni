namespace _01.Inventory
{
    using _01.Inventory.Interfaces;
    using _01.Inventory.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Inventory : IHolder
    {
        private List<IWeapon> weapons;

        public Inventory()
        {
            this.weapons = new List<IWeapon>();
        }
        public int Capacity => weapons.Count;

        public void Add(IWeapon weapon)
        {
            weapons.Add(weapon);
        }

        public void Clear()
        {
            weapons.Clear();
        }

        public bool Contains(IWeapon weapon)
        {
            return weapons.Contains(weapon);
        }

        public void EmptyArsenal(Category category)
        {
            foreach (var weapon in weapons)
            {
                if (weapon.Category == category)
                {
                    weapon.Ammunition = 0;
                }
            }
        }

        public bool Fire(IWeapon weapon, int ammunition)
        {
            var weaponToFire = weapons.IndexOf(weapon);

            ValidateIndex(weaponToFire);

            if (weapons[weaponToFire].Ammunition >= ammunition)
            {
                weapons[weaponToFire].Ammunition -= ammunition;
                return true;
            }

            return false;
        }

        public IWeapon GetById(int id)
        {
            return weapons.Find(x => x.Id == id);
        }

        public IEnumerator GetEnumerator()
        {
            return this.weapons.GetEnumerator();
        }

        public int Refill(IWeapon weapon, int ammunition)
        {
            var weaponToRefillIndex = weapons.IndexOf(weapon);

            ValidateIndex(weaponToRefillIndex);

            weapons[weaponToRefillIndex].Ammunition += ammunition;

            if (weapons[weaponToRefillIndex].Ammunition > weapons[weaponToRefillIndex].MaxCapacity)
            {
                weapons[weaponToRefillIndex].Ammunition = weapons[weaponToRefillIndex].MaxCapacity;
            }

            return weapons[weaponToRefillIndex].Ammunition;
        }

        public IWeapon RemoveById(int id)
        {
            var weapon = weapons.Find(x => x.Id == id);

            if (weapon == null)
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            }
            weapons.Remove(weapon);

            return weapon;
        }

        public int RemoveHeavy()
        {
            return weapons.RemoveAll(x => x.Category == Category.Heavy);
        }

        public List<IWeapon> RetrieveAll()
        {
            return weapons;
        }

        public List<IWeapon> RetriveInRange(Category lower, Category upper)
        {
            var result = new List<IWeapon>();
            foreach (var weapon in weapons)
            {
                if (weapon.Category >= lower && weapon.Category <= upper)
                {
                    result.Add(weapon);
                }
            }

            return result;
        }

        public void Swap(IWeapon firstWeapon, IWeapon secondWeapon)
        {
            var firstWeaponIndex = weapons.IndexOf(firstWeapon);
            ValidateIndex(firstWeaponIndex);
            var secondWeaponIndex = weapons.IndexOf(secondWeapon);
            ValidateIndex(secondWeaponIndex);

            if (weapons[firstWeaponIndex].Category == weapons[secondWeaponIndex].Category)
            {
                var temp = weapons[firstWeaponIndex];
                weapons[firstWeaponIndex] = weapons[secondWeaponIndex];
                weapons[secondWeaponIndex] = temp;
            }
        }

        private void ValidateIndex(int index)
        {
            if (index == -1)
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            }
        }

    }
}
