using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProgram
{
    class Employee : Person
    {
        
        public string Position { get; set; }
        public int Salary { get; set; }

        public static int ID { get; set; }

        public int getAge()
        {
           // taking first 4 carachter for year
           int year = Convert.ToInt32( Birthday.Substring(0,4) );
           return DateTime.Now.Year - year;
        }

    }
}
