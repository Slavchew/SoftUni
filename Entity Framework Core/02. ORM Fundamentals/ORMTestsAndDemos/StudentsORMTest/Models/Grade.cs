using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsORMTest.Models
{
    public class Grade
    {
        public int Id { get; set; }

        public decimal Value { get; set; }

        public Student Student { get; set; }

        public Course Course { get; set; }
    }
}
