using Portfolio.Domain.Entity;
using Portfolio.Domain.Response;

namespace Portfolio.Service.Interfaces
{
    public interface ISpecialityBox
    {
        BaseResponse<IEnumerable<SpecialityBox>> GetAll();
        BaseResponse<IEnumerable<SpecialityBox>> GetProfileSpecialities(long profileId);
    }
}
