using Tasks.API.Data.DTO;
using Tasks.Models.Domain;

namespace Tasks.API.Repositories.Interface
{
    public interface IDutyRepository
    {
        Task<Duty> CreateDuty(Duty duty);
        List<Duty> UserDuties(DutyRequestDTO duty);
        Task<DutyResponseDTO> UpdateDuty(Duty duty);
        Task<DutyResponseDTO> DeleteDuty(Guid id);

    }
}
