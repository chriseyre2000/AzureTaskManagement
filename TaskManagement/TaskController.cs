using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement
{
    public class TaskController
    {

        Dictionary<string, Task> currentTasks = new Dictionary<string, Task>();
        Dictionary<string, CloudQueueMessage> currentMessages = new Dictionary<string, CloudQueueMessage>();

        public int Capacity { get; set; }

        public void CheckAvailableTasks()
        {
            CloudQueueClient client = CloudStorageAccount.DevelopmentStorageAccount.CreateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference("management");

            if (currentTasks.Count < Capacity)
            {
                CloudQueueMessage message = queue.GetMessage();
                if (message != null)
                {
                    currentTasks.Add(message.AsString, new Task());
                    currentMessages.Add(message.AsString, message);
                }           
            }

            



            //CloudQueueMessage message =  queue.GetMessage();
            //if (message != null)
            //{
            //    Console.WriteLine(message.AsString);
            //}
            //else
            //{
            //    Console.WriteLine("No tasks");
            //}
            //
            //queue = null;
            //client = null;
        }
    }
}
