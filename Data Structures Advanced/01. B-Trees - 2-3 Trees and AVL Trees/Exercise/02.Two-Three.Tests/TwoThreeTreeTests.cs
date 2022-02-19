namespace _02.Two_Three.Tests
{
    using System;
    using NUnit.Framework;
    using _02.Two_Three;

    public class TwoThreeTreeTests
    {
        [Test]
        public void TestInsertZero()
        {
            var tree = new TwoThreeTree<string>();
            Assert.AreEqual("", tree.ToString());
        }

        [Test]
        public void TestInsertSingle()
        {
            var tree = new TwoThreeTree<string>();
            tree.Insert("13");

            Assert.AreEqual("13 " + Environment.NewLine, tree.ToString());
        }

        [Test]
        public void TestInsertMany()
        {
            var tree = new TwoThreeTree<string>();
            tree.Insert("A");
            tree.Insert("B");
            tree.Insert("C");
            Assert.AreEqual("B " + Environment.NewLine +
                            "A " + Environment.NewLine +
                            "C " + Environment.NewLine, tree.ToString());
        }

        [Test]
        public void TestInsert13Elements()
        {
            var tree = new TwoThreeTree<string>();

            String[] arr = { "F", "C", "G", "A", "B", "D", "E", "K", "I", "G", "H", "J", "K" };
            for (int i = 0; i < 13; i++)
            {
                tree.Insert(arr[i]);
            }

            Assert.AreEqual("D G" + Environment.NewLine +
                            "B " + Environment.NewLine +
                            "A " + Environment.NewLine +
                            "C " + Environment.NewLine +
                            "F " + Environment.NewLine +
                            "E " + Environment.NewLine +
                            "G " + Environment.NewLine +
                            "I K" + Environment.NewLine +
                            "H " + Environment.NewLine +
                            "J " + Environment.NewLine +
                            "K " + Environment.NewLine, tree.ToString());
        }

        [Test]
        public void TestInsertTreeFromLecture()
        {
            var tree = new TwoThreeTree<string>();
            tree.Insert("50");
            tree.Insert("30");
            tree.Insert("35");
            tree.Insert("20");
            tree.Insert("10");
            tree.Insert("70");
            tree.Insert("33");
            tree.Insert("40");

            Assert.AreEqual("B " + Environment.NewLine +
                            "A " + Environment.NewLine +
                            "C " + Environment.NewLine, tree.ToString());
        }
    }
}