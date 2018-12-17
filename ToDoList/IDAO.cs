using System;

namespace ToDoList
{
    public interface IDAO
    {
        void Add(String description, String tag);

        void Delete(int id);

        void UpdateState(int id);

        void UpdateTaskDescription(int id, String taskName);

        void UpdateTaskTag(int id, String taskName);

        String ListTasks();

        String ListTasksByTag(String Tag);
    }
}