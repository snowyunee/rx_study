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

    class week3
    {
        public static IObservable<TSource> Where<TSource>(
            IObservable<TSource> source,
            Func<TSource, bool> predicate)
        {
            return Observable.Create<TSource>(
                (observer) =>
                {
                    return source.Subscribe(
                        (v) => { if (predicate(v)) observer.OnNext(v); },
                        (e) => observer.OnError(e),
                        () => observer.OnCompleted());
                });

        }

        public static IObservable<TSource> SkipWhile<TSource>(
            IObservable<TSource> source,
            Func<TSource, bool> predicate)
        {
            return Observable.Create<TSource>(
                (observer) =>
                {
                    bool skip = true;
                    return source.Subscribe(
                        (v) =>
                        {
                            if (skip)
                            {
                                if (!predicate(v))
                                {
                                    skip = false;
                                    observer.OnNext(v);
                                }
                                return;
                            }
                            observer.OnNext(v);
                        },
                        (e) => observer.OnError(e),
                        () => observer.OnCompleted());
                });
        }

        public static IObservable<TSource> Distinct<TSource>(
            IObservable<TSource> source)
        {
            return Observable.Create<TSource>(
                (observer) =>
                {
                    HashSet<TSource> set = new HashSet<TSource>();                    
                    return source.Subscribe(
                       (v) =>
                       {
                          if (set.Add(v))
                              observer.OnNext(v);
                       },
                       (e) => observer.OnError(e),
                       () => observer.OnCompleted());
                });
        }

        public static void Run()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5};
            Where(arr.ToObservable(), v => (v % 2) == 0)
                .Subscribe(
                    Console.WriteLine,
                    e => Console.WriteLine("err"),
                    () => Console.WriteLine("complete"));
            int[] arr2 = new int[] { 1, 2, 3, 4, 5};
            SkipWhile(arr2.ToObservable(), v => (v < 3))
                .Subscribe(
                    Console.WriteLine,
                    e => Console.WriteLine("err"),
                    () => Console.WriteLine("complete"));
            int[] arr3 = new int[] { 1, 2, 3, 3, 3, 4, 5, 5, 5, 5};
            Distinct(arr3.ToObservable())
                .Subscribe(
                    Console.WriteLine,
                    e => Console.WriteLine("err"),
                    () => Console.WriteLine("complete"));
        }

    }
}
