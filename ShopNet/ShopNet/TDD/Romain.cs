using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopNet.TDD
{
    [TestFixture]
    public class ParseRomain
    {
        [TestCase(1, "I")]
        [TestCase(5, "V")]
        [TestCase(10, "X")]
        [TestCase(50, "L")]
        public void Parse(int expected, string letter)
        {
            Assert.AreEqual(expected, Roman.Parse(letter));
        }

        public class Roman
        {
            private static Dictionary<char, int> map =
                new Dictionary<char, int>()
                {
                    {'I', 1 },
                    {'V', 5 },                  
                    {'X', 10 },
                    {'L', 50 }


                };
          //  public static int Parse(string letter)
           // {
                //return map[letter[0]];
                //with multiple if statements we build dublicate code
                //if(letter =="I")
                   // return 1;
                //if (letter == "V")
                 //   return 5;
               // return 1;

               // if we need to pass II or IV values we need for loop like: 
               public static int Parse(string letter) {

                   int result =0;
                   for (int i =0; i< letter.Length; i++)
                   {
                       if (i + 1 < letter.Length && map[letter[i]] < map[letter[i + 1]])
                        { result -= map[letter[i]]; }
                        else
                        { result += map[letter[i]]; }

                    }
                   return result;
                }      
            }
        }
    }
//}
