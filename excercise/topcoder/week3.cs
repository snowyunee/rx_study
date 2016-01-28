using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive;
using System.Reactive.Linq;

namespace topcoder
{
    class PeacefulLine
    {
        static public String makeLine(int[] ks)
        {
            return ks
                .ToObservable()
                .GroupBy(k => k)
                .SelectMany(grp => grp.Count())
                .Max()
                .Select(m =>
                {
                    if (((ks.Length + 1) / 2) >= m) return "possible";
                    return "impossible";
                })
                .Last();
        }

        static public String makeLine2(int[] ks)
        {
            return ks
                .ToObservable()
                .Scan(new Dictionary<int, int>(), (acc, cur) =>
                {
                    if (!acc.ContainsKey(cur)) acc.Add(cur, 1);
                    else acc[cur]++;
                    return acc;
                })
                .Select(m => m.Values.Max())
                .Select(m =>
                {
                    if (((ks.Length + 1) / 2) >= m) return "possible";
                    return "impossible";
                })
                .Last();

        }
    }
    static class Week3
    {
        static public void run()
        {
            Console.WriteLine("p {0}", PeacefulLine.makeLine(new int[] { 1, 2, 3, 4 }));
            Console.WriteLine("p {0}", PeacefulLine.makeLine(new int[] { 1, 1, 2, 2, 3, 3, 4, 4 }));
            Console.WriteLine("p {0}", PeacefulLine.makeLine(new int[] { 3, 3, 3, 3, 13, 13, 13, 13 }));
            Console.WriteLine("imp {0}", PeacefulLine.makeLine(new int[] { 3, 7, 7, 7, 3, 7, 7, 7, 3 }));
            Console.WriteLine("p {0}", PeacefulLine.makeLine(new int[] { 25, 12, 3, 25, 25, 12, 12, 12, 12, 3, 25 }));
            Console.WriteLine("p {0}", PeacefulLine.makeLine(new int[] { 3, 3, 3, 3, 13, 13, 13, 13, 3 }));

            Console.WriteLine("p {0}", PeacefulLine.makeLine2(new int[] { 1, 2, 3, 4 }));
            Console.WriteLine("p {0}", PeacefulLine.makeLine2(new int[] { 1, 1, 2, 2, 3, 3, 4, 4 }));
            Console.WriteLine("p {0}", PeacefulLine.makeLine2(new int[] { 3, 3, 3, 3, 13, 13, 13, 13 }));
            Console.WriteLine("imp {0}", PeacefulLine.makeLine2(new int[] { 3, 7, 7, 7, 3, 7, 7, 7, 3 }));
            Console.WriteLine("p {0}", PeacefulLine.makeLine2(new int[] { 25, 12, 3, 25, 25, 12, 12, 12, 12, 3, 25 }));
            Console.WriteLine("p {0}", PeacefulLine.makeLine2(new int[] { 3, 3, 3, 3, 13, 13, 13, 13, 3 }));
        }
    }
}
