using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopNet.TDD
{
    //if divisible by 3 => Fizz
    //if devisible by 5 => Buzz
    //if devisible by 15 => FizBuzz
    [TestFixture]
    public class FrizzBuzzTests  

    {
        [TestCase("Fizz",3)]
        [TestCase("Buzz",5)]
        [TestCase("FizzBuzz", 15)]

        public void TestFizBuzz(string expected, int i) {

            Assert.AreEqual(expected,FizzBuzz(i));
            
            
           
        }
        private string FizzBuzz(int i) {

            if (i % 3 == 0)
            return "Fizz";
            if (i % 5 ==0)
                return "Buzz";
            if (i % 3 == 0 && i %5==0 )
                return "FizzBuzz";
            else return "";
        }

    }
}
