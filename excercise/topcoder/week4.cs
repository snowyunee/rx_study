using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive;
using System.Reactive.Linq;

namespace topcoder
{

    class KitayutaMart2
    {
        static public int numBought(int K, int T)
        {
            return (int)Math.Log(T / K + 1, 2);
        }
        public static IEnumerable<T> Unfold<T>(T seed, Func<T, T> accumulator)
        {
            var nextValue = seed;
            while (true)
            {
                yield return nextValue;
                nextValue = accumulator(nextValue);
            }
        }
        static public int numBought2(int K, int T)
        {
            var seq = Unfold(T / K + 1, i => i / 2);

            return seq.ToObservable()
                .TakeWhile(x => x > 1)
                .Count()
                .Last();
        }
    }

    class Week4
    {
        static public void run()
        {
            Console.WriteLine("1 {0}", KitayutaMart2.numBought(100, 100));
            Console.WriteLine("2 {0}", KitayutaMart2.numBought(100, 300));
            Console.WriteLine("3 {0}", KitayutaMart2.numBought(150, 1050));
            Console.WriteLine("10 {0}", KitayutaMart2.numBought(160, 163680));

            Console.WriteLine("1 {0}", KitayutaMart2.numBought2(100, 100));
            Console.WriteLine("2 {0}", KitayutaMart2.numBought2(100, 300));
            Console.WriteLine("3 {0}", KitayutaMart2.numBought2(150, 1050));
            Console.WriteLine("10 {0}", KitayutaMart2.numBought2(160, 163680));
        }
    }
}
