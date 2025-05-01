namespace my_cs_project.DTOs.Responses
{
    public class SkillDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }

        public int TechCategoryId { get; set; }

        public string TechCategoryName { get; set; }
    }
}
