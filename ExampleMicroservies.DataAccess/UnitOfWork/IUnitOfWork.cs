using System;
using ExampleMicroservices.DataAccess.Repository;

namespace ExampleMicroservices.DataAccess.UnitOfWork
{
   public  interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;
        int SaveChanges();
    }
}
