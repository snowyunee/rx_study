using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Disposables;

namespace topcoder
{
    class week16
    {
        public static IEnumerable<T> Unfold<T>(T seed, Func<T, T> accumulator)
        {
            var nextValue = seed;
            while (true)
            {
                yield return nextValue;
                nextValue = accumulator(nextValue);
            }
        }
        static int chooseMax(IEnumerable<KeyValuePair<char, int>> even,
                             IEnumerable<KeyValuePair<char, int>> odd)
        {
            if (even.Count() == 0 && odd.Count() == 0) return 0;
            if (even.Count() == 0) return odd.First().Value;
            if (odd.Count() == 0) return even.First().Value;

            if (even.First().Key == odd.First().Key)
            {
                if (even.First().Value > odd.First().Value)
                    return chooseMax(even, odd.Skip(1));
                return chooseMax(even.Skip(1), odd);
            }

            return even.First().Value + odd.First().Value;
        }

        static int minimumChanges(String[] floor)
        {
            var index = Unfold(0, x => x + 1);
            var even = floor.Zip(index, (s, i) => new KeyValuePair<String, int>(s, i))
                            .Select(pr => pr.Key.Zip(index, (c, i) => new KeyValuePair<char, int>(c, i + pr.Value)))
                            .SelectMany(pr => pr)
                            .Where(pr => pr.Value % 2 == 0)
                            .Select(pr => pr.Key)
                            .GroupBy(x => x)
                            .Select(g => new KeyValuePair<char, int>(g.First(), g.Count()))
                            .OrderBy(pr => pr.Value)
                            .Reverse();

            var odd = floor.Zip(index, (s, i) => new KeyValuePair<String, int>(s, i))
                            .Select(pr => pr.Key.Zip(index, (c, i) => new KeyValuePair<char, int>(c, i + pr.Value)))
                            .SelectMany(pr => pr)
                            .Where(pr => pr.Value % 2 == 1)
                            .Select(pr => pr.Key)
                            .GroupBy(x => x)
                            .Select(g => new KeyValuePair<char, int>(g.First(), g.Count()))
                            .OrderBy(pr => pr.Value)
                            .Reverse();

            var count = floor.SelectMany(x => x).Count();
            return count - chooseMax(even, odd);
        }

        static public void run()
        {
            Console.WriteLine("{0}, {1}", minimumChanges(new String[] { "aba", "bbb", "aba" }), 1);
            Console.WriteLine("{0}, {1}", minimumChanges(new String[] { "wbwbwbwb", "bwbwbwbw", "wbwbwbwb", "bwbwbwbw", "wbwbwbwb", "bwbwbwbw", "wbwbwbwb", "bwbwbwbw"}), 0);
            Console.WriteLine("{0}, {1}", minimumChanges(new String[] { "zz", "zz"}), 2);
            Console.WriteLine("{0}, {1}", minimumChanges(new String[] { "helloand", "welcomet", "osingler", "oundmatc", "hsixhund", "redandsi", "xtythree", "goodluck"}), 56);
            Console.WriteLine("{0}, {1}", minimumChanges(new String[] { "jecjxsengslsmeijrmcx", "tcfyhumjcvgkafhhffed", "icmgxrlalmhnwwdhqerc",
                                                                         "xzrhzbgjgabanfxgabed", "fpcooilmwqixfagfojjq", "xzrzztidmchxrvrsszii",
    																	 "swnwnrchxujxsknuqdkg", "rnvzvcxrukeidojlakcy", "kbagitjdrxawtnykrivw",
    																	 "towgkjctgelhpomvywyb", "ucgqrhqntqvncargnhhv", "mhvwsgvfqgfxktzobetn",
    																	 "fabxcmzbbyblxxmjcaib", "wpiwnrdqdixharhjeqwt", "xfgulejzvfgvkkuyngdn",
    																	 "kedsalkounuaudmyqggb", "gvleogefcsxfkyiraabn", "tssjsmhzozbcsqqbebqw",
    																	 "ksbfjoirwlmnoyyqpbvm", "phzsdodppzfjjmzocnge"}), 376);


        }
    }
}
