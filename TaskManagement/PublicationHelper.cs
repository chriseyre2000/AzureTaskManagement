using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement
{
    public class PublicationHelper
    {
        RedisClient client;
        
        public PublicationHelper()
        {
            client = new RedisClient();
        }

        public void Publish(string message)
        {
            client.PublishMessage("abc", message);
        }
    }
}
