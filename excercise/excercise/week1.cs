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
    class week1
    {
        public static IObservable<int> Create(Func<IObserver<int>, IDisposable> f)
        {
            return new MyObservable(f);
        }
        public static IDisposable Subscribe(IObserver<int> observer)
        {
            observer.OnNext(0);
            observer.OnNext(1);
            observer.OnNext(2);
            observer.OnCompleted();
            return Disposable.Empty;
        }

        public static IObservable<int> Range(int seed, int count)
        {
            return Observable.Create<int>((observer) => 
                {
                    for (int i = 0; i < count; ++i)
                    {
                      observer.OnNext(seed);
                      ++seed;
                    }
                    observer.OnCompleted();
                    return Disposable.Empty;
                });
        }

        public static IObservable<int> Timer(int ms)
        {
            return Observable.Create<int>((observer) => 
                {
                    var timer = new System.Timers.Timer(ms);
                    timer.Elapsed += (sender, e) =>
                    {
                        timer.Stop();
                        timer.Dispose();
                        observer.OnNext(0);
                        observer.OnCompleted();
                    };
                    timer.Start();

                    return Disposable.Empty;
                });
        }

        public static IObservable<int> Interval(int ms)
        {
            return Observable.Create<int>((observer) => 
                {
                    var timer = new System.Timers.Timer(ms);
                    int v = 0;
                    timer.Elapsed += (sender, e) =>
                    {
                        observer.OnNext(v);
                        ++v;
                    };
                    timer.Start();

                    return Disposable.Empty;
                });
        }
        public static void Run()
        {
            Console.WriteLine("Create Observer with Subscribe. print 0 1 2");
            var obsarvable = Create(Subscribe);
            obsarvable.Subscribe(Observer.Create<int>(
                Console.WriteLine,
                () => Console.WriteLine("complete")));
            Task.Delay(2000).Wait();

            Console.WriteLine("Range, print 0 1 2 3 4");
            Range(0, 5).Subscribe(Console.WriteLine, () => Console.WriteLine("complete"));
            Task.Delay(2000).Wait();

            Console.WriteLine("Timer, 1초 후 0");
            Timer(1000).Subscribe(Console.WriteLine, () => Console.WriteLine("complete"));
            Task.Delay(2000).Wait();

            Console.WriteLine("Interval, 매 1초 후 0,1,2...");
            Interval(1000).Subscribe(Console.WriteLine, () => Console.WriteLine("complete"));
            Task.Delay(10000).Wait();
        }
    }
}
