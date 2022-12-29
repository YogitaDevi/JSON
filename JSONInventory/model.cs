using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JSONInventory
{
    public class model
    {
        public string name { get; set; }
        public int weight { get; set; }
        public int price { get; set; }

        public List<model> Amazon { get; set; }
        public List<model> Flipkart { get; set; }
        public List<model> DMart { get; set; }
    }
}
