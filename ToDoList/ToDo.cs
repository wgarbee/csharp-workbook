using System;

namespace ToDoList
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiates the ToDo list program
            ToDoController ToDoListProgram = new ToDoController();

            // Calls the MainController method on the TDLP instance
            ToDoListProgram.MainController();
        }
    }
}