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
    public static class week4
    {
        public static IObservable<TResult> MySelect<TSource, TResult>(
            this IObservable<TSource> source,
            Func<TSource, TResult> selector)
        {
            return source.SelectMany(v => Observable.Return(selector(v)));
        }

        public static IObservable<TSource> MyWhere<TSource>(
            this IObservable<TSource> source,
            Func<TSource, bool> predicate)
        {
            return source.SelectMany(
                (v) =>
                {
                    if (predicate(v))
                        return Observable.Return(v);
                    else
                        return Observable.Empty<TSource>();
            	});
        }

        public static void Run()
        {
            Observable.Range(100, 10)
            .MySelect(v => v * 2)
            .MyWhere(v => v % 2 == 0)
            .Subscribe(
                Console.WriteLine,
                e => Console.WriteLine("err"),
                () => Console.WriteLine("complete"));
        }
    }
}
