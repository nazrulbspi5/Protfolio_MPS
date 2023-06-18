using Microsoft.EntityFrameworkCore;
using MPS.DataAccess.DbContexts;
using MPS.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.DataAccess.Repositories
{
    public class TestRepository : Repository<Test, Guid>, ITestRepository
    {
        private readonly IApplicationDbContext _dbContext;
        public TestRepository(IApplicationDbContext context) : base((DbContext)context)
        {
            _dbContext = context;
        }
    }
}
