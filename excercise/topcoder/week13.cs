using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topcoder
{
    static class week13
    {
        static int GCD(int num1, int num2)
        {
            while (num1 != num2)
            {
                if (num1 > num2)
                    num1 = num1 - num2;

                if (num2 > num1)
                    num2 = num2 - num1;
            }
            return num1;
        }


        static int LCM(int num1, int num2)
        {
            return (num1 * num2) / GCD(num1, num2);
        }

        static public String equals(String s, String t)
        {
            var lcm = LCM(s.Count(), t.Count());
            //var r = Enumerable.SequenceEqual(
            //    Enumerable.Repeat(s, (lcm / s.Count())).SelectMany(l => l),
            //    Enumerable.Repeat(t, (lcm / t.Count())).SelectMany(l => l));
            return (Enumerable.Repeat(s, (lcm / s.Count())).SelectMany(l => l)
                .SequenceEqual(Enumerable.Repeat(t, (lcm / t.Count())).SelectMany(l => l))) ?
                "Equal" : "Not Equal";
        }

        static public void run()
        {
            Console.WriteLine("{0} {1}", equals("ab", "abab"), "Equal");
			Console.WriteLine("{0} {1}", equals("abc", "bca"), "Not equal");
			Console.WriteLine("{0} {1}", equals("abab", "aba"), "Not equal");
			Console.WriteLine("{0} {1}", equals("aaaaa", "aaaaaa"), "Equal");
			Console.WriteLine("{0} {1}", equals("ababab", "abab"), "Equal");
			Console.WriteLine("{0} {1}", equals("a", "z"), "Not equal");
        }
    }
}
