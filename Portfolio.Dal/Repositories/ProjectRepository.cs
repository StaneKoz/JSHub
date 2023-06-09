﻿using Portfolio.Dal.Interfaces;
using Portfolio.Domain.Entity;

namespace Portfolio.Dal.Repositories
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
            var project = Get(entity.Id);
            _dbContext.Update(entity);
            return project;
        }
    }
}
