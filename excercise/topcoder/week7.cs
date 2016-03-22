using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive;
using System.Reactive.Linq;


namespace topcoder
{
    static class week7
    {
        public static IEnumerable<T> Scan<T>(this IEnumerable<T> Input, Func<T, T, T> Accumulator)
        {
            using (IEnumerator<T> enumerator = Input.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                    yield break;
                T state = enumerator.Current;
                yield return state;
                while (enumerator.MoveNext())
                {
                    state = Accumulator(state, enumerator.Current);
                    yield return state;
                }
            }
        }
        public static IEnumerable<T> Unfold<T>(T seed, Func<T, T> accumulator)
        {
            var nextValue = seed;
            while (true)
            {
                yield return nextValue;
                nextValue = accumulator(nextValue);
            }
        }
        static public int findValue(string s)
        {
            int[] seed = (new int['z' - 'a'+1]);
            seed.Select(x => 0);

            return Observable.Scan(s.ToObservable(), seed, (acc, x) => { ++acc[x - 'a']; return acc; })
                .Select(xs => {
                    var acc = xs.Scan((y, x) => y + x);
                    return xs.Zip(acc, (x, y) => new { x = x, acc_cnt = y })
                             .Zip(Unfold(1, x => x + 1), (v, idx) => new { x = v.x, acc_cnt = v.acc_cnt, idx = idx });
                })
                .Select(vs =>
                {
                    //Console.WriteLine("--------------------");
                    return vs.Aggregate(0, (acc, v) => acc + v.x * v.acc_cnt * v.idx);
                })
                .Last();
        }

        static public void run()
        {
            Console.WriteLine("104 {0}", findValue("zz"));
            Console.WriteLine("25 {0}", findValue("y"));
            Console.WriteLine("47 {0}", findValue("aaabbc"));
            Console.WriteLine("558 {0}", findValue("topcoder"));
            Console.WriteLine("11187 {0}", findValue("thequickbrownfoxjumpsoverthelazydog"));
            Console.WriteLine("6201 {0}", findValue("zyxwvutsrqponmlkjihgfedcba"));
        }
    }
}
