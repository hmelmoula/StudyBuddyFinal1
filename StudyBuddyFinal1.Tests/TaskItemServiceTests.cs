using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;
using StudyBuddyFinal1.Data;
using StudyBuddyFinal1.Models;
using StudyBuddyFinal1.Services;

namespace StudyBuddyFinal1.Tests
{
    public class TaskItemServiceTests
    {
        // create in-memory database for testing
        private ApplicationDbContext GetContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(options);
        }
        // test adding a task item to the database
        [Fact]
        public async Task AddAsync_AddsTaskItem()
        {
            var context = GetContext();
            var service = new TaskItemService(context);

            // create course (required for relationship)
            var course = new Course
            {
                CourseName = "Math",
                Instructor = "Smith"
            };

            context.Course.Add(course);
            await context.SaveChangesAsync();

            // create task
            var task = new TaskItem
            {
                TaskName = "Homework 1",
                Description = "Chapter 1",
                DueDate = DateTime.Today.AddDays(3),
                IsCompleted = false,
                CourseId = course.Id
            };

            await service.AddAsync(task);

            var tasks = await service.GetAllAsync();

            // check result
            Assert.Single(tasks);
            Assert.Equal("Homework 1", tasks[0].TaskName);
        }
        // test if UpdateAsync successfully updates a task item in the database
        [Fact]
        public async Task UpdateAsync_UpdatesTaskItem()
        {
            var context = GetContext();
            var service = new TaskItemService(context);

            var course = new Course
            {
                CourseName = "Science",
                Instructor = "Brown"
            };

            context.Course.Add(course);
            await context.SaveChangesAsync();

            var task = new TaskItem
            {
                TaskName = "Lab",
                Description = "Write report",
                DueDate = DateTime.Today,
                IsCompleted = false,
                CourseId = course.Id
            };

            await service.AddAsync(task);

            // mark as completed
            task.IsCompleted = true;
            await service.UpdateAsync(task);

            var updated = await service.GetByIdAsync(task.Id);

            // check update
            Assert.True(updated.IsCompleted);
        }
        // test if DeleteAsync successfully removes a task item from the database
        [Fact]
        public async Task DeleteAsync_RemovesTaskItem()
        {
            var context = GetContext();
            var service = new TaskItemService(context);

            var course = new Course
            {
                CourseName = "English",
                Instructor = "Jones"
            };

            context.Course.Add(course);
            await context.SaveChangesAsync();

            var task = new TaskItem
            {
                TaskName = "Essay",
                Description = "Final essay",
                DueDate = DateTime.Today,
                IsCompleted = false,
                CourseId = course.Id
            };

            await service.AddAsync(task);

            // delete task
            await service.DeleteAsync(task);

            var tasks = await service.GetAllAsync();

            // should be empty
            Assert.Empty(tasks);
        }
    }
}