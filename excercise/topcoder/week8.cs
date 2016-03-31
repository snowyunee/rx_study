using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive;
using System.Reactive.Linq;

namespace topcoder
{
    class week8
    {
        static int solve(int[] a)
        {
            try
            {
              return a.GroupBy(x => x)
                  .Select(xs =>
                  {
//                      Console.WriteLine("{0} {1}", xs.Count(), xs.First());
                      if (xs.Count() % xs.First() == 0)
                          return xs.Count() / xs.First();
                      throw new Exception();
                  })
                  .Aggregate((x, y) => x + y);
            }
            catch(Exception e)
            {
                return -1;
            }
        }

        static public void run()
        {

            Console.WriteLine("2, {0}", solve(new int[] { 2, 2, 3, 3, 3 }));
            Console.WriteLine("5, {0}", solve(new int[] { 1, 1, 1, 1, 1 }));
            Console.WriteLine("-1, {0}", solve(new int[] { 3, 3 }));
            Console.WriteLine("5, {0}", solve(new int[] { 4, 4, 4, 4 , 1, 1, 2, 2, 3, 3, 3 }));
            Console.WriteLine("-1, {0}", solve(new int[] { 2, 1, 2, 2, 1, 2 }));
        }
    }
}
