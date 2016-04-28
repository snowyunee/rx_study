using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topcoder
{

    static class week12
    {
        /// <summary>
        /// Swaps the rows and columns of a nested sequence.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="source">The source sequence.</param>
        /// <returns>A sequence whose rows and columns are swapped.</returns>
        public static IEnumerable<IEnumerable<T>> Transpose<T>(
                 this IEnumerable<IEnumerable<T>> source)
        {
            return from row in source
                   from col in row.Select(
                       (x, i) => new KeyValuePair<int, T>(i, x))
                   group col.Value by col.Key into c
                   select c as IEnumerable<T>;
        }

        public static int count(
                 this IEnumerable<IEnumerable<char>> source)
        {
            return source.Select(row => row.Any(c => c == 'R'))
                .Select(x => (x) ? 1 : 0)
                .Aggregate(0, (x, y) => x + y);
        }


        static public String isCorrect(String[] board)
        {
            return (board.count() == 8 && board.Transpose().count() == 8) ? "Correct" : "Incorrect";
        }

        static public void run()
        {
            //IEnumerable<IEnumerable<int>> c = new []{ new [] { 1, 2, 3 },
            //                                          new [] { 4, 5, 6 },
            //                                          new [] { 10, 11, 12 } };
            //var Ttemp = c.Transpose();
            //var str = Ttemp.Aggregate("", (acc, row) => acc + "\n" + row.Aggregate("", (acc2, col) => acc2 + " " + col));
            //Console.Write(str);
            Console.WriteLine("{0} {1}", "Correct", isCorrect(new String[] { "R.......", ".R......", "..R.....", "...R....", "....R...", ".....R..", "......R.", ".......R" }));
            Console.WriteLine("{0} {1}", "Incorrect", isCorrect(new String[] { "........", "....R...", "........", ".R......", "........", "........", "..R.....", "........"}));
            Console.WriteLine("{0} {1}", "Correct", isCorrect(new String[] { "......R.", "....R...", "...R....", ".R......", "R.......", ".....R..", "..R.....", ".......R"}));
            Console.WriteLine("{0} {1}", "Incorrect", isCorrect(new String[] { "......R.", "....R...", "...R....", ".R......", "R.......", ".......R", "..R.....", ".......R"}));
            Console.WriteLine("{0} {1}", "Incorrect", isCorrect(new String[] { "........", "........", "........", "........", "........", "........", "........", "........" }));
        }
    }
}
