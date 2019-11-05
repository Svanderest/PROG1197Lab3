using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Queue
    {
        public Queue(ToDo first)
        {
            First = first;
        }

        public int Count
        {
            get
            {
                if (First == null)
                    return 0;
                else
                {
                    int c = 0;
                    ToDo i = First;
                    while (i.Next != null)
                        c++;
                    return c;
                }
            }
        }
        public ToDo First { get; private set; }
        public void Enqueue(ToDo item)
        {
            if (First == null)
                First = item;
            else
            {
                ToDo i = First;
                while (i.Next != null)
                    i = i.Next;
                i.Next = item;
            }
        }
        public ToDo Dequeue()
        {
            ToDo item = First;
            First = item.Next;
            return item;
        }

        public ToDo Peek()
        {
            return First;
        }

    }
}
