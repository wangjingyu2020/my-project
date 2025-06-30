using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using my_cs_project.Entities.Context;
using my_cs_project.Entities.Models;
using System;

namespace my_cs_project.Entities.Seeds
{
    public static class SeedData
    {
        static int userId = 1; // User ID 1


        public static void Initialize(PortfolioDbContext context)
        {


            // ✅ Add tech categories
            if (!context.TechCategories.Any())
            {
                context.TechCategories.AddRange(
                    new TechCategory { Name = "Frontend" },
                    new TechCategory { Name = "Backend" },
                    new TechCategory { Name = "DevOps" }
                );
                context.SaveChanges();
            }

            var frontendCategory = context.TechCategories.First(tc => tc.Name == "Frontend");
            var backendCategory = context.TechCategories.First(tc => tc.Name == "Backend");
            var devopsCategory = context.TechCategories.First(tc => tc.Name == "DevOps");

            // ✅ Add technologies
            if (!context.Technologies.Any())
            {
                context.Technologies.AddRange(
                    new Technology { Name = "HTML", Type = "Language", TechCategoryId = frontendCategory.Id },
                    new Technology { Name = "CSS", Type = "Language", TechCategoryId = frontendCategory.Id },
                    new Technology { Name = "JavaScript", Type = "Language", TechCategoryId = frontendCategory.Id },
                    new Technology { Name = "Flutter", Type = "Framework", TechCategoryId = frontendCategory.Id },
                    new Technology { Name = "Vue", Type = "Framework", TechCategoryId = frontendCategory.Id },
                    new Technology { Name = "React", Type = "Framework", TechCategoryId = frontendCategory.Id },
                    new Technology { Name = "TypeScript", Type = "Language", TechCategoryId = frontendCategory.Id },


                    new Technology { Name = "C#", Type = "Language", TechCategoryId = backendCategory.Id },
                    new Technology { Name = ".NET Core", Type = "Framework", TechCategoryId = backendCategory.Id },
                    new Technology { Name = "Java", Type = "Language", TechCategoryId = backendCategory.Id },
                    new Technology { Name = "Spring Cloud", Type = "Framework", TechCategoryId = backendCategory.Id },
                    new Technology { Name = "Springboot", Type = "Framework", TechCategoryId = backendCategory.Id },

                    new Technology { Name = "PHP", Type = "Language", TechCategoryId = backendCategory.Id },
                    new Technology { Name = "Laravel", Type = "Framework", TechCategoryId = backendCategory.Id },
                    new Technology { Name = "MySQL", Type = "Database", TechCategoryId = backendCategory.Id },
                    new Technology { Name = "PostgreSQL", Type = "Database", TechCategoryId = backendCategory.Id },
                    new Technology { Name = "C++", Type = "Language", TechCategoryId = backendCategory.Id },
                    new Technology { Name = "Qt", Type = "Framework", TechCategoryId = backendCategory.Id },



                    new Technology { Name = "Azure", Type = "Cloud Service", TechCategoryId = devopsCategory.Id },
                    new Technology { Name = "AWS", Type = "Cloud Service", TechCategoryId = devopsCategory.Id },
                    new Technology { Name = "Linux", Type = "Operating System", TechCategoryId = devopsCategory.Id },
                    new Technology { Name = "Windows", Type = "Operating System", TechCategoryId = devopsCategory.Id },
                    new Technology { Name = "Docker", Type = "Containerization", TechCategoryId = devopsCategory.Id }
                );
                context.SaveChanges();
            }

            // ✅ Add skills for user
            if (!context.Skills.Any())
            {
                var allTechnologies = context.Technologies.ToList();

                foreach (var tech in allTechnologies)
                {
                    // Determine proficiency level
                    var proficiency = "Intermediate"; // Default
                    if (new[] { "HTML", "CSS", "JavaScript", "Vue", "Java", "Spring Cloud", "Springboot", "MySQL", "PostgreSQL", "Linux", "Windows", "Docker",
                    "C#", ".NET Core", "Azure", "AWS", "React" }.Contains(tech.Name))
                    {
                        proficiency = "Experienced";
                    }

                    var skill = new Skill
                    {
                        UserId = userId,
                        TechnologyId = tech.Id,
                        Level = proficiency
                    };

                    context.Skills.Add(skill);
                    context.SaveChanges();

                    // ✅ Insert skill history based on defined year ranges
                    var skillYears = new List<int>();

                    if (new[] { "HTML", "CSS", "JavaScript", "Vue", "Java", "Spring Cloud", "Springboot", "MySQL", "PostgreSQL", "Linux", "Windows", "Docker" }.Contains(tech.Name))
                    {
                        skillYears = new List<int> { 2021, 2022, 2023 };
                    }
                    else if (new[] { "C#", ".NET Core", "Azure", "AWS", "React" }.Contains(tech.Name))
                    {
                        skillYears = new List<int> { 2023, 2024, 2025 };
                    }
                    else if (new[] { "PHP", "Flutter" , "Laravel", "TypeScript", "C++", "Qt" }.Contains(tech.Name))
                    {
                        skillYears = new List<int> { 2024, 2025 };
                    }

                    foreach (var year in skillYears)
                    {
                        context.SkillHistories.Add(new SkillHistory
                        {
                            SkillId = skill.Id,
                            Year = year,
                            Popularity = new Random().Next(50, 100) // Randomized popularity between 50-100
                        });
                    }

                    context.SaveChanges();
                }
            }

            // ✅ Add project details
            if (!context.Projects.Any(p => p.Name == "Portfolio"))
            {
                context.Projects.AddRange(
                    new Project
                    {
                        Name = "Portfolio",
                        GithubUrl = "https://github.com/wangjingyu2020/my-project.git",
                        StartDate = new DateTime(2025, 4, 27),
                        Description = "A portfolio project using various technologies"
                    },
                    new Project
                    {
                        Name = "WellMini",
                        GithubUrl = "https://github.com/wangjingyu2020/WellMini.git",
                        StartDate = new DateTime(2025, 6, 30),
                        Description = "A Qt-based activity tracking app with real-time charts and cloud sync"
                    },
                    new Project
                    {
                        Name = "Exchange",
                        GithubUrl = "https://github.com/wangjingyu2020/exchange.git",
                        StartDate = new DateTime(2025, 6, 15),
                        Description = "Design an endpoint for users to fetch exchange rates."
                    }
                );

                context.SaveChanges();

            }

            // ✅ Ensure the Portfolio project exists
            var portfolioProject = context.Projects.FirstOrDefault(p => p.Name == "Portfolio");
            if (portfolioProject != null)
            {
                // ✅ Get the technology IDs for the relevant technologies   
                var technologyIds = context.Technologies
                    .Where(t => new[] { "HTML", "CSS", "JavaScript", "React", "C#", ".NET Core", "Java",
                            "Spring Cloud", "PHP", "Laravel", "MySQL", "Docker" }.Contains(t.Name))
                    .Select(t => t.Id)
                    .ToList();

                // ✅ Insert associations into `projects_technologies`
                foreach (var techId in technologyIds)
                {
                    if (!context.ProjectsTechnologies.Any(pt => pt.ProjectId == portfolioProject.Id && pt.TechnologyId == techId))
                    {
                        context.ProjectsTechnologies.Add(new ProjectTechnology
                        {
                            ProjectId = portfolioProject.Id,
                            TechnologyId = techId,
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow
                        });
                    }
                }

                context.SaveChanges(); // ✅ Persist changes
            }


            var wellMiniProject = context.Projects.FirstOrDefault(p => p.Name == "WellMini");
            if (wellMiniProject != null)
            {
                var techIds = context.Technologies
                    .Where(t => new[] {"Qt", "C++"}.Contains(t.Name))
                    .Select(t => t.Id)
                    .ToList();

                foreach (var techId in techIds)
                {
                    if (!context.ProjectsTechnologies.Any(pt => pt.ProjectId == wellMiniProject.Id && pt.TechnologyId == techId))
                    {
                        context.ProjectsTechnologies.Add(new ProjectTechnology
                        {
                            ProjectId = wellMiniProject.Id,
                            TechnologyId = techId,
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow
                        });
                    }
                }

                context.SaveChanges();
            }

            var exchangeProject = context.Projects.FirstOrDefault(p => p.Name == "Exchange");
            if (exchangeProject != null)
            {
                var techIds = context.Technologies
                    .Where(t => new[] { "Java", "Springboot" }.Contains(t.Name))
                    .Select(t => t.Id)
                    .ToList();

                foreach (var techId in techIds)
                {
                    if (!context.ProjectsTechnologies.Any(pt => pt.ProjectId == exchangeProject.Id && pt.TechnologyId == techId))
                    {
                        context.ProjectsTechnologies.Add(new ProjectTechnology
                        {
                            ProjectId = exchangeProject.Id,
                            TechnologyId = techId,
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow
                        });
                    }
                }

                context.SaveChanges();
            }



            var projectIds = context.Projects
                .Where(p => new[] { "Portfolio", "WellMini", "Exchange" }.Contains(p.Name))
                .Select(p => p.Id)
                .ToList();


            foreach (var projectId in projectIds)
            {
                if (!context.UsersProjects.Any(up => up.UserId == userId && up.ProjectId == projectId))
                {
                    context.UsersProjects.Add(new UserProject
                    {
                        UserId = userId,
                        ProjectId = projectId
                    });
                }
            }

            context.SaveChanges();

        }
    }

}
