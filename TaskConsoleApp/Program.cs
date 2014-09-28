using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManagement;

namespace TaskConsoleApp
{
    public class Program
    {
        static void Main()
        {
            //MasterController masterController = new MasterController();
            //
            //Console.WriteLine("Am I master controller? {0}", masterController.IsMasterController);
            //
            //masterController.CheckMasterControllerState();
            //
            //Console.WriteLine("Am I master controller? {0}", masterController.IsMasterController);
            //
            //Console.WriteLine("This is the task console app");

            //new SeedTasks().Seed();

            //new TaskController().CheckAvailableTasks();
            //TaskController taskController = new TaskController();

            //ILockManager lockManager = new FileLockManager("d:\\lockfile.txt");

            ILockManager lockManager = new RedisExperiment();

            MasterController masterController = new MasterController(lockManager);

            SubscriptionHelper subscriptionHelper = new SubscriptionHelper();
            subscriptionHelper.Execute();

            PublicationHelper publicationHelper = new PublicationHelper();

            int i = 0;

            while (true) {
                masterController.CheckMasterControllerState();
                Console.WriteLine("Am I master controller? {0}", masterController.IsMasterController);

                if (masterController.IsMasterController)
                {
                    publicationHelper.Publish(string.Format( "Publication {0}", i++));
                }
                //taskController.CheckAvailableTasks();
                Thread.Sleep(1000);
            }

        }
    }
}
