using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topcoder
{
    class week15
    {
        static public String[] simulate(String[] board)
        {
            return board.Transpose().Select(row =>
            {
                Console.WriteLine("==========");
                Console.Write("row ");
                Console.WriteLine(String.Join("", row));
                var temp = row.GroupAdjacent(x => x == 'o' || x == '.')
                  .SelectMany(xs => xs.GroupBy( x => x).Reverse())
                  .SelectMany(xs => {
                      Console.WriteLine("sorted");
                      Console.WriteLine(xs.Count());
                      Console.WriteLine(String.Join("", xs));  return  xs;});
                Console.WriteLine(String.Join("", temp));
                Console.WriteLine("==========");

                return row.GroupAdjacent(x => x == 'o' || x == '.')
                  .SelectMany(xs => xs)
                  .GroupBy(x => x)
                  .Reverse()
                  .SelectMany(xs => xs);
            } )
            .Transpose()
            .Select(row => String.Join("", row))
            .ToArray();
        }

        static public void run()
        {
            Console.WriteLine("{0}", simulate(new String[] { "ooooo", "..x..", "....x", ".....", "....o" }).Aggregate((x, y) => x + ", " + y));

            //Console.WriteLine("{0}", simulate(new String[] { "..o..", "..x.o", "....x", ".....", "oo.oo" }).Aggregate((x, y) => x + ", " + y));

            //Console.WriteLine("{0}", simulate(new String[] { "o", ".", "o", ".", "o", ".", "." }).Aggregate((x, y) => x + ", " + y));

            //Console.WriteLine("{0}", simulate(new String[] { "oxxxxooo", "xooooxxx", "..xx.ooo", "oooox.o.", "..x....." }).Aggregate((x, y) => x + ", " + y));

            //Console.WriteLine("{0}", simulate(new String[] { "..o..o..o..o..o..o..o..o..o..o..o",
            //                                                 "o..o..o..o..o..o..o..o..o..o..o..",
            //                                                 ".o..o..o..o..o..o..o..o..o..o..o.",
            //                                                 "...xxx...xxx...xxxxxxxxx...xxx...",
            //                                                 "...xxx...xxx...xxxxxxxxx...xxx...",
            //                                                 "...xxx...xxx......xxx......xxx...",
            //                                                 "...xxxxxxxxx......xxx......xxx...",
            //                                                 "...xxxxxxxxx......xxx......xxx...",
            //                                                 "...xxxxxxxxx......xxx......xxx...",
            //                                                 "...xxx...xxx......xxx............",
            //                                                 "...xxx...xxx...xxxxxxxxx...xxx...",
            //                                                 "...xxx...xxx...xxxxxxxxx...xxx...",
            //                                                 "..o..o..o..o..o..o..o..o..o..o..o",
            //                                                 "o..o..o..o..o..o..o..o..o..o..o..",
            //                                                 ".o..o..o..o..o..o..o..o..o..o..o."}));
        }
    }
}
