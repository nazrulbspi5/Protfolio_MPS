using MPS.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.DataAccess.Repositories
{
    public interface ITestRepository : IRepository<Test, Guid>
    {
    }
}
