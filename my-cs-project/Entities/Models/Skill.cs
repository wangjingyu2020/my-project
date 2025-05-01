namespace my_cs_project.Entities.Models
{
    using System;

    public class Skill
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TechnologyId { get; set; }
        public string Level { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;

        public Technology Technology { get; set; }
    }
}
