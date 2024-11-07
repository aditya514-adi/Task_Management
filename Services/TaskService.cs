using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Management_System.Module;

namespace Task_Management_System.Services
{
    public class TaskService
    {
        private List<TaskModel> tasks = new List<TaskModel>();

        public Task<List<TaskModel>> GetTasksAsync()
        {
            return Task.FromResult(tasks);
        }

        public Task<TaskModel> GetTaskByIdAsync(int id)
        {
            return Task.FromResult(tasks.FirstOrDefault(t => t.Id == id));
        }

        public Task AddTaskAsync(TaskModel newTask)
        {
            newTask.Id = tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1;
            tasks.Add(newTask);
            return Task.CompletedTask;
        }

        public Task DeleteTaskAsync(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                tasks.Remove(task);
            }
            return Task.CompletedTask;
        }

        public Task UpdateTaskAsync(TaskModel updatedTask)
        {
            var task = tasks.FirstOrDefault(t => t.Id == updatedTask.Id);
            if (task != null)
            {
                task.Name = updatedTask.Name;
                task.Description = updatedTask.Description;
                task.DueDate = updatedTask.DueDate;
                task.Priority = updatedTask.Priority;
                task.IsCompleted = updatedTask.IsCompleted;
            }
            return Task.CompletedTask;
        }
    }
}

