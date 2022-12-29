using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json.Nodes;
using Newtonsoft.Json;

namespace JSONInventory
{
    public class JSONMain
    {

        public void ReadJsonFile(string filePath)
        {                      
           var json = File.ReadAllText(filePath);
            model data = JsonConvert.DeserializeObject<model>(json);
            List<model> amazon = data.Amazon;
            List<model> flipkart = data.Flipkart;
            List<model> dmart = data.DMart;
            Console.WriteLine("Amazon: ");
            foreach (var content in amazon)
            {
                double value = content.price * content.weight;
                Console.WriteLine(content.name + "   " + content.price + "   " + content.weight + "   " + value);
            }

            Console.WriteLine("Flipkart:");
            foreach (var content in flipkart)
            {
                double value = content.price * content.weight;
                Console.WriteLine(content.name + "   " + content.price + "   " + content.weight + "   " + value);
            }

            Console.WriteLine("DMart:");
            foreach (var content in dmart)
            {
                double value = content.price * content.weight;
                Console.WriteLine(content.name + "   " + content.price + "   " + content.weight + "   " + value);
            }

        }
    }
}
