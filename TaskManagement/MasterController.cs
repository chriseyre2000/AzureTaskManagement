namespace TaskManagement
{
    public class MasterController
    {
        ILockManager lockManager;

        public MasterController(ILockManager lockManager)
        {
            this.lockManager = lockManager;
        }

        private MasterControllerState state = MasterControllerState.Slave;

        public bool IsMasterController
        {
            get { return this.state == MasterControllerState.Master; }
        }

        public bool CheckMasterControllerState()
        {
            if (IsMasterController)
            {
                //Allow locks that need to be reknewed to stay alive
                return lockManager.MaintainLock();            
            }

            if (this.lockManager.TryGetLock())
            {
                this.state = MasterControllerState.Master;
                return true;
            }
            return false;

            //CloudBlobClient blobClient = CloudStorageAccount.DevelopmentStorageAccount.CreateCloudBlobClient();
            //ICloudBlob blob = blobClient.GetBlobReferenceFromServer(new Uri("http://127.0.0.1:10000/devstoreaccount1/task-management/CinemaCode.txt"));
            //
            //string lease = Guid.NewGuid().ToString();
            //
            ////This is not good, since I can't even acquire a lease. 
            //try
            //{
            //    string result = blob.AcquireLease(TimeSpan.FromMinutes(60), lease);
            //    if (result == lease)
            //    {
            //        this.state = MasterControllerState.Master;
            //    }
            //}
            //catch (StorageException ex)
            //{
            //    this.state = MasterControllerState.Slave;
            //
            //    Console.WriteLine(ex);
            //}

            //string result = blob.AcquireLease(TimeSpan.FromHours(1), "lease"); 

           // Console.WriteLine(result);


            //return false;
        }


    }
}
