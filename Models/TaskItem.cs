using System.ComponentModel.DataAnnotations;

namespace StudyBuddyFinal1.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required]
        public string TaskName { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsCompleted { get; set; }
    }
}