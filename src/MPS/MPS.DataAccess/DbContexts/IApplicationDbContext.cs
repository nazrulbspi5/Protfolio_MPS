using MPS.DataAccess;
using Microsoft.EntityFrameworkCore;
using MPS.DataAccess.Entities;

namespace MPS.DataAccess.DbContexts
{
    public interface IApplicationDbContext
    {
       public DbSet<Test> Tests { get; set; }
    }
}