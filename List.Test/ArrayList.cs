using NUnit.Framework;
using OwnList;
using System;
namespace List.Test
{
    public class ArrayList
    {

        [TestCase(1, new int[] { 2 }, 1)]
        [TestCase(4, new int[] { 2, 1, 2, 3, 3 }, 2)]
        [TestCase(-1, new int[] { 2, -1, 0, 0, -2 }, 3)]

        public void PushBack(int value, int[] actualArr, int numArrayListMoq)
        {
            OwnList.ArrayList<int> expected = ArrayListMoq(numArrayListMoq);
            OwnList.ArrayList<int> actual = new OwnList.ArrayList<int>(actualArr);
            actual.PushBack(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] {2, 1}, new int[] {}, 1)]
        [TestCase(new int[] {3, 3, 4}, new int[] { 2, 1, 2}, 2)]
        [TestCase(new int[] { 0, -2, -1 }, new int[] { 2, -1, 0}, 3)]
        public void PushBack(int[] inputArr, int[]actualArr, int numArrayListMoq)
        {
            OwnList.ArrayList<int> expected = ArrayListMoq(numArrayListMoq);
            OwnList.ArrayList<int> actual = new OwnList.ArrayList<int>(actualArr);
            actual.PushBack(inputArr);
            Assert.AreEqual(expected, actual);
        }
         
        [TestCase(2, 0, new int[] { 1 }, 1)]
        [TestCase(4, 5, new int[] { 2, 1, 2, 3, 3 },  2)]
        [TestCase(0, 3, new int[] { 2, -1, 0, -2, -1},  3)]

        public void PushPos(int value, int pos, int[] actualArr, int numArrayListMoq)
        {
            OwnList.ArrayList<int> expected = ArrayListMoq(numArrayListMoq);
            OwnList.ArrayList<int> actual = new OwnList.ArrayList<int>(actualArr);
            actual.PushPos(value, pos);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] {2, 1}, 0, new int[] { }, 1)]
        [TestCase(new int[] {3, 3, 4}, 3, new int[] { 2, 1, 2},  2)]
        [TestCase(new int[] {-1, 0, 0}, 1, new int[] { 2, -2, -1},  3)]

        public void PushPos(int[] inputArr, int pos, int[] actualArr, int numArrayListMoq)
        {
            OwnList.ArrayList<int> expected = ArrayListMoq(numArrayListMoq);
            OwnList.ArrayList<int> actual = new OwnList.ArrayList<int>(actualArr);
            actual.PushPos(inputArr, pos);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, new int[] { 1 }, 1)]
        [TestCase(2, new int[] { 1, 2, 3, 3,4 }, 2)]
        [TestCase(2, new int[] { -1, 0, 0, -2, -1 }, 3)]

        public void PushFront(int value, int[] actualArr, int numArrayListMoq)
        {
            OwnList.ArrayList<int> expected = ArrayListMoq(numArrayListMoq);
            OwnList.ArrayList<int> actual = new OwnList.ArrayList<int>(actualArr);
            actual.PushFront(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 2, 1 }, new int[] { }, 1)]
        [TestCase(new int[] { 2, 1, 2 }, new int[] { 3, 3, 4 }, 2)]
        [TestCase(new int[] { 2, -1, 0 }, new int[] { 0, -2, -1 }, 3)]
        public void PushFront(int[] inputArr, int[] actualArr, int numArrayListMoq)
        {
            OwnList.ArrayList<int> expected = ArrayListMoq(numArrayListMoq);
            OwnList.ArrayList<int> actual = new OwnList.ArrayList<int>(actualArr);
            actual.PushFront(inputArr);
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 2, 1, 3},  1)]
        [TestCase(new int[] { 2, -1, 0, 0, -2, -1, 0 }, 3)]
        public void PopBack(int[] actualArr, int numArrayListMoq)
        {
            OwnList.ArrayList<int> expected = ArrayListMoq(numArrayListMoq);
            OwnList.ArrayList<int> actual = new OwnList.ArrayList<int>(actualArr);
            actual.PopBack();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void NegativePopBack(int[] actualArr)
        {
            try
            {
                OwnList.ArrayList<int> actual = new OwnList.ArrayList<int>(actualArr);
                actual.PopBack();
            }
            catch
            {
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(new int[] {0, 2, 1},  0, 1)]
        [TestCase(new int[] { 2, 1, 123,2, 3, 3, 4 },  2, 2)]
        [TestCase(new int[] { 2, -1, 0, 0, -2, -1, 0 }, 6, 3)]
        public void PopPos(int[] actualArr, int pos, int numArrayListMoq)
        {
            OwnList.ArrayList<int> expected = ArrayListMoq(numArrayListMoq);
            OwnList.ArrayList<int> actual = new OwnList.ArrayList<int>(actualArr);
            actual.PopPos(pos);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] {}, 0)]
        [TestCase(new int[] {1,2 } , 9)]
        public void NegativePopPos(int[] actualArr, int pos)
        {
            try
            {
                OwnList.ArrayList<int> actual = new OwnList.ArrayList<int>(actualArr);
                actual.PopPos(pos);
            }
            catch
            {
                Assert.Pass();
            }

            Assert.Fail();
        }

        public OwnList.ArrayList<int> ArrayListMoq(int numExpectedMoq)
        {
            switch (numExpectedMoq)
            {
                case (1):
                    return new OwnList.ArrayList<int>(new int[] { 2, 1});
                case (2):
                    return new OwnList.ArrayList<int>(new int[] {2,1,2,3,3,4});
                case (3):
                    return new OwnList.ArrayList<int>(new int[] {2, -1, 0 , 0, -2, -1});
                 
                default:
                    throw new Exception();

            }
        }
    }
}