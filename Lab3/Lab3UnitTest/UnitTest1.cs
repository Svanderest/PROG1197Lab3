using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab3;

namespace Lab3UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private Queue MakeQueue()
        {            
            Queue q = new Queue(new ToDo("Watch Movie", "Normal"));
            q.Enqueue(new ToDo("Eat lunch", "Normal"));
            q.Enqueue(new ToDo("Put out fire", "Urgent"));
            q.Enqueue(new ToDo("Stop robbery", "High"));
            q.Enqueue(new ToDo("Dust bookshelf", "Low"));
            q.Enqueue(new ToDo("Finish Lab 3", "High"));
            q.Enqueue(new ToDo("Brush teeth", "Normal"));
            q.Enqueue(new ToDo("Weed garden", "Low"));
            return q;
        }

        [TestMethod]
        public void TestFirst()
        {
            //Arrange
            Queue target = MakeQueue();

            //Act
            string Expected = "Put out fire";
            string Actual = target.First.Description;

            //Assert
            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void TestPeek()
        {
            //Arrange
            Queue target = MakeQueue();

            //Act
            string Expected = "Put out fire";
            string Actual = target.Peek().Description;            

            //Assert
            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void TestUrgent()
        {
            //Arrange
            Queue target = MakeQueue();

            //Act
            int Expected = 1;
            int Actual = target.PriorityCount("Urgent");

            //Assert
            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void TestHigh()
        {
            //Arrange
            Queue target = MakeQueue();

            //Act
            int Expected = 2;
            int Actual = target.PriorityCount("High");

            //Assert
            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void TestNormal()
        {
            //Arrange
            Queue target = MakeQueue();

            //Act
            int Expected = 3;
            int Actual = target.PriorityCount("Normal");

            //Assert
            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void TestLow()
        {
            //Arrange
            Queue target = MakeQueue();

            //Act
            int Expected = 2;
            int Actual = target.PriorityCount("Low");

            //Assert
            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void TestCount()
        {
            //Arrange
            Queue target = MakeQueue();

            //Act
            int Expected = 8;
            int Actual = target.Count;

            //Assert
            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void TestOrder()
        {
            //Arrange
            Queue target = MakeQueue();

            //Act
            bool condition = true;
            foreach (ToDo t in target)
                condition = condition && (t.Next == null || t.Priority <= t.Next.Priority);

            //Assert
            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void TestClear()
        {
            //Arrange
            Queue target = MakeQueue();
            target.Clear();

            //Act
            int expected = 0;
            int actual = target.Count;

            //Assert
            Assert.AreEqual(expected, actual);

        }
    }
}
