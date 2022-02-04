namespace _02.LegionSystem
{
    using System;
    using System.Collections.Generic;
    using _02.LegionSystem.Interfaces;

    public class Legion : IArmy
    {
        public int Size => throw new NotImplementedException();

        public bool Contains(IEnemy enemy)
        {
            throw new NotImplementedException();
        }

        public void Create(IEnemy enemy)
        {
            throw new NotImplementedException();
        }

        public IEnemy GetByAttackSpeed(int speed)
        {
            throw new NotImplementedException();
        }

        public List<IEnemy> GetFaster(int speed)
        {
            throw new NotImplementedException();
        }

        public IEnemy GetFastest()
        {
            throw new NotImplementedException();
        }

        public IEnemy[] GetOrderedByHealth()
        {
            throw new NotImplementedException();
        }

        public List<IEnemy> GetSlower(int speed)
        {
            throw new NotImplementedException();
        }

        public IEnemy GetSlowest()
        {
            throw new NotImplementedException();
        }

        public void ShootFastest()
        {
            throw new NotImplementedException();
        }

        public void ShootSlowest()
        {
            throw new NotImplementedException();
        }
    }
}
