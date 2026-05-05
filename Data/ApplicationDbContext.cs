using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudyBuddyFinal.Models;
using StudyBuddyFinal1.Models;

namespace StudyBuddyFinal1.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<StudyBuddyFinal.Models.Course> Course { get; set; } = default!;
        public DbSet<TaskItem> TaskItems { get; set; } 
    }
}
