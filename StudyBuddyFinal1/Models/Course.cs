using System.ComponentModel.DataAnnotations;

namespace StudyBuddyFinal1.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        public string CourseName { get; set; }

        public string Instructor { get; set; }
    }
}