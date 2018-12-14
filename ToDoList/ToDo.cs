using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace ToDoList
{
    public enum ToDoStatus
    {
        COMPLETE,
        INCOMPLETE
    }

    public interface IDAO
    {
        void Add(String description, String tag);

        void Delete(int id);

        void UpdateState(int id);

        String ListTasks();
    }

    class Program
    {
        static void Main(string[] args)
        {
            ToDoController ToDoListProgram = new ToDoController();

            ToDoListProgram.MainController();
        }
    }

    public class DAOSqlite : IDAO
    {
        public DAOSqlite()
        {

        }

        public void Add(String description, String Tag)
        {

        }

        public void Delete(int id)
        {

        }

        public void UpdateState(int id)
        {

        }

        public String ListTasks()
        {
            String formattedList = "";

            return formattedList;
        }
    }

    public class DAOInMemory : IDAO
    {
        public List<ToDo> ToDos { get; set; }

        public ToDo taskItem { get; set; }

        public static int taskNumber = 1;

        public DAOInMemory()
        {
            ToDos = new List<ToDo>();
        }

        public void Add(String description, String tag)
        {
            taskItem = new ToDo(description, taskNumber, tag);
            ToDos.Add(taskItem);
            taskNumber++;
        }

        public void Delete(int id)
        {
            foreach (ToDo task in ToDos)
            {
                if (task.id == id)
                {
                    ToDos.Remove(task);
                    break;
                }
            }
        }

        public void UpdateState(int id)
        {
            foreach (ToDo task in ToDos)
            {
                if (task.id == id)
                {
                    task.status = ToDoStatus.COMPLETE;
                    break;
                }
            }
        }

        public String ListTasks()
        {
            String formattedList = "";
            int longestTaskName = ToDos.First().task.Length;
            int longestTaskTag = ToDos.First().tag.Length;
            int spacesNeeded;

            // Finds the longest task name length
            foreach (ToDo task in ToDos)
            {
                if (task.task.Length > longestTaskName)
                {
                    longestTaskName = task.task.Length;
                }
            }

            // Finds the longest task tag length
            foreach (ToDo task in ToDos)
            {
                if (task.tag.Length > longestTaskTag)
                {
                    longestTaskTag = task.tag.Length;
                }
            }

            // Builds the header string
            formattedList += " ID | Task" + new string(' ', longestTaskName) + "| Tag" + new string(' ', longestTaskTag) + "| Status      | Created Date" + "\n";
            int headerLength = formattedList.Length;

            // Builds the line below the header
            for (int i = 0; i < headerLength; i++)
            {
                formattedList += "-";
            }

            formattedList += "\n";

            // Loops through the list of ToDo task objects
            foreach (ToDo task in ToDos)
            {
                // Adds the task ID
                formattedList += " " + task.id;
                formattedList += task.id < 10 ? "  |" : " |";  // If the id is less than 10, adds 2 spaces, else 1 and then a pipe

                // If the task is longest, adds to the string with 4 extra spaces
                if (task.task.Length == longestTaskName)
                {
                    formattedList += " " + task.task + new string(' ', 4) + "|";
                }
                else  // If shorter than longest, determines how many spaces are needed to continue to build table
                {
                    spacesNeeded = longestTaskName - task.task.Length;
                    formattedList += " " + task.task + new string(' ', spacesNeeded + 4) + "|";
                }

                // If the tag is longest, adds to the string with 4 extra spaces
                if (task.tag.Length == longestTaskTag)
                {
                    formattedList += " " + task.tag + new string(' ', 3) + "|";
                }
                else  // If shorter than longest, determines how many spaces are needed to continue to build table
                {
                    spacesNeeded = longestTaskTag - task.tag.Length;
                    formattedList += " " + task.tag + new string(' ', spacesNeeded + 3) + "|";
                }

                // Continues to construct the string based on whether the status is incomplete...
                if (task.status == ToDoStatus.INCOMPLETE)
                {
                    formattedList += " " + task.status + "  |  " + task.createdDate + "\n";
                }
                else  // ...or complete
                {
                    formattedList += " " + task.status + "    |  " + task.createdDate + "\n";
                }
            }

            return formattedList;
        }
    }

    // ToDo POCO with properties 
    public class ToDo
    {
        public String task { get; set; }

        public int id { get; private set; }

        public ToDoStatus status { get; set; }

        public String tag { get; private set; }

        public DateTime createdDate { get; private set; }

        public ToDo()
        {

        }

        public ToDo(String task, int id, String tag)
        {
            this.task = task;
            this.tag = tag;
            this.id = id;
            status = ToDoStatus.INCOMPLETE;
            createdDate = DateTime.Now;
        }
    }

    // This controlls the accessing and passing of data from the List (eventually db) to the user/console
    public class ToDoController
    {
        public IDAO dao { get; set; }

        public ConsoleView newConsole { get; set; }

        public ToDoController()
        {
            dao = new DAOInMemory();
            newConsole = new ConsoleView();
        }

        // Controls the interaction between the user (in ConsoleView) and the DAO
        public void MainController()
        {
            int menuSelection = 0;

            do
            {
                try
                {
                    menuSelection = newConsole.MainMenu();

                    if (menuSelection == 1)
                    {
                        String description = newConsole.AddTaskDescription();
                        String tag = newConsole.AddTaskTag();
                        dao.Add(description, tag);
                    }
                    else if (menuSelection == 2)
                    {
                        newConsole.ListTasks(dao.ListTasks());
                    }
                    else if (menuSelection == 3)
                    {
                        int taskID = newConsole.DeleteTask();
                        dao.Delete(taskID);
                    }
                    else if (menuSelection == 4)
                    {
                        int taskID = newConsole.MarkComplete();
                        dao.UpdateState(taskID);
                    }
                }
                catch
                {
                    newConsole.PrintMessage("Invalid input");
                }

            }while(menuSelection != 6);

            Console.Clear();
        }
    }

    public class ConsoleView
    {
        public ConsoleView()
        {

        }

        // Displays the main menu
        public int MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Wes' ToDo List!");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Enter the number for the action you wish to take");
            Console.WriteLine("1. Add task");
            Console.WriteLine("2. List tasks");
            Console.WriteLine("3. Delete task");
            Console.WriteLine("4. Mark task complete");
            // Console.WriteLine("5. Update task");
            Console.WriteLine("6. Exit");
            
            return Convert.ToInt32(Console.ReadLine());
        }

        // Adds a task description/name
        public String AddTaskDescription()
        {
            Console.Clear();
            Console.WriteLine("Please enter a task description:");
            return Console.ReadLine();
        }

        // Adds a task tag
        public String AddTaskTag()
        {
            Console.WriteLine("Please enter a task tag:");
            return Console.ReadLine();
        }

        // Displays a formatted view of the list of tasks
        public void ListTasks(String list)
        {
            Console.Clear();
            Console.WriteLine(list);

            Console.WriteLine("Press enter to return to the main menu.");
            Console.ReadLine();
        }

        // Prompts to delete a task ID provided by user
        public int DeleteTask()
        {
            Console.Clear();
            Console.WriteLine("Select the task ID you wish to delete:");
            return Convert.ToInt32(Console.ReadLine());
        }

        // Prompts to update the status of a task ID provided by user
        public int MarkComplete()
        {
            Console.Clear();
            Console.WriteLine("Select the task ID you wish to mark complete:");
            return Convert.ToInt32(Console.ReadLine());
        }

        // Can be called to print a message that's passed to it
        public void PrintMessage(String message)
        {
            Console.WriteLine(message);
        }
    }
}
