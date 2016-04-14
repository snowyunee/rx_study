using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive;
using System.Reactive.Linq;

namespace topcoder
{
    class week10
    {
        static bool check(String[] board)
        {
            return board.Select(xs => xs.GroupAdjacent(x => x).Count() == xs.Count())
                .Aggregate((x, y) => x && y);
        }
        static bool remained(String[] board)
        {
            return board.Select(xs => xs.Select(x => x == '?').Aggregate((x, y) => x || y))
                .Aggregate((x, y) => x || y);
        }
        static String[] set_x(String[] board, Char c)
        {
            bool changed = false;
            return (String[])board
                .Select(xs =>
                    (String) xs.Select(x =>
                    {
                        if (changed == false && x == '?')
                        {
                            changed = true;
                            return c;
                        }
                        return x;
                    })
                 );
        }
        static bool ableToDraw_r(String[] board)
        {
            if (!remained(board))
            {
                if (check(board))
                {
                    String px = board.Select(x => x).Aggregate((x, y) => x + ", " + y);
                    Console.WriteLine(px);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return ableToDraw_r(set_x(board, 'W')) || ableToDraw_r(set_x(board, 'B'));
            }
        }
        static public String ableToDraw(String[] board)
        {
            if (ableToDraw_r(board))
                return "possible";
            return "impossible";
        }

        static public void run()
        {

            //Console.WriteLine("Possible {0}", check(new String[] {"WWW"}));
            Console.WriteLine("Possible {0}", ableToDraw(new String[] { "W?W", "??B", "???" }));
            Console.WriteLine("Impossible {0}", ableToDraw(new String[] { "W??W" }));
            Console.WriteLine("Possible {0}", ableToDraw(new String[] { "??" }));
            Console.WriteLine("Possible {0}", ableToDraw(new String[] { "W???", "??B?", "W???", "???W" }));
            Console.WriteLine("Impossible {0}", ableToDraw(new String[] { "W???", "??B?", "W???", "?B?W" }));
            Console.WriteLine("Possible {0}", ableToDraw(new String[] { "B" }));
        }
    }
}
