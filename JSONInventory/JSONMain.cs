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
        class StockAccountManagement
        {
            double amount = 10000;
            List<StockDetails> stock = new List<StockDetails>();
            List<StockDetails> customer = new List<StockDetails>();
            public void ReadStockJsonFile(string filePath)
            {
                var json = File.ReadAllText(filePath);
                this.stock = JsonConvert.DeserializeObject<List<StockDetails>>(json);
                foreach (var content in stock)
                {
                    Console.WriteLine("{0}" + "\t" + "{1}" + "\t" + "{2}", content.StockName, content.StockPrice, content.NoOfShares);
                }
            }
            public void ReadCustomerJsonFile(string filePath)
            {
                var json = File.ReadAllText(filePath);
                this.customer = JsonConvert.DeserializeObject<List<StockDetails>>(json);
                foreach (var content in customer)
                {
                    //Console.WriteLine(content.StockName + " " + content.StockPrice + " " + content.NoOfShares);
                    Console.WriteLine("{0}" + "\t" + "{1}" + "\t" + "{2}" + "\t\t" + "{3}", content.StockName, content.StockPrice, content.NoOfShares, content.NoOfShares * content.StockPrice);
                }
            }

            public void BuyStock(string name)
            {
                foreach (var data in stock)
                {
                    int count = 0;
                    if (data.StockName.Equals(name))
                    {
                        Console.WriteLine("Enter The Number Of Stocks You Want To Buy : ");
                        int noOfStocks = Convert.ToInt32(Console.ReadLine());
                        if (noOfStocks * data.StockPrice <= amount && noOfStocks <= data.NoOfShares)
                        {
                            StockDetails details = new StockDetails()
                            {
                                StockName = data.StockName,
                                StockPrice = data.StockPrice,
                                NoOfShares = noOfStocks
                            };
                            data.NoOfShares -= noOfStocks;
                            amount -= data.StockPrice * noOfStocks;

                            foreach (var account in customer)
                            {
                                if (account.StockName.Equals(name))
                                {
                                    account.NoOfShares += noOfStocks;
                                    count++;
                                }
                            }
                            if (count == 0)
                            {
                                customer.Add(details);
                            }


                        }
                    }
                }
            }
            public void SellStock(string name)
            {
                foreach (var data in customer)
                {
                    int count = 0;
                    if (data.StockName.Equals(name))
                    {
                        Console.WriteLine("Enter The Name Of Stock You Want To Sell : ");
                        int noOfStocks = Convert.ToInt32(Console.ReadLine());
                        if (noOfStocks <= data.NoOfShares)
                        {
                            StockDetails details = new StockDetails()
                            {
                                StockName = data.StockName,
                                StockPrice = data.StockPrice,
                                NoOfShares = noOfStocks
                            };
                            data.NoOfShares -= noOfStocks;
                            amount += data.StockPrice * noOfStocks;

                            foreach (var account in stock)
                            {
                                if (account.StockName.Equals(name))
                                {
                                    data.NoOfShares += noOfStocks;
                                    count--;
                                }
                            }
                            if (count == 1)
                            {
                                stock.Add(details);
                            }
                        }
                    }
                }
            }
            public void WriteToStockJsonFile(string filepath)
            {
                var json = JsonConvert.SerializeObject(stock);
                File.WriteAllText(filepath, json);
            }
            public void WriteToCusatomerJsonFile(string filepath)
            {
                var json = JsonConvert.SerializeObject(customer);
                File.WriteAllText(filepath, json);
            }

        }   
}
