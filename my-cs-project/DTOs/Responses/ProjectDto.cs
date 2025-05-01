namespace my_cs_project.DTOs.Responses
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GithubUrl { get; set; }
        public DateTime StartDate { get; set; }
        public string Description { get; set; }
        public List<TechnologyDto> Technologies { get; set; }
    }
}
