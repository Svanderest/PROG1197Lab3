using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Queue : IEnumerable<ToDo>
    {
        public Queue(ToDo first)
        {
            First = first;
        }

        public int Count
        {
            get
            {
                int c = 0;
                for (ToDo i = First; i != null; i = i.Next)
                    c++;
                return c;
            }
        }

        public ToDo First { get; private set; }
        public void Enqueue(ToDo item)
        {
            if (First == null)
                First = item;
            else if (item.Priority < First.Priority)
            {
                item.Next = First;
                First = item;
            }
            else
            {
                ToDo i;
                for (i = First; i.Next != null && i.Next.Priority <= item.Priority; i = i.Next) ;
                if (i.Next != null)
                {
                    item.Next = i.Next;
                }
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

        public IEnumerator<ToDo> GetEnumerator()
        {
            return new QueueEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new QueueEnumerator(this);
        }

        public int PriorityCount(string priorityLevel)
        {
            return PriorityCount(Priorities.GetPriority(priorityLevel));
        }

        public int PriorityCount(int priority)
        {
            int i = 0;
            foreach (ToDo t in this)
            {
                if (t.Priority == priority)
                    i++;
            }
            return i;
        }
    }

    public class QueueEnumerator : IEnumerator<ToDo>, IDisposable
    {
        Queue Q;
        public QueueEnumerator(Queue q)
        {
            Q = q;
            Current = null;

        }
        public ToDo Current { get; private set; }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            return;
        }

        public bool MoveNext()
        {
            if (Q.First == null || (Current != null && Current.Next == null))
                return false;
            if (Current == null)
                Current = Q.First;                
            else
                Current = Current.Next;
            return true;
        }

        public void Reset()
        {
            Current = Q.First;
        }
    }
}
