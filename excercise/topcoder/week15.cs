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
                return row.GroupAdjacent(x => x == 'o' || x == '.')
                  .SelectMany(xs => xs.OrderBy(x => x));
            } )
            .Transpose()
            .Select(row => String.Join("", row))
            .ToArray();
        }

        static public void run()
        {
            Console.WriteLine("{0}", simulate(new String[] { "ooooo", "..x..", "....x", ".....", "....o" }).Aggregate((x, y) => x + ", " + y));

            Console.WriteLine("{0}", simulate(new String[] { "..o..", "..x.o", "....x", ".....", "oo.oo" }).Aggregate((x, y) => x + ", " + y));

            Console.WriteLine("{0}", simulate(new String[] { "o", ".", "o", ".", "o", ".", "." }).Aggregate((x, y) => x + ", " + y));

            Console.WriteLine("{0}", simulate(new String[] { "oxxxxooo", "xooooxxx", "..xx.ooo", "oooox.o.", "..x....." }).Aggregate((x, y) => x + ", " + y));

            Console.WriteLine("{0}", simulate(new String[] { "..o..o..o..o..o..o..o..o..o..o..o",
                                                             "o..o..o..o..o..o..o..o..o..o..o..",
                                                             ".o..o..o..o..o..o..o..o..o..o..o.",
                                                             "...xxx...xxx...xxxxxxxxx...xxx...",
                                                             "...xxx...xxx...xxxxxxxxx...xxx...",
                                                             "...xxx...xxx......xxx......xxx...",
                                                             "...xxxxxxxxx......xxx......xxx...",
                                                             "...xxxxxxxxx......xxx......xxx...",
                                                             "...xxxxxxxxx......xxx......xxx...",
                                                             "...xxx...xxx......xxx............",
                                                             "...xxx...xxx...xxxxxxxxx...xxx...",
                                                             "...xxx...xxx...xxxxxxxxx...xxx...",
                                                             "..o..o..o..o..o..o..o..o..o..o..o",
                                                             "o..o..o..o..o..o..o..o..o..o..o..",
                                                             ".o..o..o..o..o..o..o..o..o..o..o."}).Aggregate((x, y) => x + ", " + y));
        }
    }
}
