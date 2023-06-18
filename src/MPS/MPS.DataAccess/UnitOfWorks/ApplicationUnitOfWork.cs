using MPS.DataAccess.DbContexts;
using MPS.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MPS.DataAccess.UnitOfWorks
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {

        public ITestRepository Tests { get; private set; }
        public ApplicationUnitOfWork(IApplicationDbContext dbContext, ITestRepository testRepository)
            : base((DbContext)dbContext)
        {
            Tests = testRepository;  
        }
       
        
    }
}