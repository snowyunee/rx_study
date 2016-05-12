using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive;
using System.Reactive.Linq;

namespace topcoder
{
    static public class week14
    {
        static public int countReachableIslands(int[] positions, int L)
        {
            var p = positions.First();

            int big = positions.OrderBy(x => x)
                .SkipWhile(x => x < p)
                .ToObservable()
                .Buffer(2, 1)
                .Where(l => l.Count >= 2)
                .TakeWhile(xy => Math.Abs(xy[0] - xy[1]) <= L)
                .Count()
                .First();

            int small = positions.OrderBy(x => x)
                .Reverse()
                .SkipWhile(x => x > p)
                .ToObservable()
                .Buffer(2, 1)
                .Where(l => l.Count >= 2)
                .TakeWhile(xy => Math.Abs(xy[0] - xy[1]) <= L)
                .Count()
                .First();

            return big + small + 1;
        }

        static public void run()
        {
            Console.WriteLine("{0} {1}", countReachableIslands(new int[] { 4, 7, 1, 3, 5 }, 1), 3);
            Console.WriteLine("{0} {1}", countReachableIslands(new int[] { 100, 101, 103, 105, 107 }, 2), 5);
            Console.WriteLine("{0} {1}", countReachableIslands(new int[] { 17, 10, 22, 14, 6, 1, 2, 3 }, 4), 7);
            Console.WriteLine("{0} {1}", countReachableIslands(new int[] { 0 }, 1000), 1);
        }
    }
}
