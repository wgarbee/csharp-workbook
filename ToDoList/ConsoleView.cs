using System;
using System.Threading;

namespace ToDoList
{
        public static class ConsoleView
    {
        // Displays the main menu
        public static int MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Wes' ToDo List!");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Enter the number for the action you wish to take");
            Console.WriteLine("1. Add task");
            Console.WriteLine("2. List tasks");
            Console.WriteLine("3. Delete task");
            Console.WriteLine("4. Mark task complete");
            Console.WriteLine("5. Update task name");
            Console.WriteLine("6. Update task tag");
            Console.WriteLine("7. List by task tag");
            Console.WriteLine("8. Exit");
            
            return Convert.ToInt32(Console.ReadLine());
        }

        // Adds a task description/name
        public static String TaskDescription()
        {
            Console.Clear();
            Console.WriteLine("Please enter a task description:");
            return Console.ReadLine();
        }

        // Adds a task tag
        public static String TaskTag()
        {
            Console.WriteLine("Please enter a task tag:");
            return Console.ReadLine();
        }

        // Displays a formatted view of the list of tasks
        public static void ListTasks(String list)
        {
            Console.Clear();
            Console.WriteLine(list);

            Console.WriteLine("Press enter to return to the main menu.");
            Console.ReadLine();
        }

        // Prompts to delete a task ID provided by user
        public static int DeleteTask(String list)
        {
            Console.Clear();
            Console.WriteLine(list);

            Console.WriteLine("Select the task ID you wish to delete:");
            return Convert.ToInt32(Console.ReadLine());
        }

        // Prompts to update the status of a task ID provided by user
        public static int MarkComplete(String list)
        {
            Console.Clear();
            Console.WriteLine(list);
            
            Console.WriteLine("Select the task ID you wish to mark complete:");
            return Convert.ToInt32(Console.ReadLine());
        }

        public static int SelectTaskToUpdate(String list, String message)
        {
            Console.Clear();
            Console.WriteLine(list);

            Console.WriteLine(message);
            return Convert.ToInt32(Console.ReadLine());
        }

        // Displays a formatted view of the list of tasks by tag name
        public static String ListTasksByTag()
        {
            Console.Clear();
            Console.WriteLine("What tag do you want to filter by?");
            return Console.ReadLine().ToLower();
        }

        // Can be called to print a message that's passed to it
        public static void PrintMessage(String message)
        {
            Thread.Sleep(500);
            Console.WriteLine(message);
            Thread.Sleep(1500);
        }
    }
}