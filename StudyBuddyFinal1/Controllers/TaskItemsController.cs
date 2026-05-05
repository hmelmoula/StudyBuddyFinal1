using Microsoft.AspNetCore.Mvc;
using StudyBuddyFinal1.Models;
using StudyBuddyFinal1.Services;
using Microsoft.AspNetCore.Authorization;

namespace StudyBuddyFinal1.Controllers
{
    [Authorize]
    public class TaskItemsController : Controller
    {
        private readonly TaskItemService _service;

        public TaskItemsController(TaskItemService service)
        {
            _service = service;
        }

        // GET: TaskItems
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }

        // GET: TaskItems/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var taskItem = await _service.GetByIdAsync(id);

            if (taskItem == null)
                return NotFound();

            return View(taskItem);
        }

        // GET: TaskItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaskItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaskItem taskItem)
        {
            if (!ModelState.IsValid)
                return View(taskItem);

            await _service.AddAsync(taskItem);

            return RedirectToAction(nameof(Index));
        }

        // GET: TaskItems/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var taskItem = await _service.GetByIdAsync(id);

            if (taskItem == null)
                return NotFound();

            return View(taskItem);
        }

        // POST: TaskItems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TaskItem taskItem)
        {
            if (!ModelState.IsValid)
                return View(taskItem);

            await _service.UpdateAsync(taskItem);

            return RedirectToAction(nameof(Index));
        }

        // GET: TaskItems/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var taskItem = await _service.GetByIdAsync(id);

            if (taskItem == null)
                return NotFound();

            return View(taskItem);
        }

        // POST: TaskItems/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskItem = await _service.GetByIdAsync(id);

            if (taskItem != null)
                await _service.DeleteAsync(taskItem);

            return RedirectToAction(nameof(Index));
        }
    }
}