using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace LiveStockData
{
    class Program
    {

        private readonly List<string> tickerlist = new List<string>();

        public void SetTicker()
        {
            char keepGoing='y';
            while(keepGoing=='y')
            {
                Console.WriteLine("Enter ticker:");
                var ticker = Console.ReadLine();
                ticker = ticker.ToUpper();
                tickerlist.Add(ticker);

                Console.WriteLine("Would you like more tickers? (y/n)");
                keepGoing = Convert.ToChar(Console.ReadLine());
            }
            
        }

        public void GetClient()
        {
            
            foreach(string ticker in tickerlist)
            {
                var client = new RestClient($"https://api.polygon.io/v1/open-close/{ticker}/2020-10-14?adjusted=true&apiKey=7WDBvplZZDsVBLOaPS8mVzKOycDrgp3B");
                var request = new RestRequest("", DataFormat.Json);
                var response = client.Get(request);
                JObject json = JObject.Parse(response.Content);
                Console.WriteLine($"After houre price of {json["symbol"]} is: {json["afterHours"]}");


            }
        }
        static void Main(string[] args)
        {
            var object1 = new Program();
            object1.SetTicker();
            object1.GetClient();
            
        }
    }
}
