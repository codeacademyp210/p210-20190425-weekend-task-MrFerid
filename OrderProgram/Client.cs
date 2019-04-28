using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProgram
{
    class Client : Person
    {
        public static int ID { get; set; }
        public string Client_ID { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
