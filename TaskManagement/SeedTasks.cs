using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace TaskManagement
{
    public class SeedTasks
    {
        public void Seed()
        {
            CloudQueueClient client = CloudStorageAccount.DevelopmentStorageAccount.CreateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference("management");
            queue.CreateIfNotExists();

            queue.AddMessage(new CloudQueueMessage("Task #1"));
            queue.AddMessage(new CloudQueueMessage("Task #2"));

        }
    }
}
