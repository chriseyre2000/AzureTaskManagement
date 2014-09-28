using System;
using System.IO;

namespace TaskManagement
{
    public class FileLockManager : ILockManager, IDisposable
    {
        private string filename;
        private FileStream lockFilestream;
        private bool disposed = false;

        public FileLockManager(string filename)
        {
            this.filename = filename;
        }

        ~FileLockManager()
        {
            this.Dispose();
        }

        public bool TryGetLock()
        {
            try
            {
                lockFilestream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Read, FileShare.None);
                return true;
            }
            catch (IOException ex)
            {
                return false;
            }

        }

        public bool MaintainLock()
        {
            return true;
        }

        public void Dispose()
        {
            if (!disposed)
            {
                disposed = true;
                lockFilestream.Dispose();
            }
        }
    }
}
