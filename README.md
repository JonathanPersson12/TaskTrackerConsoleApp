# TaskTrackerConsoleApp

A simple **To-Do List Console Application** built in **C#** that allows users to manage tasks efficiently using a simple text-based interface.

## Features

✅ Add new tasks\
✅ Edit existing tasks\
✅ Mark tasks as done\
✅ Remove tasks\
✅ Sort tasks by Title, Due date, Completion \
✅ Save and load tasks from a JSON file

## Project Structure in VS Community

```
TaskMasterConsoleApp/                     # Main project folder
├── TaskMasterConsoleApp.sln              # Solution file
│
├── TaskMasterApp/                        # Main application
│   ├── Program.cs                        # Entry point
│   ├── Models/                           # Data models
│   │   ├── TaskItem.cs                   # Defines a task (Title, DueDate, Status, Project)
│   ├── Services/                         # Core logic
│   │   ├── TodoManager.cs                # Handles task operations
│   │   └── SortingFunction.cs            # Sorts tasks
│   ├── UI/                               # User interface
│   │   └── DisplayMenu.cs                # Displays menu and handles input
│   ├── Data/                             # File storage
│   │   └── FileHandler.cs                # Saves and loads tasks
│
├── .gitignore                            # Ignore unnecessary files
├── README.md                             # Project documentation
```

## Installation

### Prerequisites

- Install a version of Visual Studio Community that as .NET 8.0 or later

### Steps

1. Clone the repository:
   ```sh
   git clone https://github.com/yourusername/TaskMasterConsoleApp.git
   ```
2. Navigate to the project folder in VS using terminal or open the TaskTrackerConsoleApp.sln inside the folder:
   ```sh
   cd TaskMasterConsoleApp/TaskMasterApp
   ```
4. Run the application using dotnet run in terminal or press F5 in VS Community:
   ```sh
   dotnet run
   ```

## Contributing

Feel free to fork this project and submit pull requests with improvements or new features!

