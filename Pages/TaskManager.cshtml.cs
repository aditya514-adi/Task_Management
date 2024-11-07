using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task_Management_System.Services;
using Task_Management_System.Module;

namespace Task_Management_System.Pages
{
    public class TaskManagerModel : PageModel
    {
        private readonly TaskService _taskService;

        public TaskManagerModel(TaskService taskService)
        {
            _taskService = taskService;
        }

        [BindProperty]
        public TaskModel Task { get; set; }

        public List<TaskModel> Tasks { get; set; }

        public async Task OnGetAsync()
        {
            Tasks = await _taskService.GetTasksAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _taskService.AddTaskAsync(Task);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _taskService.DeleteTaskAsync(id);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostToggleCompleteAsync(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task != null)
            {
                task.IsCompleted = !task.IsCompleted;
                await _taskService.UpdateTaskAsync(task);
            }
            return RedirectToPage();
        }
    }
}
