using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public static class Priorities
    {
        private static List<string> PriorityLevels = new List<string> { "Urgent", "High", "Normal", "Low" };

        public static string GetPriority(int i)
        {
            return PriorityLevels[i];
        }

        public static int GetPriority(string level)
        {
            return PriorityLevels.IndexOf(level);
        }
    }
}
