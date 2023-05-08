using JSHub.Dal.Interfaces;
using JSHub.Domain.Entity;

namespace JSHub.Dal.Repositories
{
    public class ProjectRepository : IBaseRepository<Project>
    {
        private readonly AppDBContext _dbContext;

        public ProjectRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Create(Project entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(Project entity)
        {
            var project = _dbContext.Projects.FirstOrDefault(p => p.Id == entity.Id);
            if (project != null)
            {
                _dbContext.Projects.Remove(project);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public Project Get(long id)
        {
            return _dbContext.Projects.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Project> GetAll()
        {
            return _dbContext.Projects;
        }

        public Project Update(Project entity)
        {
            throw new NotImplementedException();
        }
    }
}
