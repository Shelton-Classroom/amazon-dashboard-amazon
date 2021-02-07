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
            var dataRetriever = new DataRetriever { };
            dataRetriever.Initialize("8918", "8SIUJJ576MF9V1PP31BY79CNRFIND0N0BJFV8VSSMZVQ7FC181TOAGK0Q6CEBR37");
            var task = dataRetriever.Get<List<SAInventory>>("https://rest.selleractive.com:443/api/Inventory");
            task.Wait();
            var result = task.Result;
            Console.ReadKey();
        }
    }
}
