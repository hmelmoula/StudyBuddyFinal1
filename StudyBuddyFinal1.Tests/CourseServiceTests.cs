using Microsoft.EntityFrameworkCore;
using StudyBuddyFinal1.Data;
using StudyBuddyFinal1.Models;
using StudyBuddyFinal1.Services;

namespace StudyBuddyFinal1.Tests
{
    public class CourseServiceTests
    {
        // create in-memory database for testing
        private ApplicationDbContext GetContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(options);
        }
        // Tests if AddAsync successfully adds a new course to the database
        [Fact]
        public async Task AddAsync_AddsCourse()
        {
            var context = GetContext();
            var service = new CourseService(context);

            // create course
            var course = new Course
            {
                CourseName = "Math",
                Instructor = "Smith"
            };

            // add course
            await service.AddAsync(course);

            // get all courses
            var courses = await service.GetAllAsync();

            // check result
            Assert.Single(courses);
            Assert.Equal("Math", courses[0].CourseName);
        }
        // Tests if UpdateAsync successfully updates a course's information in the database
        [Fact]
        public async Task UpdateAsync_UpdatesCourse()
        {
            var context = GetContext();
            var service = new CourseService(context);

            var course = new Course
            {
                CourseName = "Math",
                Instructor = "Smith"
            };

            await service.AddAsync(course);

            // update course name
            course.CourseName = "Advanced Math";
            await service.UpdateAsync(course);

            var updated = await service.GetByIdAsync(course.Id);

            // check updated value
            Assert.Equal("Advanced Math", updated.CourseName);
        }
        // Tests if DeleteAsync successfully removes a course from the database
        [Fact]
        public async Task DeleteAsync_RemovesCourse()
        {
            var context = GetContext();
            var service = new CourseService(context);

            var course = new Course
            {
                CourseName = "English",
                Instructor = "Jones"
            };

            await service.AddAsync(course);

            // delete course
            await service.DeleteAsync(course);

            var courses = await service.GetAllAsync();

            // should be empty
            Assert.Empty(courses);
        }
    }
}