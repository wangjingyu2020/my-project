using Microsoft.AspNetCore.Mvc;
using my_cs_project.DTOs.Responses;
using my_cs_project.Entities.Models;
using my_cs_project.Services;
using my_cs_project.Services.Impl;

namespace my_cs_project.Controllers
{
    [ApiController]
    [Route("api/portfolio/[controller]/[action]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // ✅ Get user skills
        [HttpGet("{userId}")]
        public async Task<ActionResult<ApiResponse<List<ProjectDto>>>> getProjects(int userId)
        {
            var projects = await _projectService.GetProjectsByUserIdAsync(userId);
            return Ok(new ApiResponse<List<ProjectDto>>
            {
                Code = 200,
                Message = projects.Any() ? "Projects retrieved successfully" : "No projects found for this user",
                Data = projects
            });
        }

    }
}
