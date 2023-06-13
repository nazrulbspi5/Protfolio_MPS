namespace MPS.DataAccess.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}