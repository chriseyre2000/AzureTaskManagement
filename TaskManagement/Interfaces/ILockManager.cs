namespace TaskManagement
{
    public interface ILockManager
    {
        bool TryGetLock();
        bool MaintainLock();
    }
}
