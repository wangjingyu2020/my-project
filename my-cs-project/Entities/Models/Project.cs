namespace my_cs_project.Entities.Models
{
    using System;

    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GithubUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;
    }
}
