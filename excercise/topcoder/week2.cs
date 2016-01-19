using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive;
using System.Reactive.Linq;

namespace topcoder
{
    class TheConsecutiveIntegersDivTwo
    {
        static public IObservable<int> find(int[] numbers, int k)
        {
            if (k == 1) return Observable.Return(0);

            return numbers
                .OrderBy(c => c)
                .ToObservable()
                .Buffer(2, 1)
                .Where(l => l.Count >= 2)
                .Select(l => System.Math.Abs(l[0] - l[1]))
                .Min()
                .Select(x => System.Math.Abs(1 - x));
        }
    }
    static class Week2
    {
        public static void Dump<T>(this IObservable<T> source, string name)
        {
          source.Subscribe(
              i=>Console.WriteLine("{0}-->{1}", name, i),
              ex=>Console.WriteLine("{0} failed-->{1}", name, ex.Message),
              ()=>Console.WriteLine("{0} completed", name));
        }
        static public void run()
        {
            TheConsecutiveIntegersDivTwo.find(new int[] { 4, 47, 7}, 2).Dump("ex1 : 2");
            TheConsecutiveIntegersDivTwo.find(new int[] { 1, 100}, 1).Dump("ex2 : 0");
            TheConsecutiveIntegersDivTwo.find(new int[] { -96, -53, 82, -24, 6, -75}, 2).Dump("ex3 : 20");
            TheConsecutiveIntegersDivTwo.find(new int[] { 64, -31, -56}, 2).Dump("ex4 : 24");
        }
    }
}
