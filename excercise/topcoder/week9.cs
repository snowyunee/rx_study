using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topcoder
{
    class week9
    {
        public static int getscore(String s)
        {
            return s.GroupAdjacent(x => x)
                .Select(xs => (xs.Count() + 1) * xs.Count() / 2)
                .Aggregate((x, y) => x + y);
        }
        static public void run()
        {
            Console.WriteLine("8 {0}", getscore("aaaba"));
            Console.WriteLine("12 {0}", getscore("zzzxxzz"));
            Console.WriteLine("26 {0}", getscore("abcdefghijklmnopqrstuvwxyz"));
            Console.WriteLine("1 {0}", getscore("p"));
            Console.WriteLine("5050 {0}", getscore("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"));
        }
    }
}

    	
