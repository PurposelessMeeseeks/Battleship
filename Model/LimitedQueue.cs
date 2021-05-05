﻿using System.Collections.Generic;

namespace Vsite.Oom.Battleship.Model
{
    public class LimitedQueue<T> : Queue<T>
    {
        public LimitedQueue(int length)
        {
            this.length = length;
        }

        public new void Enqueue(T item)
        {
            base.Enqueue(item);
            if (Count > length)
                Dequeue();
        }

        private int length;
    }
}