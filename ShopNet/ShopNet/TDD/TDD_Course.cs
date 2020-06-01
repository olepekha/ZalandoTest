using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ShopNet.TDD
{
    [TestFixture]
    public class Fibonacci
    {

        // 1,1,2,3,5,8,13,21,34
        //or
        // 0,1,1,2,3,5,8,13,21,34
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(1, 2)]
        [TestCase(2, 3)]
        [TestCase(3, 4)]
        [TestCase(5, 5)]
        [TestCase(8, 6)]
        public void TestFBN(int expected, int i)
        {
            Assert.AreEqual(expected, GetFBN(i));
        }

        private int GetFBN(int i)
        {
            if (i == 0) return 0;
            if (i == 1) return 1;
            return GetFBN(i - 1) + GetFBN(i - 2);

        }

    }
}


