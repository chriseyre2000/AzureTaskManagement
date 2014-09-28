using ServiceStack.Redis;
using ServiceStack.Redis.Support.Locking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement
{
    public class RedisExperiment : ILockManager, IDisposable
    {
        RedisClient redisClient = new RedisClient();
        IDisposable redisLock = null;

        DistributedLock distributedLock;

        public bool TryGetLock()
        {
            try
            {
                distributedLock = new DistributedLock();
                
                long lockExpire;

                long result = distributedLock.Lock("master.lock.5", 1, 5, out lockExpire, redisClient);
                
                return result != 0;
            }
            catch (Exception ex)
            {
            //    Console.WriteLine(ex);
            }

            return false;
        }

        public bool MaintainLock()
        {
            //redisClient.r
            return TryGetLock();
        }

        public void Dispose()
        {
            if (redisLock != null)
            {
                redisLock.Dispose();
            }
        }
    }
}
