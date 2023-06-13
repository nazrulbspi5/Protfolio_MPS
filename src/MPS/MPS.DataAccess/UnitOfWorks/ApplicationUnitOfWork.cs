﻿using MPS.DataAccess.DbContexts;
using MPS.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MPS.DataAccess.UnitOfWorks
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
       
        public ApplicationUnitOfWork(IApplicationDbContext dbContext)
            : base((DbContext)dbContext)
        {
           
        }
    }
}