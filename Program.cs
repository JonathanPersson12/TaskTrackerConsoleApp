using System;
using TaskTrackerApp.Services;
using TaskTrackerApp.UI;
using TaskTrackerApp.Data;

namespace TaskTrackerApp
{
    class Program
    {
        private static void Main(string[] args)
        {
            var todoManager = new TodoManager();
            DisplayMenu.ShowMenu(todoManager);
        }
    }
}

