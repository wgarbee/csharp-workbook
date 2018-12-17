using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ToDoList
{
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

        public void UpdateTaskDescription(int id, String taskName)
        {
            foreach (ToDo task in ToDos)
            {
                if (task.id == id)
                {
                    task.task = taskName;
                }
            }
        }

        public void UpdateTaskTag(int id, String taskTag)
        {

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

        public String ListTasksByTag(String tag)
        {
            return "";
        }
    }
}