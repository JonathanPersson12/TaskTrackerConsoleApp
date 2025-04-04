using TaskTrackerApp.Models;
using TaskTrackerApp.Services;

namespace TaskTrackerApp.UI
{
    public static class DisplayMenu
    {
        public static void ShowMenu(TodoManager todoManager)
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the TaskTracker App");
                Console.WriteLine();
                Console.WriteLine("1. Manage Tasks (Add, Remove, Update)");
                Console.WriteLine("2. View Tasks (All, Completed, Sorted)");
                Console.WriteLine("3. Mark Task As Completed");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Select an option");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        ManageTasks(todoManager);
                        break;
                    case "2":
                        ViewTasks(todoManager);
                        break;
                    case "3":
                        MarkTaskAsCompleted(todoManager);
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        private static void ManageTasks(TodoManager todoManager)
        {
            Console.Clear();
            Console.WriteLine("Manage Tasks");
            Console.WriteLine();
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Remove Task");
            Console.WriteLine("3. Update Task");
            Console.WriteLine("Select an option");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddTask(todoManager);
                    break;
                case "2":
                    RemoveTask(todoManager);
                    break;
                case "3":
                    UpdateTask(todoManager);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        private static void ViewTasks(TodoManager todoManager)
        {
            Console.Clear();
            Console.WriteLine("View Tasks");
            Console.WriteLine();
            Console.WriteLine("1. View All Tasks");
            Console.WriteLine("2. View Completed Tasks");
            Console.WriteLine("3. View Sorted Tasks");
            Console.WriteLine("Select an option");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    ViewAllTasks(todoManager);
                    break;
                case "2":
                    ViewCompletedTasks(todoManager);
                    break;
                case "3":
                    ViewSortedTasks(todoManager);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        private static void AddTask(TodoManager todoManager)
        {
            Console.Write("Enter title: ");
            string title = Console.ReadLine();
            Console.Write("Enter description: ");
            string description = Console.ReadLine();
            Console.Write("Enter due date (yyyy-mm-dd) or leave blank: ");
            string dueDateInput = Console.ReadLine();
            DateTime? dueDate = string.IsNullOrEmpty(dueDateInput) ? (DateTime?)null : DateTime.Parse(dueDateInput);

            todoManager.AddTask(title, description, dueDate);
            Console.WriteLine("Task added successfully.");
        }

        private static void RemoveTask(TodoManager todoManager)
        {
            Console.Write("Enter task ID to remove: ");
            int id = int.Parse(Console.ReadLine());
            todoManager.RemoveTask(id);
            Console.WriteLine("Task removed successfully.");
        }

        private static void UpdateTask(TodoManager todoManager)
        {
            Console.Write("Enter task ID to update: ");
            int id = int.Parse(Console.ReadLine());
            var task = todoManager.GetTaskById(id);
            if (task != null)
            {
                Console.Write("Enter new title (leave blank to keep current): ");
                string title = Console.ReadLine();
                if (!string.IsNullOrEmpty(title))
                {
                    task.Title = title;
                }

                Console.Write("Enter new description (leave blank to keep current): ");
                string description = Console.ReadLine();
                if (!string.IsNullOrEmpty(description))
                {
                    task.Description = description;
                }

                Console.Write("Enter new due date (yyyy-mm-dd) or leave blank to keep current: ");
                string dueDateInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(dueDateInput))
                {
                    task.DueDate = DateTime.Parse(dueDateInput);
                }

                todoManager.UpdateTask(task);
                Console.WriteLine("Task updated successfully.");
            }
            else
            {
                Console.WriteLine("Task not found.");
            }
        }

        private static void ViewAllTasks(TodoManager todoManager)
        {
            var tasks = todoManager.GetTasks();
            DisplayTasks(tasks);
        }

        private static void ViewCompletedTasks(TodoManager todoManager)
        {
            var completedTasks = todoManager.GetTasks().Where(t => t.IsCompleted).ToList();
            DisplayTasks(completedTasks);
        }

        private static void ViewSortedTasks(TodoManager todoManager)
        {
            Console.Clear();
            Console.WriteLine("Sort Tasks");
            Console.WriteLine();
            Console.WriteLine("1. Sort by Title");
            Console.WriteLine("2. Sort by Due Date");
            Console.WriteLine("3. Sort by Completion Status");
            Console.WriteLine("Select an option");
            string option = Console.ReadLine();

            List<TaskItem> sortedTasks = option switch
            {
                "1" => SortingFunction.SortByTitle(todoManager.GetTasks()),
                "2" => SortingFunction.SortByDueDate(todoManager.GetTasks()),
                "3" => SortingFunction.SortByCompletionStatus(todoManager.GetTasks()),
                _ => todoManager.GetTasks()
            };

            DisplayTasks(sortedTasks);
        }

        private static void MarkTaskAsCompleted(TodoManager todoManager)
        {
            Console.Write("Enter task ID to mark as completed: ");
            int id = int.Parse(Console.ReadLine());
            todoManager.MarkTaskAsCompleted(id);
            Console.WriteLine("Task marked as completed.");
        }

        private static void DisplayTasks(List<TaskItem> tasks)
        {
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("| ID  | Title               | Due Date   | Completed |");
            Console.WriteLine("------------------------------------------------------------");

            foreach (var task in tasks)
            {
                string dueDate = task.DueDate.HasValue ? task.DueDate.Value.ToString("yyyy-MM-dd") : "N/A";
                string completed = task.IsCompleted ? "Yes" : "No";
                Console.WriteLine($"| {task.Id,-3} | {task.Title,-18} | {dueDate,-10} | {completed,-9} |");
            }

            Console.WriteLine("------------------------------------------------------------");
        }
    }
}
