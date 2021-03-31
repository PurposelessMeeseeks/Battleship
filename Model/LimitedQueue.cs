using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class LimitedQueue<T> : Queue<T>
    {
        public LimitedQueue(int lenght)
        {
            this.lenght = lenght;
        }

        public new void Enqueue(T item)
        {
            base.Enqueue(item);
            if (Count > lenght)
                Dequeue(); 
        }

        private int lenght;
    }
}
