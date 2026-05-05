using Microsoft.EntityFrameworkCore;
using StudyBuddyFinal1.Data;
using StudyBuddyFinal1.Models;

namespace StudyBuddyFinal1.Services
{
    public class TaskItemService
    {
        private readonly ApplicationDbContext _context;

        public TaskItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all task items
        public async Task<List<TaskItem>> GetAllAsync()
        {
            return await _context.TaskItems
                .Include(t => t.Course)
                .ToListAsync();
        }

        // Get one task item by id
        public async Task<TaskItem?> GetByIdAsync(int id)
        {
            return await _context.TaskItems
                .Include(t => t.Course)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        // Add a new task item
        public async Task AddAsync(TaskItem taskItem)
        {
            _context.TaskItems.Add(taskItem);
            await _context.SaveChangesAsync();
        }

        // Update a task item
        public async Task UpdateAsync(TaskItem taskItem)
        {
            _context.TaskItems.Update(taskItem);
            await _context.SaveChangesAsync();
        }

        // Delete a task item
        public async Task DeleteAsync(TaskItem taskItem)
        {
            _context.TaskItems.Remove(taskItem);
            await _context.SaveChangesAsync();
        }
    }
}