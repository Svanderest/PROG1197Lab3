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
        public string Priority { get; set; }
        public ToDo Next { get; set; }
    }
}
