using System;
using System.Threading;

namespace ToDoList
{
    // This controlls the accessing and passing of data from the List (eventually db) to the user/console
    public class ToDoController
    {
        public IDAO dao { get; set; }

        public ToDoController()
        {
            dao = new DAOSqlite();
        }

        // Controls the interaction between the user (in ConsoleView) and the DAO
        public void MainController()
        {
            int menuSelection = 0;

            do
            {
                try
                {
                    menuSelection = ConsoleView.MainMenu();

                    if (menuSelection == 1)  // If 1, user can enter a new task
                    {
                        String description = ConsoleView.TaskDescription();
                        String tag = ConsoleView.TaskTag();
                        dao.Add(description, tag);
                    }
                    else if (menuSelection == 2)  // If 2, user gets a list of tasks
                    {
                        ConsoleView.ListTasks(dao.ListTasks());
                    }
                    else if (menuSelection == 3)  // If 3, user can delete a task
                    {
                        int taskID = ConsoleView.DeleteTask(dao.ListTasks());
                        dao.Delete(taskID);
                    }
                    else if (menuSelection == 4)  // If 4, user can complete a task
                    {
                        int taskID = ConsoleView.MarkComplete(dao.ListTasks());
                        dao.UpdateState(taskID);
                    }
                    else if (menuSelection == 5)  // if 5, user can update a task description
                    {   // Should I have one method to get a task ID that passes a message specifically for that need, like this one?
                        int taskID = ConsoleView.SelectTaskToUpdate(dao.ListTasks(), "Please enter a task ID to update");
                        String newTaskDescription = ConsoleView.TaskDescription();

                        dao.UpdateTaskDescription(taskID, newTaskDescription);
                    }
                    else if (menuSelection == 6)  // If 6, customer can update a tag
                    {
                        int taskID = ConsoleView.SelectTaskToUpdate(dao.ListTasks(), "Please enter a task ID to update");
                        String newTaskTag = ConsoleView.TaskDescription();

                        dao.UpdateTaskTag(taskID, newTaskTag);
                    }
                    else if (menuSelection == 7)  // Lists by task tag
                    {
                        String taskID = ConsoleView.ListTasksByTag();
                        ConsoleView.ListTasks(dao.ListTasksByTag(taskID));
                    }
                    else if (menuSelection == 8)  // Lists complete
                    {
                        ConsoleView.ListCompletedTasks(dao.ListCompletedTasks());
                    }
                }
                catch
                {
                    ConsoleView.PrintMessage("Invalid input");
                }

            }while(menuSelection != 9);

            Console.Clear();
        }
    }
}