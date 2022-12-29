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
           List<model> data = JsonConvert.DeserializeObject<List<model>>(json);
           Console.WriteLine("name: weight, price, total value");
           foreach (var content in data)
           {     
              double value = content.price * content.weight;
              Console.WriteLine(content.name + " : " + content.weight + " , " + content .price + " , " + value);

           }
            
        }
    }
}
