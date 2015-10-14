using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Reactive.Disposables;

namespace excercise
{
    class MyObservable : IObservable<int>
    {
        public MyObservable(Func<IObserver<int>, IDisposable> subscribe)
        {
            subscribe_ = subscribe;
        }

        public IDisposable Subscribe(IObserver<int> observer)
        {
            return subscribe_(observer);
        }
        private Func<IObserver<int>, IDisposable> subscribe_;
    };
}
