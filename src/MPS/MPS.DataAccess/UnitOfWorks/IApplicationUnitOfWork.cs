using MPS.DataAccess.Repositories;

namespace MPS.DataAccess.UnitOfWorks
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        ITestRepository Tests { get; }
    }
}