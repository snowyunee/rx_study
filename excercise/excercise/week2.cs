using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Disposables;

namespace excercise
{
    class week2
    {
    
        public static IObservable<int> Range(int seed, int count)
        {
            return Observable.Generate(
                seed,
                value => value < seed + count,
                value => value + 1,
                value => { Console.WriteLine("emit: {0}", value); return value; });
        }

        public static IObservable<int> Fibonacci()
        {
            return Observable.Generate(
                new KeyValuePair<int, int>(0, 1),
                value => true,
                value => new KeyValuePair<int, int>(value.Value, value.Key + value.Value),
                value => { Console.WriteLine("state: ({0}, {1}),", value.Key, value.Value); return value.Key; });
        }

        public static void Run()
        {
            Console.WriteLine("Range, print 0 1 2 3 4");
            Range(0, 100)
                .Take(5)
                .Subscribe(Console.WriteLine, () => Console.WriteLine("complete"));
            Task.Delay(2000).Wait();

            Console.WriteLine("Fibonacci, print 0 1 1 2 3 5 8");
            Fibonacci()
                .Take(7)
                .Subscribe(Console.WriteLine, () => Console.WriteLine("complete"));
            Task.Delay(2000).Wait();
        }
    }
}
