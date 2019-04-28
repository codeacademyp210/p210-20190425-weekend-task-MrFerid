using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProgram
{
    class Order : Product
    {
        public static int ID { get; set; }
        public Client client { get; set; }
        public Product product { get; set; }
        public int Count { get; set; }
      
        
    }
}
