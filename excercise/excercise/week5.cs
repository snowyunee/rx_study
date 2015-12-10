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
    public static class week5
    {

    public static void Dump<T>(this IObservable<T> source, string name)
    {
      source.Subscribe(
          i=>Console.WriteLine("{0}-->{1}", name, i),
          ex=>Console.WriteLine("{0} failed-->{1}", name, ex.Message),
          ()=>Console.WriteLine("{0} completed", name));
    }

    static void ReadAccMoney(Action<int> callback)
        {
            Random r = new Random(Guid.NewGuid().GetHashCode());
            callback(r.Next(100, 1000));
        }

        static void ReadLimitMoney(Action<int> callback)
        {
            Random r = new Random(Guid.NewGuid().GetHashCode());
            callback(r.Next(100, 1000));
        }

        public static void Run()
        {
            var acc_money = Observable.Create<int>(
                o =>
                {
                    ReadAccMoney(o.OnNext);
                    return Disposable.Empty;
                });
            var limit_money = Observable.Create<int>(
                o =>
                {
                    ReadLimitMoney(o.OnNext);
                    return Disposable.Empty;
                });

            var obs = Observable.Interval(TimeSpan.FromSeconds(1))
                .SelectMany(
                    tick =>
                    {
                        //return acc_money.Zip(limit_money, (acc, limit) => new Tuple<bool, int, int>(true, acc, limit));
                        return acc_money.Zip(
                            limit_money,
                            (acc, limit) => new { tick = tick, enabled = acc > limit, acc = acc, limit = limit });
                    })
                .Publish();
            obs.DistinctUntilChanged(x => x.enabled)
                .Dump("changed");
            obs.Sample(TimeSpan.FromSeconds(3))
                .Dump("timeout");

            obs.Connect();
            Console.ReadLine();
        }
    }
}
