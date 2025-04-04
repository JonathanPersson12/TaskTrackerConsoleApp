using TaskTrackerApp.Data;
using TaskTrackerApp.Models;


namespace TaskTrackerApp.Services
{
    public class TodoManager
    {
        private List<TaskItem> tasks;
        private static int nextId = 1;

        public TodoManager()
        {
            tasks = FileHandler.LoadTasks();
            if (tasks.Any())
            {
                nextId = tasks.Max(t => t.Id) + 1;
            }
        }

        public void AddTask(string title, string description, DateTime? dueDate = null)
        {
            var task = new TaskItem(nextId++, title, description, dueDate);
            tasks.Add(task);
            FileHandler.SaveTasks(tasks);
        }

        public void RemoveTask(int id)
        {
            var task = tasks.FirstOrDefault(task => task.Id == id);
            if (task != null)
            {
                tasks.Remove(task);
                FileHandler.SaveTasks(tasks);
            }
        }

        public void MarkTaskAsCompleted(int id)
        {
            var task = tasks.FirstOrDefault(task => task.Id == id);
            if (task != null)
            {
                task.IsCompleted = true;
                FileHandler.SaveTasks(tasks);
            }
        }

        public void UpdateTask(TaskItem updatedTask)
        {
            var task = tasks.FirstOrDefault(t => t.Id == updatedTask.Id);
            if (task != null)
            {
                task.Title = updatedTask.Title;
                task.Description = updatedTask.Description;
                task.DueDate = updatedTask.DueDate;
                task.IsCompleted = updatedTask.IsCompleted;
                FileHandler.SaveTasks(tasks);
            }
        }

        public List<TaskItem> GetTasks()
        {
            return tasks;
        }

        public TaskItem GetTaskById(int id)
        {
            return tasks.FirstOrDefault(task => task.Id == id)!;
        }
    }
}
