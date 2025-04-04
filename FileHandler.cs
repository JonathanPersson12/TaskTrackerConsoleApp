using TaskTrackerApp.Models;

namespace TaskTrackerApp.Data
{
    public static class FileHandler
    {
        private static readonly string FilePath = "tasks.txt";

        public static void SaveTasks(List<TaskItem> tasks)
        {
            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                foreach (var task in tasks)
                {
                    writer.WriteLine($"{task.Id}|{task.Title}|{task.Description}|{task.DueDate}|{task.IsCompleted}");
                }
            }
        }

        public static List<TaskItem> LoadTasks()
        {
            List<TaskItem> tasks = new List<TaskItem>();
            if (File.Exists(FilePath))
            {
                using (StreamReader reader = new StreamReader(FilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        try
                        {
                            var parts = line.Split('|');
                            // Validate the line format
                            if (parts.Length != 5)
                            {
                                Console.WriteLine($"Invalid line format: {line}");
                                continue;
                            }

                            // Validate and parse the Id
                            if (!int.TryParse(parts[0], out var id))
                            {
                                Console.WriteLine($"Invalid Id: {parts[0]} in line: {line}");
                                continue;
                            }

                            // Parse the DueDate
                            DateTime? dueDate = DateTime.TryParse(parts[3], out var parsedDate) ? parsedDate : null;
                            // Create the TaskItem
                            TaskItem task = new TaskItem(
                                id, // Id
                                parts[1], // Title
                                parts[2], // Description
                                dueDate // DueDate
                            )
                            {
                                IsCompleted = bool.Parse(parts[4]) // Parse IsCompleted
                            };
                            tasks.Add(task);
                        }
                        catch (Exception ex)
                        {
                            // Log the exception and continue
                            Console.WriteLine($"Error processing line: {line}. Exception: {ex.Message}");
                        }
                    }
                }
            }

            return tasks;
        }
    }
}