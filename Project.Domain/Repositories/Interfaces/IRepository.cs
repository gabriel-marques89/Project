using System.Linq;

namespace Project.Domain.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        IQueryable<T> All();
        T GetById(int id);
        void Update(T entity);
        void Delete(int id);
        void Save();
    }
}
