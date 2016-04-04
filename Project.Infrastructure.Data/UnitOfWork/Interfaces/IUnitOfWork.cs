using System;
using NHibernate;

namespace Project.Infrastructure.Data.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ISession Session { get; }
        void Commit();
        void Rollback();
    }
}