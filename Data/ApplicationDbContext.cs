using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudyBuddyFinal.Models;

namespace StudyBuddyFinal1.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<StudyBuddyFinal.Models.Course> Course { get; set; } = default!;
    }
}
