using Portfolio.Dal;
using Portfolio.Domain.Entity;
using Portfolio.Domain.Response;
using Portfolio.Service.Interfaces;

namespace Portfolio.Service.Implementations
{
    public class SpecialityService : ISpecialityBox
    {
        private readonly AppDBContext _dbContext;

        public SpecialityService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BaseResponse<IEnumerable<SpecialityBox>> GetAll()
        {
            throw new NotImplementedException();
        }

        public BaseResponse<IEnumerable<SpecialityBox>> GetProfileSpecialities(long profileId)
        {
            throw new NotImplementedException();
        }
    }
}
