using my_cs_project.DTOs.Responses;

namespace my_cs_project.Services
{
    public interface IProjectService
    {
        Task<List<ProjectDto>> GetProjectsByUserIdAsync(int userId);
    }

}
