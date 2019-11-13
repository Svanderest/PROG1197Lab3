using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    interface IQueue<T>
    {
        T Peek();
        void Enqueue(T item);
        T Dequeue();
    }
}
