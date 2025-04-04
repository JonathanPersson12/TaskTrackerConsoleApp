using System;

namespace TaskTrackerApp.Models
{
    /// <summary>
    /// Represents a todo item with a title, status, description, and due date.
    /// </summary>
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? DueDate { get; set; }

        public TaskItem(int id, string title, string description, DateTime? dueDate = null)
        {
            Id = id;
            Title = title;
            Description = description;
            DueDate = dueDate;
            IsCompleted = false;
        }
    }
}
