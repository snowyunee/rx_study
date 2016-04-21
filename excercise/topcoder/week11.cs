using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topcoder
{
    class week11
    {
        static public String reconstructMessage(String s, int k)
        {
            var r = s.GroupBy(x => x)
                .Select(x => new KeyValuePair<int, char>(x.Count(), x.First()))
                .Aggregate(
                    new {
                        pr = new KeyValuePair<int, char>(0, '0'),
                        alphabet = "abcdefghijklmnopqrstuvwxyz"
                    },
                    (seed, x) => {
                        if (s.Count() - x.Key == k)
                            return new { pr = x, alphabet = String.Join("", seed.alphabet.Except(new String(x.Value, 1))) };
                        return new { pr = seed.pr, alphabet = String.Join("", seed.alphabet.Except(new String(x.Value, 1))) };
                });

            if (r.pr.Key != 0) return String.Join("", s.Select(x => new String(r.pr.Value, 1)));

            return String.Join("", s.Select(x => new String(r.alphabet.First(), 1)));;
        }

        static public void run()
        {
            Console.WriteLine("{0}, {1}", reconstructMessage("hello", 3), "lllll");
            Console.WriteLine("{0}, {1}", reconstructMessage("abc", 3), "ddd");
            Console.WriteLine("{0}, {1}", reconstructMessage("wwwwwwwwwwwwwwwwww", 0), "wwwwwwwwwwwwwwwwww");
            Console.WriteLine("{0}, {1}", reconstructMessage("ababba", 3), "aaaaaa");
            Console.WriteLine("{0}, {1}", reconstructMessage("zoztxtoxytyt", 10), "oooooooooooo");
            Console.WriteLine("{0}, {1}", reconstructMessage("jlmnmiunaxzywed", 13), "mmmmmmmmmmmmmmm");
        }
    }
}
