using Microsoft.AspNetCore.Mvc;
using my_cs_project.Services;
using my_cs_project.DTOs.Responses;

namespace my_cs_project.Controllers
{
    [ApiController]
    [Route("api/portfolio/[controller]/[action]")]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        // ✅ Get user skills
        [HttpGet("{userId}")]
        public async Task<ActionResult<ApiResponse<List<SkillDto>>>> getUserSkills(int userId)
        {
            var skills = await _skillService.GetUserSkillsAsync(userId);

            return Ok(new ApiResponse<List<SkillDto>>
            {
                Code = 200,
                Message = skills.Any() ? "Skills retrieved successfully" : "No skills found for this user",
                Data = skills
            });
        }

        // ✅ Get skill history
        [HttpGet("{userId}")]
        public async Task<ActionResult<ApiResponse<List<SkillHistoryDto>>>> getUserSkillsHistory(int userId)
        {
            var history = await _skillService.GetUserSkillsHistoryAsync(userId);

            return Ok(new ApiResponse<List<SkillHistoryDto>>
            {
                Code = 200,
                Message = history.Any() ? "Skill history retrieved successfully" : "No skill history found for this user",
                Data = history
            });
        }
    }
}
