using JSHub.Dal.Interfaces;
using JSHub.Domain.Entity;

namespace JSHub.Dal.Repositories
{
    public class UserRepostory : IBaseRepository<User>
    {
        private readonly AppDBContext _dbContext;
        public UserRepostory(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Create(User entity)
        {
            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(User entity)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == entity.Id);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public User Get(long id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users;
        }

        public User Update(User entity)
        {
            _dbContext.Users.Update(entity);
            _dbContext.SaveChanges();
            return entity;
        }
    }
}
