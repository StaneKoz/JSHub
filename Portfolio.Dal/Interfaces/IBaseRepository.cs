
namespace Portfolio.Dal.Interfaces
{
    public interface IBaseRepository<T>
    {
        bool Create(T entity);

        T Get(long id);

        IEnumerable<T> GetAll();

        //bool Delete(int id);

        bool Delete(T entity);

        T Update(T entity); 
    }
}
