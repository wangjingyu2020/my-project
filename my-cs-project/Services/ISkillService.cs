using my_cs_project.DTOs.Responses;

namespace my_cs_project.Services
{
    public interface ISkillService
    {
        Task<List<SkillDto>> GetUserSkillsAsync(int userId);
        Task<List<SkillHistoryDto>> GetUserSkillsHistoryAsync(int userId);
    }
}
