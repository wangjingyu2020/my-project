namespace my_cs_project.DTOs.Responses
{
    public class SkillHistoryDto
    {
        public int Id { get; set; }
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public int Year { get; set; }
        public int Popularity { get; set; }
    }
}
