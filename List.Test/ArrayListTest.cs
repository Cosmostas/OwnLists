using NUnit.Framework;
using OwnList;
using System;
namespace List.Test
{
    public class ArrayListTest
    {

        [TestCase(1)]
        public void ToString(int a)
        {
            ArrayList<int> V = new ArrayList<int>(a);

            Assert.AreEqual("1 ", V.ToString());
        }

        [TestCase(new int[] { 1, 2, 3 })]
        public void ToString(int[] a)
        {
            ArrayList<int> V = new ArrayList<int>(a);

            Assert.AreEqual("1 2 3 ", V.ToString());
        }


        [TestCase(5, 1)]
        public void PushBack(int value, int numExpectedMoq)
        {
            ArrayList<int> expected = ArrayListMoq(numExpectedMoq);
            ArrayList<int> actual = new ArrayList<int>();
            actual.PushBack(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, new int[] { 5 }, 1)]
        [TestCase(new int[] { 1, 6, -1 }, new int[] { 0, 123 }, 2)]
        public void PushBack(int[] actualArr, int[] arr, int numExpectedMoq)
        {
            ArrayList<int> expected = ArrayListMoq(numExpectedMoq);
            ArrayList<int> actual = new ArrayList<int>(actualArr);
            actual.PushBack(arr);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(5, 0, new int[] { }, 1)]
        [TestCase(-1, 2, new int[] { 1, 6, 0, 123 }, 2)]
        [TestCase(123, 4, new int[] { 1, 6, -1, 0 }, 2)]
        [TestCase(1, 0, new int[] { 6, -1, 0, 123 }, 2)]
        public void PushByIndex(int value, int index, int[] actualArr, int numExpectedMoq)
        {
            ArrayList<int> expected = ArrayListMoq(numExpectedMoq);
            ArrayList<int> actual = new ArrayList<int>(actualArr);
            actual.PushByIndex(value, index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 5 }, 0, new int[] { }, 1)]
        [TestCase(new int[] { -1, 0 }, 2, new int[] { 1, 6, 123 }, 2)]
        [TestCase(new int[] { 0, 123 }, 3, new int[] { 1, 6, -1 }, 2)]
        [TestCase(new int[] { 1, 6 }, 0, new int[] { -1, 0, 123 }, 2)]
        public void PushByIndex(int[] arr, int index, int[] actualArr, int numExpectedMoq)
        {
            ArrayList<int> expected = ArrayListMoq(numExpectedMoq);
            ArrayList<int> actual = new ArrayList<int>(actualArr);
            actual.PushByIndex(arr, index);

            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { }, 5, 1)]
        [TestCase(new int[] { 6, -1, 0, 123 }, 1, 2)]
        public void PushFront(int[] actualArr, int value, int numExpectedMoq)
        {
            ArrayList<int> expected = ArrayListMoq(numExpectedMoq);
            ArrayList<int> actual = new ArrayList<int>(actualArr);
            actual.PushFront(value);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { }, new int[] { 5, 3 }, 3)]
        [TestCase(new int[] { -1, 0, 123 }, new int[] { 1, 6 }, 2)]

        public void PushFront(int[] actualArr, int[] arr, int numExpectedMoq)
        {
            ArrayList<int> expected = ArrayListMoq(numExpectedMoq);
            ArrayList<int> actual = new ArrayList<int>(actualArr);
            actual.PushFront(arr);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 5, 3, 3 }, 3)]
        [TestCase(new int[] { 1, 6, -1, 0, 123, 21 }, 2)]

        public void PopBack(int[] actualArr, int numExpectedMoq)
        {
            ArrayList<int> expected = ArrayListMoq(numExpectedMoq);
            ArrayList<int> actual = new ArrayList<int>(actualArr);
            actual.PopBack();

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 5, 3, 3 }, 2, 1)]
        [TestCase(new int[] { 5, 3, 3 }, 3, 0)]
        [TestCase(new int[] { 5, 3, 3 }, 1, 3)]

        public void PopBackAmount(int[] actualArr, int amount, int numExpectedMoq)
        {
            ArrayList<int> expected = ArrayListMoq(numExpectedMoq);
            ArrayList<int> actual = new ArrayList<int>(actualArr);
            actual.PopBackAmount(amount);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 3, 2, 1, 6, -1, 0, 123 }, 2, 0, 2)]
        [TestCase(new int[] { 3, 2, 1, 6, -1, 0, 123 }, 7, 0, 0)]
        [TestCase(new int[] { 1, 6, -1, 0, 123, 2, 3 }, 2, 5, 2)]

        public void PopByPosAmount(int[] actualArr, int amount, int index, int numExpectedMoq)
        {
            ArrayList<int> expected = ArrayListMoq(numExpectedMoq);
            ArrayList<int> actual = new ArrayList<int>(actualArr);
            actual.PopByPosAmount(index, amount);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 6, -1, 2, 0, 123 }, 3, 2)]
        [TestCase(new int[] { 4, 5, 3 }, 0, 3)]
        [TestCase(new int[] { 5, 3, 3 }, 2, 3)]
        [TestCase(new int[] { 5, 3, 3 }, 1, 3)]
        [TestCase(new int[] { 5 }, 0, 0)]

        public void PopByPos(int[] actualArr, int index, int numExpectedMoq)
        {
            ArrayList<int> expected = ArrayListMoq(numExpectedMoq);
            ArrayList<int> actual = new ArrayList<int>(actualArr);
            actual.PopByPos(index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 5, 3 }, 3)]
        [TestCase(new int[] { 5, 1, 6, -1, 0, 123 }, 2)]

        public void PopFront(int[] actualArr, int numExpectedMoq)
        {
            ArrayList<int> expected = ArrayListMoq(numExpectedMoq);
            ArrayList<int> actual = new ArrayList<int>(actualArr);
            actual.PopFront();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 2, 1, 5, 3 }, 2, 3)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 1, 6, -1, 0, 123 }, 5, 2)]
        [TestCase(new int[] { 0, 123 }, 2, 0)]

        public void PopFrontamount(int[] actualArr, int amount, int numExpectedMoq)
        {
            ArrayList<int> expected = ArrayListMoq(numExpectedMoq);
            ArrayList<int> actual = new ArrayList<int>(actualArr);
            actual.PopFrontAmount(amount);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { -1, 1, 6, -1, 0, 123 }, -1, 2)]
        [TestCase(new int[] { 1, 6, -1, -1, 0, 123 }, -1, 2)]
        [TestCase(new int[] { 1, 6, -1, 0, 123, -2 }, -2, 2)]
        [TestCase(new int[] { 5 }, 5, 0)]

        public void PopByValue(int[] actualArr, int value, int numExpectedMoq)
        {
            ArrayList<int> expected = ArrayListMoq(numExpectedMoq);
            ArrayList<int> actual = new ArrayList<int>(actualArr);
            actual.PopByValue(value);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { -2, -2, 1, 6, -1, 0, -2, 123, -2 }, -2, 2)]
        [TestCase(new int[] { 5, 5 }, 5, 0)]

        public void PopAllByValue(int[] actualArr, int value, int numExpectedMoq)
        {
            ArrayList<int> expected = ArrayListMoq(numExpectedMoq);
            ArrayList<int> actual = new ArrayList<int>(actualArr);
            actual.PopByValueAll(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 2, 1, 5, 3 }, 2, 0)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 1, 6, -1, 0, 123 }, -1, 7)]
        [TestCase(new int[] { 0, 123 }, 123, 1)]

        public void Find(int[] actualArr, int value, int expectedIndex)
        {
            int expected = expectedIndex;
            ArrayList<int> actualList = new ArrayList<int>(actualArr);
            int actual = actualList.Find(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 5 }, 1)]
        [TestCase(new int[] { 5, 3 }, 4)]
        [TestCase(new int[] { 5, 3, 1, 6, 9, 0, -1, 3 }, 5)]
        [TestCase(new int[] { 5, 3, 1, 6, 9, 0, -1, 3, -5 }, 6)]

        public void Sort(int[] actualArr, int numExpectedMoq)
        {
            ArrayList<int> expected = ArrayListMoq(numExpectedMoq);
            ArrayList<int> actual = new ArrayList<int>(actualArr);
            actual.Sort(0,actual.GetLength());

            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 5 }, 1)]
        [TestCase(new int[] { 5, 3 }, 4)]
        [TestCase(new int[] { 9, 6, 5, 3, 3, 1, 0, 0 - 1 }, 5)]

        public void Reverse(int[] actualArr, int numExpectedMoq)
        {
            ArrayList<int> expected = ArrayListMoq(numExpectedMoq);
            ArrayList<int> actual = new ArrayList<int>(actualArr);
            actual.Reverse();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 5)]
        [TestCase(2, 123)]
        public void FindMax(int numMoq, int max)
        {
            ArrayList<int> list = ArrayListMoq(numMoq);

            if (list.FindMax() == max)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void NegativeFindMax()
        {
            ArrayList<int> list = new ArrayList<int>();

            try
            {
                list.FindMax();
            }
            catch (Exception e)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(1, 0)]
        [TestCase(2, 4)]
        public void FindMaxIndex(int numMoq, int maxIndex)
        {
            ArrayList<int> list = ArrayListMoq(numMoq);

            Assert.AreEqual(list.FindMaxIndex(), maxIndex);
        }

        [Test]
        public void NegativeFindMaxIndex()
        {
            ArrayList<int> list = new ArrayList<int>();

            try
            {
                list.FindMaxIndex();
            }
            catch (Exception e)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }
        [TestCase(1, 5)]
        [TestCase(2, -1)]
        public void FinMin(int numMoq, int min)
        {
            ArrayList<int> list = ArrayListMoq(numMoq);

            if (list.FindMin() == min)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
        [Test]
        public void NegativeFindMin()
        {
            ArrayList<int> list = new ArrayList<int>();

            try
            {
                list.FindMin();
            }
            catch (Exception e)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }
        [TestCase(1, 0)]
        [TestCase(2, 2)]
        public void FindMinIndex(int numMoq, int minIndex)
        {
            ArrayList<int> list = ArrayListMoq(numMoq);

            Assert.AreEqual(list.FindMinIndex(), minIndex);
        }
        [Test]
        public void NegativeFindMinIndex()
        {
            ArrayList<int> list = new ArrayList<int>();

            try
            {
                list.FindMaxIndex();
            }
            catch (Exception e)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }
        public ArrayList<int> ArrayListMoq(int numMoq)
        {
            switch (numMoq)
            {
                case 0:
                    return new ArrayList<int>();
                case 1:
                    return new ArrayList<int>(5);
                case 2:
                    return new ArrayList<int>(new int[] { 1, 6, -1, 0, 123 });
                case 3:
                    return new ArrayList<int>(new int[] { 5, 3 });
                case 4:
                    return new ArrayList<int>(new int[] { 3, 5 });
                case 5:
                    return new ArrayList<int>(new int[] { -1, 0, 1, 3, 3, 5, 6, 9 });
                case 6:
                    return new ArrayList<int>(new int[] { -5, -1, 0, 1, 3, 3, 5, 6, 9 });
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}