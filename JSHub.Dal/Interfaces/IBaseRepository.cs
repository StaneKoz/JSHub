using JSHub.Domain.Entity;

namespace JSHub.Dal.Interfaces
{
    public interface IBaseRepository<T>
    {
        bool Create(T entity);

        T Get(int id);

        IEnumerable<T> GetAll();

        //bool Delete(int id);

        bool Delete(T entity);

        T Update(T entity); 
    }
}
