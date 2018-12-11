using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

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
            Console.WriteLine("Hi!");

            ToDoController ToDoListProgram = new ToDoController();

            ToDoListProgram.MainController();
        }
    }

    public class ToDoDAOInMemory : IDAO
    {
        public List<ToDo> ToDos { get; set; }

        public ToDo taskItem;

        public static int taskNumber = 1;

        public ToDoDAOInMemory()
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
            int longestTaskName = taskItem.task.Length;
            int longestTaskTag = taskItem.tag.Length;
            String taskEmptySpaces = "";
            String tagEmptySpaces = "";

            foreach (ToDo task in ToDos)
            {
                if (task.task.Length > longestTaskName)
                {
                    longestTaskName = task.task.Length;
                }
            }

            foreach (ToDo task in ToDos)
            {
                if (taskItem.tag.Length > longestTaskTag)
                {
                    longestTaskTag = taskItem.tag.Length;
                }
            }

            formattedList += " ID |  Task  ";

            for (int i = 0; i < longestTaskName; i++)
            {
                taskEmptySpaces += " ";
                formattedList += " ";
            }

            formattedList += "|  Tag  ";

            for (int i = 0; i < longestTaskTag; i++)
            {
                tagEmptySpaces += " ";
                formattedList += " ";
            }

            formattedList += "|  Status    |  Created Date\n";

            for (int i = 0; i < (longestTaskName + longestTaskTag + 55); i++)
            {
                formattedList += "-";
            }

            formattedList += "\n";

            foreach (ToDo task in ToDos)
            {
                formattedList += " " + task.id + "  |  " + task.task + taskEmptySpaces + "  |  " + task.tag + tagEmptySpaces + "  |  " + task.status + "  |  " + task.createdDate + "\n";
            }

            return formattedList;
        }
    }

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

    // This controlls the accessing and passing of data around the program
    public class ToDoController
    {
        public ToDoDAOInMemory dao { get; set; }

        public ConsoleView newConsole { get; set; }

        public ToDoController()
        {
            dao = new ToDoDAOInMemory();
            newConsole = new ConsoleView();
        }

        // Conntrols the interaction between the user (in ConsoleView) and the ToDoDAO
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
        }
    }

    public class ConsoleView
    {
        public ConsoleView()
        {

        }

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

        public String AddTaskDescription()
        {
            Console.Clear();
            Console.WriteLine("Please enter a task description:");
            return Console.ReadLine();
        }

        public String AddTaskTag()
        {
            // Console.Clear();
            Console.WriteLine("Please enter a task tag:");
            return Console.ReadLine();
        }

        public void ListTasks(String list)
        {
            Console.Clear();
            Console.WriteLine(list);

            Console.WriteLine("Press enter to return to the main menu.");
            Console.ReadLine();
        }

        public int DeleteTask()
        {
            Console.Clear();
            Console.WriteLine("Select the task ID you wish to delete:");
            return Convert.ToInt32(Console.ReadLine());
        }

        public int MarkComplete()
        {
            Console.Clear();
            Console.WriteLine("Select the task ID you wish to mark complete:");
            return Convert.ToInt32(Console.ReadLine());
        }

        public void PrintMessage(String message)
        {
            Console.WriteLine(message);
        }
    }
}
