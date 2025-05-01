namespace my_cs_project.Entities.Models
{
    using System;

    public class SkillHistory
    {
        public int Id { get; set; }
        public int SkillId { get; set; }
        public int Year { get; set; }
        public int Popularity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;

        public Skill Skill { get; set; }
    }
}
