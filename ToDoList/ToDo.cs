using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace ToDoList
{
    public enum ToDoStatus
    {
        COMPLETE,
        INCOMPLETE
    }

    class Program
    {
        static void Main(string[] args)
        {
            ToDoController ToDoListProgram = new ToDoController();

            ToDoListProgram.MainController();
        }
    }
}