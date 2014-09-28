using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskManagement
{
    public class SubscriptionHelper
    {
        RedisClient client;
        RedisSubscription redisSubscription;

        public void Execute()
        {
            this.client = new RedisClient();


            TaskFactory taskFactory = new TaskFactory();
            taskFactory.StartNew(() =>
            {
                redisSubscription = new RedisSubscription(client);
                redisSubscription.OnMessage = (t, m) => Console.WriteLine("topic '{0}' message '{1}'", t, m);
                redisSubscription.SubscribeToChannels("abc");
            });
        }
    }
}
