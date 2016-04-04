using System.Linq;
using NHibernate;
using NHibernate.Linq;
using Project.Domain.Repositories.Interfaces;

namespace Project.Infrastructure.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session;
        }

        public IQueryable<T> All()
        {
            return _session.Query<T>();
        }

        public void Add(T entity)
        {
            _session.Save(entity);
        }

        public T GetById(int id)
        {
            return _session.Get<T>(id);
        }

        public void Update(T entity)
        {
            _session.Update(entity);
        }

        public void Delete(int id)
        {
            _session.Delete(_session.Load<T>(id));
        }

        public void Save()
        {
            _session.Flush();
        }

        public T FindBy(System.Linq.Expressions.Expression<System.Func<T, bool>> expression)
        {
            return FilterBy(expression).Single();
        }

        public IQueryable<T> FilterBy(System.Linq.Expressions.Expression<System.Func<T, bool>> expression)
        {
            return All().Where(expression).AsQueryable();
        }
    }
}
