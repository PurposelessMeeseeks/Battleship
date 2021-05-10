using System.Collections.Generic;

namespace Vsite.Oom.Battleship.Model
{
    internal class LimitedQueue<T> : Queue<T>
    {
        public LimitedQueue(int lenght)
        {
            this.lenght = lenght;
        }

        public new void Enqueue (T item)
        {
            base.Enqueue(item);
            if (Count > lenght)
                Dequeue();
        }
        private int lenght;
    }
}