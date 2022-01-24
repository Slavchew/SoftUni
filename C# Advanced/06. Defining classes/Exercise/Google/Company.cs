using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    public class Company
    {
        public Company(string companyName, string companySection, decimal salary)
        {
            CompanyName = companyName;
            CompanySection = companySection;
            Salary = salary;
        }

        public string CompanyName { get; set; }
        public string CompanySection { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"{this.CompanyName} {this.CompanySection} {this.Salary:F2}";
        }
    }
}
