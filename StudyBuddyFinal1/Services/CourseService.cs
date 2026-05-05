using Microsoft.EntityFrameworkCore;
using StudyBuddyFinal1.Data;
using StudyBuddyFinal1.Models;

namespace StudyBuddyFinal1.Services
{
    public class CourseService
    {
        private readonly ApplicationDbContext _context;

        public CourseService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all courses
        public async Task<List<Course>> GetAllAsync()
        {
            return await _context.Course.ToListAsync();
        }

        // Get one course by id
        public async Task<Course?> GetByIdAsync(int id)
        {
            return await _context.Course
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        // Add a new course
        public async Task AddAsync(Course course)
        {
            _context.Course.Add(course);
            await _context.SaveChangesAsync();
        }

        // Update a course
        public async Task UpdateAsync(Course course)
        {
            _context.Course.Update(course);
            await _context.SaveChangesAsync();
        }

        // Delete a course
        public async Task DeleteAsync(Course course)
        {
            _context.Course.Remove(course);
            await _context.SaveChangesAsync();
        }
    }
}