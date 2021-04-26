using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace AmazonAPI
{
    class ApiModel
    {
        public static Task<Root> ShipStation()
        {
            var shipStation = new ShipStation { };
            shipStation.InitializeTwo("06abbc4a37994912ab7667a3765a2ab5", "d6c652b062584facb8605e867018bef9");
            var taskTwo = shipStation.Get<Root>("https://ssapi.shipstation.com/shipments");
            return taskTwo;
        }

        public static Task<List<Order>> Order()
        {
            var dataRetriever = new DataRetriever { };
            dataRetriever.Initialize("8918", "8SIUJJ576MF9V1PP31BY79CNRFIND0N0BJFV8VSSMZVQ7FC181TOAGK0Q6CEBR37");
            var task = dataRetriever.Get<List<Order>>("https://rest.selleractive.com:443/api/Order");
            return task;
        }
    }

    public class Timer
    {
        public Timer()
        {
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(5);

            var timer = new System.Threading.Timer((e) =>
            {
                ApiModel.ShipStation();
                ApiModel.Order();
            }, null, startTimeSpan, periodTimeSpan);
        }
    }
}
