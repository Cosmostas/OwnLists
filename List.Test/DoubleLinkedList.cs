using NUnit.Framework;
using OwnList;
using OwnList.DoubleLinkedList;
using System;

namespace List.Test
{
    public class DoubleLinkedList
    {

        [TestCase(1)]
        public void ToString(int a)
        {
            DoubleLinkedList<int> V = new DoubleLinkedList<int>(new int[] { 12,3,4,6});

            Assert.AreEqual(V._tail, V.GetNode(3));
        }


        [TestCase(new int[] { 5 }, 1)]
        [TestCase(new int[] { 5, 3 }, 4)]
        [TestCase(new int[] { 5, 3, 1, 6, 9, 0, -1, 3 }, 5)]
        [TestCase(new int[] { 5, 3, 1, 6, 9, 0, -1, 3, -5 }, 6)]

        public void Sort(int[] actualArr, int numExpectedMoq)
        {
            DoubleLinkedList<int> expected = DoubleLinkedListMoq(numExpectedMoq);
            DoubleLinkedList<int> actual = new DoubleLinkedList<int>(actualArr);
            actual.Sort(actual._head, actual._tail, actual._length);

            Assert.AreEqual(expected, actual);
        }

        public DoubleLinkedList<int> DoubleLinkedListMoq(int numMoq)
        {
            switch (numMoq)
            {
                case 0:
                    return new DoubleLinkedList<int>();
                case 1:
                    return new DoubleLinkedList<int>(5);
                case 2:
                    return new DoubleLinkedList<int>(new int[] { 1, 6, -1, 0, 123 });
                case 3:
                    return new DoubleLinkedList<int>(new int[] { 5, 3 });
                case 4:
                    return new DoubleLinkedList<int>(new int[] { 3, 5 });
                case 5:
                    return new DoubleLinkedList<int>(new int[] { -1, 0, 1, 3, 3, 5, 6, 9 });
                case 6:
                    return new DoubleLinkedList<int>(new int[] { -5, -1, 0, 1, 3, 3, 5, 6, 9 });
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}  