using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Task> Tasks { get; set; } = new List<Task>();

        public bool CanAssignTask(Task task)
        {
            if (Name == "John")
                return false;

            if (Name == "Steve")
                return true;

            if (Tasks.Count < 3 && !Tasks.Contains(task))
                return true;

            return false;
        }

        public void AssignTask(Task task)
        {
            if (CanAssignTask(task))
                Tasks.Add(task);
        }
    }
}

