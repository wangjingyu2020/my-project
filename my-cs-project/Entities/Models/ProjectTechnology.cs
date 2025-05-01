namespace my_cs_project.Entities.Models
{
    using System;

    public class ProjectTechnology
    {
        public int Id { get; set; }
        public int ProjectId { get; set; } // 关联项目
        public int TechnologyId { get; set; } // 关联技术
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public Project Project { get; set; } // 项目
        public Technology Technology { get; set; } // 技术
    }
}
