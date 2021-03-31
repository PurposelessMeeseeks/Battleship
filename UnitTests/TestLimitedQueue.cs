using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Vsite.Oom.Battleship.Model.UnitTests
{
    [TestClass]
    public class TestLimitedQueue
    {
        [TestMethod]
        public void LimitedQueueEnqueueMethodAddsElementsToQueue()
        {

            LimitedQueue<int> lq = new LimitedQueue<int>(3);

            lq.Enqueue(1);
            Assert.AreEqual(1, lq.Count);
            lq.Enqueue(5);
            Assert.AreEqual(2, lq.Count);
            lq.Enqueue(8);
            Assert.AreEqual(3, lq.Count);
        }

        [TestMethod]
        public void LimitedQueueEnqueueMethodDequeuesElementsFromQueue()
        {

            LimitedQueue<int> lq = new LimitedQueue<int>(3);

            lq.Enqueue(1);            
            lq.Enqueue(5);            
            lq.Enqueue(8);
            lq.Enqueue(10);
            Assert.AreEqual(3, lq.Count);
            Assert.AreEqual(5, lq.Peek());
        }

        [TestMethod]
        public void LimitedQueueEnqueueMethodReturnsCurrentElements()
        {
            LimitedQueue<int> lq = new LimitedQueue<int>(3);

            lq.Enqueue(1);
            lq.Enqueue(5);
            lq.Enqueue(8);
            lq.Enqueue(10);

            var array = lq.ToArray();
            Assert.AreEqual(5, array);
            Assert.AreEqual(5, lq.Peek());
        }
    }
}
