using Portfolio.Dal.Interfaces;
using Portfolio.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Dal.Repositories
{
    public class ProfileRepository : IBaseRepository<Profile>
    {
        private readonly AppDBContext _dbContext;

        public ProfileRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Create(Profile entity)
        {
            _dbContext.Profiles.Add(entity);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(Profile entity)
        {
            var profile = _dbContext.Profiles.FirstOrDefault(u => u.Id == entity.Id);
            if (profile != null)
            {
                _dbContext.Profiles.Remove(profile);
                _dbContext.SaveChanges();
                return true;
            }
            return false; ;
        }

        public Profile Get(long id)
        {
            return _dbContext.Profiles.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Profile> GetAll()
        {
            return _dbContext.Profiles;
        }

        public Profile Update(Profile entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
            
            return entity;
        }
    }
}
