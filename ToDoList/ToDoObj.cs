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

        // Still trying to determine how to deploy this whne a db has already been created
        // public DateTime lastUpdated { get; set; }

        // Constructor for the DOA Sqlite
        public ToDo(String task, String tag)
        {
            this.task = task;
            this.tag = tag;
            status = ToDoStatus.INCOMPLETE;
            createdDate = DateTime.Now;
        }

        // Constructor for the DOA In Memory
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