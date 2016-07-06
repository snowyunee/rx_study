using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topcoder
{
    // https://community.topcoder.com/stat?c=problem_statement&pm=13960
    class srm_665
    {
        static int construct(int a)
        {
            try
            {
                return Enumerable.Range(a + 1, 100 - a)
                    .SelectMany(x =>
                    {
                        var y = a ^ x;
                        if (y == 4 || y == 7 || y == 44 || y == 47 ||
                            y == 74 || y == 77)
                            return Enumerable.Range(x, 1);
                        return Enumerable.Range(x, 0);
                    })
                    .First();
            }
            catch (Exception /*e*/)
            {
                return -1;
            }
        }

        static public void run()
        {
            //Console.WriteLine("Possible {0}", check(new String[] {"WWW"}));
            Console.WriteLine("40 , {0}", construct(4));
            Console.WriteLine("20 , {0}", construct(19));
            Console.WriteLine("92 , {0}", construct(88));
            Console.WriteLine("-1 , {0}", construct(36));
            Console.WriteLine("-1 , {0}", construct(200));
        }
    }
}
