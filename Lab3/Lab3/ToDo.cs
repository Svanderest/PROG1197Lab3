using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class ToDo
    {
        public string Description { get; set; }
        public int Priority { get; set; }
        public string PriorityLevel
        {
            get
            {
                return Priorities.GetPriority(Priority);
            }
        }
        public ToDo Next { get; set; }

        public ToDo(string description, int priority)
        {
            Description = description;
            Priority = priority;
        }

        public ToDo(string description, string priorityLevel)
        {
            Description = description;
            Priority = Priorities.GetPriority(priorityLevel);
        }
    }
}
