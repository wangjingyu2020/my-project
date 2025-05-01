using my_cs_project.DTOs.Responses;
using my_cs_project.Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace my_cs_project.Services.Impl
{

    public class SkillService : ISkillService
    {
        private readonly PortfolioDbContext _context;

        public SkillService(PortfolioDbContext context)
        {
            _context = context;
        }

        // ✅ Get all skills of a user
        public async Task<List<SkillDto>> GetUserSkillsAsync(int userId)
        {
            return await _context.Skills
                .Where(s => s.UserId == userId && !s.IsDeleted)
                .Select(s => new SkillDto
                {
                    Id = s.Id,
                    Name = s.Technology.Name,
                    Level = s.Level,
                    TechCategoryId = s.Technology.TechCategory.Id,
                    TechCategoryName = s.Technology.TechCategory.Name
                })
                .ToListAsync();
        }

        // ✅ Get skill learning history of a user
        public async Task<List<SkillHistoryDto>> GetUserSkillsHistoryAsync(int userId)
        {
            return await _context.SkillHistories
                .Where(sh => _context.Skills.Any(s => s.Id == sh.SkillId && s.UserId == userId))
                .Select(sh => new SkillHistoryDto
                {
                    Id = sh.Id,
                    SkillId = sh.SkillId,
                    SkillName = sh.Skill.Technology.Name,
                    Year = sh.Year,
                    Popularity = sh.Popularity
                })
                .ToListAsync();
        }
    }
}
