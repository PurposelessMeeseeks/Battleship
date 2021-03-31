using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class LimitedQueue<T> : Queue<T>
    {

        private readonly int Length;

        public LimitedQueue(int length)
        {
            Length = length;
        }

        public new void Enqueue(T item)
        {
            base.Enqueue(item);
            if (base.Count > Length)
            {
                Dequeue();
            }
        }


    }
}
