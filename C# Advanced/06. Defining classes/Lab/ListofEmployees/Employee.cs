using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListofEmployees
{
    class Employee
    {
        private string name;
        private decimal salary;
        private string position;
        private string section;
        private string mail;
        private int age;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public decimal Salary
        {
            get { return this.salary; }
            set { this.salary = value; }
        }
        public string Position
        {
            get { return this.position; }
            set { this.position = value; }
        }
        public string Section
        {
            get { return this.section; }
            set { this.section = value; }
        }
        public string Mail
        {
            get { return this.mail; }
            set { this.mail = value; }
        }
        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

    }
}
