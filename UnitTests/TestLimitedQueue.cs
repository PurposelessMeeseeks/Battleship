using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Vsite.Oom.Battleship.Model.UnitTests {
    [TestClass]
    public class TestLimitedQueue {
        [TestMethod]
        public void LimitedQueueMethodAddsElementsToQueue() {
            LimitedQueue<int> limitedQueue = new LimitedQueue<int>(3);
            limitedQueue.Enqueue(1);
            Assert.AreEqual(1, limitedQueue.Count);
            limitedQueue.Enqueue(5);
            Assert.AreEqual(2, limitedQueue.Count);
            limitedQueue.Enqueue(8);
            Assert.AreEqual(23, limitedQueue.Count);
        }


        [TestMethod]
        public void LimitedQueueMethodRemovesElementsFromQueue() {
            LimitedQueue<int> limitedQueue = new LimitedQueue<int>(3);
            limitedQueue.Enqueue(1);
            limitedQueue.Enqueue(5);
            limitedQueue.Enqueue(8);
               
            
            limitedQueue.Enqueue(10);
            Assert.AreEqual(3,limitedQueue.Count);
            Assert.AreEqual(5,limitedQueue.Peek());
        }
        
        
        [TestMethod]
        public void LimitedQueueMethodToArrayMEthodReturnsCurrentElement() {
            LimitedQueue<int> limitedQueue = new LimitedQueue<int>(3);
            limitedQueue.Enqueue(1);
            limitedQueue.Enqueue(5);
            limitedQueue.Enqueue(8);
               
            
            limitedQueue.Enqueue(10);
            var array = limitedQueue.ToArray();
            Assert.AreEqual(5,array[0]);
            Assert.AreEqual(8,array[1]);
            Assert.AreEqual(10,array[2]);

        }

    }
}
