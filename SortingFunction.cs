using System;
using System.Collections.Generic;
using System.Linq;
using TaskTrackerApp.Models;

namespace TaskTrackerApp.Services
{
    public static class SortingFunction
    {
        /// <summary>
        /// Sorts the list of tasks by title
        /// </summary>
        /// param name="tasks"> The list of tasks´to sort.</param>
        /// param name="ascending"> The list of tasks´to sort.</param>
        /// <returns>The sorted list  of tasks.</returns>
        public static List<TaskItem> SortByTitle(List<TaskItem> tasks, bool ascending = true)
        {
            return ascending ? tasks.OrderBy(t => t.Title).ToList() : tasks.OrderByDescending(t => t.Title).ToList();
        }

        /// <summary>
        /// Sorts the list of tasks by due date.
        /// </summary>
        /// <param name="tasks">The list of tasks to sort.</param>
        /// <param name="ascending">Whether to sort in ascending order (default is true).</param>
        /// <returns>The sorted list of tasks.</returns>
         
        public static List<TaskItem> SortByDueDate(List<TaskItem> tasks, bool ascending = true)
        {
            return ascending ? tasks.OrderBy(t => t.DueDate).ToList() : tasks.OrderByDescending(t => t.DueDate).ToList();
        }

        /// <summary>
        /// Sorts the list of tasks by completion status.
        /// </summary>
        /// <param name="tasks">The list of tasks to sort.</param>
        /// <param name="ascending">Whether to sort in ascending order (default is true).</param>
        /// <returns>The sorted list of tasks.</returns>
        public static List<TaskItem> SortByCompletionStatus(List<TaskItem> tasks, bool ascending = true)
        {
            return ascending ? tasks.OrderBy(t => t.IsCompleted).ToList() : tasks.OrderByDescending(t => t.IsCompleted).ToList();
        }
    }
}