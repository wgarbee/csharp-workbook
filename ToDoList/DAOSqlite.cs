using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ToDoList
{
    // Sqlite DAO 
    public class DAOSqlite : IDAO
    {
        public Context context { get; set; }

        public ToDo taskItem { get; set; }

        // Constructor that instantiates the Context and ensures that the db has been created
        public DAOSqlite()
        {
            context = new Context();
            context.Database.EnsureCreated();
        }

        // Constructs a ToDo item and adds it to the DB
        public void Add(String description, String tag)
        {
            context.tasks.Add(new ToDo(description, tag));
            context.SaveChanges();
        }

        // Deletes the task given an ID
        public void Delete(int id)
        {
            foreach (ToDo task in context.tasks)
            {
                if (task.id == id)
                {
                    context.tasks.Remove(task);
                    // task.lastUpdated = DateTime.Now;
                    context.SaveChanges();

                    ConsoleView.PrintMessage($"Task \"{task.task}\" has been deleted.");
                }
            }
        }

        // Updates the status to completed given an ID
        public void UpdateState(int id)
        {
            foreach (ToDo task in context.tasks)
            {
                if (task.id == id)
                {
                    task.status = ToDoStatus.COMPLETE;
                    // task.lastUpdated = DateTime.Now;
                    context.SaveChanges();

                    ConsoleView.PrintMessage($"Task \"{task.task}\" is now marked {task.status}");

                    break;
                }
            }
        }

        // Allows the user to update a task description given an ID. Takes in a string to update the task description
        public void UpdateTaskDescription(int id, String taskName)
        {
            foreach (ToDo task in context.tasks)
            {
                if (task.id == id)
                {
                    task.task = taskName;
                    // task.lastUpdated = DateTime.Now;   Unsure how I am going to implement this
                    context.SaveChanges();

                    try
                    {
                        if (task.task == taskName)
                        {
                            ConsoleView.PrintMessage($"Task ID {task.id} is now updated with {taskName}.");
                        }
                    }
                    catch
                    {
                        throw new Exception("Error updating task name");
                    }
                }
            }
        }

        // Allows the user to change the the task tag
        public void UpdateTaskTag(int id, String TaskTag)
        {
            foreach (ToDo task in context.tasks)
            {
                if (task.id == id)
                {
                    task.tag = TaskTag;
                    // task.lastUpdated = DateTime.Now;
                    context.SaveChanges();

                    try
                    {
                        if (task.tag == TaskTag)
                        {
                            ConsoleView.PrintMessage($"Task ID {task.id} is now updated with {TaskTag}.");
                        }
                    }
                    catch
                    {
                        throw new Exception("Error updating task name");
                    }
                }
            }
        }

        // Builds a list of all items and returns it
        public String ListTasks()
        {
            String formattedList = "";
            int longestTaskName = context.tasks.First().task.Length;
            int longestTaskTag = context.tasks.First().tag.Length;
            int spacesNeeded;

            // Finds the longest task name length
            foreach (ToDo task in context.tasks)
            {
                if (task.task.Length > longestTaskName)
                {
                    longestTaskName = task.task.Length;
                }
            }

            // Finds the longest task tag length
            foreach (ToDo task in context.tasks)
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
            foreach (ToDo task in context.tasks)
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

        // Builds a list of all items that match the tag entered by the user and returns it
        public String ListTasksByTag(String tag)
        {
            String formattedList = "";
            int longestTaskName = context.tasks.First().task.Length;
            int longestTaskTag = context.tasks.First().tag.Length;
            int spacesNeeded;

            // Finds the longest task name length
            foreach (ToDo task in context.tasks)
            {
                if (task.tag.ToLower() == tag)
                {
                    if (task.task.Length > longestTaskName)
                    {
                        longestTaskName = task.task.Length;
                    }
                    // listByTag.Add(task);
                }
            }

            // Finds the longest task tag length
            foreach (ToDo task in context.tasks)
            {
                if (task.tag.ToLower() == tag)
                {
                    if (task.tag.Length > longestTaskTag)
                    {
                        longestTaskTag = task.tag.Length;
                    }
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
            foreach (ToDo task in context.tasks)
            {
                if (task.tag.ToLower() == tag)
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
            }
            return formattedList;
        }

        public String ListCompletedTasks()
        {
            String formattedList = "";
            int longestTaskName = context.tasks.First().task.Length;
            int longestTaskTag = context.tasks.First().tag.Length;
            int spacesNeeded;

            // Finds the longest task name length
            foreach (ToDo task in context.tasks)
            {
                if (task.status == ToDoStatus.COMPLETE)
                {
                    if (task.task.Length > longestTaskName)
                    {
                        longestTaskName = task.task.Length;
                    }
                }
            }

            // Finds the longest task tag length
            foreach (ToDo task in context.tasks)
            {
                if (task.status == ToDoStatus.COMPLETE)
                {
                    if (task.tag.Length > longestTaskTag)
                    {
                        longestTaskTag = task.tag.Length;
                    }
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
            foreach (ToDo task in context.tasks)
            {
                if (task.status == ToDoStatus.COMPLETE)
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
            }
            return formattedList;
        }
    }
}