using Microsoft.EntityFrameworkCore;
using my_cs_project.DTOs.Responses;
using my_cs_project.Entities.Context;

namespace my_cs_project.Services.Impl
{
    public class ProjectService : IProjectService
    {
        private readonly PortfolioDbContext _context;

        public ProjectService(PortfolioDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProjectDto>> GetProjectsByUserIdAsync(int userId)
        {
            return await _context.UsersProjects
                .Where(up => up.UserId == userId)
                .Select(up => new ProjectDto
                {
                    Id = up.Project.Id,
                    Name = up.Project.Name,
                    GithubUrl = up.Project.GithubUrl,
                    StartDate = up.Project.StartDate,
                    Description = up.Project.Description,

                    Technologies = _context.ProjectsTechnologies
                        .Where(pt => pt.ProjectId == up.Project.Id)
                        .Select(pt => new TechnologyDto
                        {
                            Id = pt.Technology.Id,
                            Name = pt.Technology.Name,
                            Type = pt.Technology.Type
                        }).ToList()
                })
                .ToListAsync();
        }


    }
}
