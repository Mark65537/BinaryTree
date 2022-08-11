using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Tree;

namespace BinaryTreeTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // строки для глубины и ширины
            string depthExpected = "10 9 5 4 6 7 11 12 13 14 ";   
            string breadthExpected = "10 9 11 5 12 4 6 13 7 14 ";            
            BinaryTree<int> tree = new BinaryTree<int>(10);
            //заполнение дерева
             tree.add(9);
             tree.add(11);
             tree.add(12);
             tree.add(13);
             tree.add(14);
             tree.add(5);
             tree.add(6);
             tree.add(7);
             tree.add(4);
            //конец заполнения дерева
            Assert.AreEqual(depthExpected, tree.WalkInDepth());
            Assert.AreEqual(breadthExpected, tree.WalkInBreadth());
        }
    }
}

namespace Tree
{
    public class BinaryTree<T> where T : IComparable<T>
    {
        private T Value;
        private BinaryTree<T> Left;
        private BinaryTree<T> Right;
        private StringBuilder strToPrint = new StringBuilder();
        public BinaryTree(T val)
        {
            Value = val;
        }
        public void add(T val)
        {
            if (val.CompareTo(Value) < 0)
            {
                if (Left == null)
                {
                    Left = new BinaryTree<T>(val);
                }
                else if (Left != null)
                    Left.add(val);
            }
            else
            {
                if (Right == null)
                {
                    Right = new BinaryTree<T>(val);
                }
                else if (Right != null)
                    Right.add(val);
            }
        }
        private void _walkInDepth(BinaryTree<T> node)
        {
            strToPrint.Append(node.Value.ToString());
            strToPrint.Append(" ");
            if (node.Left != null)
                _walkInDepth(node.Left);
            if (node.Right != null)
                _walkInDepth(node.Right);           
        }

        /// <summary>
        /// Проход по дереву "в глубину"(preorder)
        /// </summary>
        public string WalkInDepth()
        {
            strToPrint.Clear();
            _walkInDepth(this);
            return strToPrint.ToString();
        }

        /// <summary>
        /// Проход по дереву "в ширину"
        /// </summary>
        public string WalkInBreadth()
        {
            strToPrint.Clear();
            Queue<BinaryTree<T>> steps = new Queue<BinaryTree<T>>();
            BinaryTree<T> step;
            steps.Enqueue(this);
            while (steps.Count > 0)
            {
                step = steps.Dequeue();
                if(step.Left != null)
                    steps.Enqueue(step.Left);
                if(step.Right != null)
                    steps.Enqueue(step.Right);
                strToPrint.Append(step.Value);
                strToPrint.Append(" ");
            }
            return strToPrint.ToString();
        }
    }
}
