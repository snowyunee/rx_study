using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Disposables;

namespace topcoder
{
    class srm_666
    {
        static String canWin(int[] nextLevel)
        {
            var l = Observable.Generate(
                0,
                s => nextLevel[s] != -1,
                s => nextLevel[s],
                s => nextLevel[s])
                .Take(nextLevel.Count())
                .Count()
                .First();

            Console.WriteLine(l);
            if (l != nextLevel.Count()) return "Win";
            return "Lose";
        }
        static public void run()
        {
            Console.WriteLine("{0}, {1}", "Win", canWin(new int[] { 1, -1 }));
            Console.WriteLine("{0}, {1}", "Lose", canWin(new int[] { 1, 0, -1 }));
            Console.WriteLine("{0}, {1}", "Lose", canWin(new int[] { 0, 1, 2 }));
            Console.WriteLine("{0}, {1}", "Win", canWin(new int[] { 29, 33, 28, 16, -1, 11, 10, 14, 6, 31, 7, 35, 34, 8, 15, 17, 26, 12, 13, 22, 1, 20, 2, 21, -1, 5, 19, 9, 18, 4, 25, 32, 3, 30, 23, 10, 27 }));
            Console.WriteLine("{0}, {1}", "Win", canWin(new int[] { 17, 43, 20, 41, 42, 15, 18, 35, -1, 31, 7, 33, 23, 33, -1, -1, 0, 33, 19, 12, 42, -1, -1, 9, 9, -1, 39, -1, 31, 46, -1, 20, 44, 41, -1, -1, 12, -1, 36, -1, -1, 6, 47, 10, 2, 4, 1, 29 }));
            Console.WriteLine("{0}, {1}", "Lose", canWin(new int[] { 3, 1, 1, 2, -1, 4 }));
        }
    }
}
