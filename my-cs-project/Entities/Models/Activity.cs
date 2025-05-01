using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace my_cs_project.Entities.Models
{
    [Table("activities", Schema = "portfolio")]
    public class Activity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false;

        [Required]
        [Column("activity_type")]
        public ActivityType ActivityType { get; set; }

        [Required]
        [Column("activity_name")]
        [MaxLength(100)]
        public string ActivityName { get; set; } = string.Empty;

        [Column("activity_description")]
        public string? ActivityDescription { get; set; }

        [Required]
        [Column("status")]
        public ActivityStatus Status { get; set; } = ActivityStatus.Pending;
    }

    public enum ActivityType
    {
        Work,
        Travel,
        Sport,
        Entertainment,
        Education
    }

    public enum ActivityStatus
    {
        Pending,
        InProgress,
        Completed,
        Canceled,
        Paused
    }
}

