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


    class ex1
    {
        public static IObservable<int> Create(Func<IObserver<int>, IDisposable> f)
        {
            return new MyObservable(f);
        }
    }
}
