using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public abstract class Game
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public abstract string GetDiscription();

        public virtual void Start()
        {
            StartDate = DateTime.Now;
        }

        public virtual void Stop()
        {
            EndDate = DateTime.Now;
        }
    }
}
