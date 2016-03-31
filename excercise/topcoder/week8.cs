using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive;
using System.Reactive.Linq;

namespace topcoder
{
    public class GroupOfAdjacent<TSource, TKey> : IEnumerable<TSource>, IGrouping<TKey, TSource>
    {
        public TKey Key { get; set; }
        private List<TSource> GroupList { get; set; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((System.Collections.Generic.IEnumerable<TSource>)this).GetEnumerator();
        }
        System.Collections.Generic.IEnumerator<TSource> System.Collections.Generic.IEnumerable<TSource>.GetEnumerator()
        {
            foreach (var s in GroupList)
                yield return s;
        }
        public GroupOfAdjacent(List<TSource> source, TKey key)
        {
            GroupList = source;
            Key = key;
        }
    }
    public static class LocalExtensions
    {
        public static IEnumerable<IGrouping<TKey, TSource>> GroupAdjacent<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector)
        {
            TKey last = default(TKey);
            bool haveLast = false;
            List<TSource> list = new List<TSource>();
            foreach (TSource s in source)
            {
                TKey k = keySelector(s);
                if (haveLast)
                {
                    if (!k.Equals(last))
                    {
                        yield return new GroupOfAdjacent<TSource, TKey>(list, last);
                        list = new List<TSource>();
                        list.Add(s);
                        last = k;
                    }
                    else
                    {
                        list.Add(s);
                        last = k;
                    }
                }
                else
                {
                    list.Add(s);
                    last = k;
                    haveLast = true;
                }
            }
            if (haveLast)
                yield return new GroupOfAdjacent<TSource, TKey>(list, last);
        }
    }
    class week8
    {

        static int solve(int[] a)
        {
            try
            {
              return a.GroupAdjacent(x =>
                  {
	                  //Console.WriteLine("x : {0}", x);
	                  return x;
	              })
                  .Select(xs =>
                  {
                      //Console.WriteLine("{0} {1}", xs.Count(), xs.First());
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
