using System.ComponentModel.DataAnnotations;

namespace StudyBuddyFinal.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        public string CourseName { get; set; }

        public string Instructor { get; set; }
    }
}