using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive;
using System.Reactive.Linq;

namespace topcoder
{
    class week6
    {
        static int gcd(int a, int b)
        {
            return b == 0 ? a : gcd(b, a % b);
        }
        static public int TaroJiroDividing_getNumber(int A, int B)
        {
            return Convert.ToString(gcd(A, B), 2)
                .Reverse()
                .ToObservable()
                .TakeWhile(x => x == '0')
                .Count()
                .Select( x => (x > 0) ? x + 1 : x)
                .First();
        }

        static public void run()
        {
            Console.WriteLine(TaroJiroDividing_getNumber(8, 4));
            Console.WriteLine(TaroJiroDividing_getNumber(4, 7));
            Console.WriteLine(TaroJiroDividing_getNumber(12, 12));
            Console.WriteLine(TaroJiroDividing_getNumber(24, 96));
            Console.WriteLine(TaroJiroDividing_getNumber(1000000000, 999999999));
        }
    }
}
