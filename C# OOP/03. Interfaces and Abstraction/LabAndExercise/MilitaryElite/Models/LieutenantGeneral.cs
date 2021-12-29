using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Interfaceses;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, ICollection<IPrivate> privates) 
            : base(id, firstName, lastName, salary)
        {
            this.Privates = privates;
        }

        public ICollection<IPrivate> Privates { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{base.ToString()}");
            foreach (var pri in Privates)
            {
                sb.AppendLine(pri.ToString());
            }

            return sb.ToString().Trim();

        }
    }
}
