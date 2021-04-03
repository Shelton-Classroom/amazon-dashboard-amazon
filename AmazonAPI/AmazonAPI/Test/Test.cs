using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonAPI.Test
{
    class Test
    {
        public void test()
        {
            //var dataRetriever = new DataRetriever { };
            //dataRetriever.Initialize("8918", "8SIUJJ576MF9V1PP31BY79CNRFIND0N0BJFV8VSSMZVQ7FC181TOAGK0Q6CEBR37");
            //var task = dataRetriever.Get<List<Order>>("https://rest.selleractive.com:443/api/Order");
            //task.Wait();
            //var result = task.Result;

            var shipStation = new ShipStation { };
            shipStation.InitializeTwo("06abbc4a37994912ab7667a3765a2ab5", "d6c652b062584facb8605e867018bef9");
            var taskTwo = shipStation.Get<Root>("https://ssapi.shipstation.com/shipments");
            taskTwo.Wait();
            var result = taskTwo.Result;
            Console.ReadKey();
        }
    }
}
