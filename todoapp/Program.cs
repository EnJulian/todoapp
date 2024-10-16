using System;
using System.Collections.Generic;
using System.IO;

namespace todoapp
{
    /// <summary>
    /// Main program for the todo list application.
    /// </summary>
    class Program
    {
        /// <summary>
        /// List of tasks.
        /// </summary>
        static List<string> tasks = new List<string>();

        /// <summary>
        /// Main entry point for the application.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        static void Main(string[] args)
        {
            LoadTasks();

            // Loop until the user chooses to exit.
            while (true)
            {
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. Remove Task");
                Console.WriteLine("3. View Tasks");
                Console.WriteLine("4. Exit");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        RemoveTask();
                        break;
                    case "3":
                        ViewTasks();
                        break;
                    case "4":
                        SaveTasks();
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        /// <summary>
        /// Adds a new task to the list.
        /// </summary>
        static void AddTask()
        {
            Console.Write("Enter task: ");
            var task = Console.ReadLine();
            tasks.Add(task);
            Console.WriteLine("Task added!");
        }

        /// <summary>
        /// Removes a task from the list.
        /// </summary>
        static void RemoveTask()
        {
            ViewTasks();
            Console.Write("Enter task number to remove: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tasks.Count)
            {
                tasks.RemoveAt(index - 1);
                Console.WriteLine("Task removed!");
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }
        }

        /// <summary>
        /// Displays all tasks in the list.
        /// </summary>
        static void ViewTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks available.");
                return;
            }

            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }

        /// <summary>
        /// Loads tasks from a file.
        /// </summary>
        static void LoadTasks()
        {
            if (File.Exists("tasks.txt"))
            {
                tasks.AddRange(File.ReadAllLines("tasks.txt"));
            }
        }

        /// <summary>
        /// Saves tasks to a file.
        /// </summary>
        static void SaveTasks()
        {
            File.WriteAllLines("tasks.txt", tasks);
        }
    }
}
