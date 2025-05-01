namespace my_cs_project.Entities.Models
{
    using System;

    public class Technology
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int TechCategoryId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;

        public TechCategory TechCategory { get; set; }
    }
}
