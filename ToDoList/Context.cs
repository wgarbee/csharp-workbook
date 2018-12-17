using System;
using Microsoft.EntityFrameworkCore;

namespace ToDoList
{
    public class Context : DbContext
    {
        public DbSet<ToDo> tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./tasks.db");
        }
    }
}