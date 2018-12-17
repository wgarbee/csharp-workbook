using System;

namespace ToDoList
{
    // ToDo POCO with properties 
    public class ToDo
    {
        public String task { get; set; }

        public int id { get; private set; }

        public ToDoStatus status { get; set; }

        public String tag { get; set; }

        public DateTime createdDate { get; private set; }

        // public DateTime lastUpdated { get; set; }

        public ToDo()
        {

        }

        public ToDo(String task, String tag)
        {
            this.task = task;
            this.tag = tag;
            // this.id = id;
            status = ToDoStatus.INCOMPLETE;
            createdDate = DateTime.Now;
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
}