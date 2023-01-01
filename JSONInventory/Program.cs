using JSONInventory;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System;
using System.Collections;

namespace StockInventory
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string stockFilePath = @"E:\RFP231\JSON\JSONInventory\Inventory.json";
            StockAccountManagement management = new StockAccountManagement();
        
            Console.WriteLine("List Of All Company Stock :");
            management.ReadStockJsonFile(stockFilePath);
 
        }
    }
}