using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DroopyExtensions
{
    public static class CircularEnumeratorExtensionMethod
    {

        public static IEnumerator<T> GetCircularEnumerator<T>(this IEnumerable<T> t) 
        {
            return new CircularEnumerator<T>(t.GetEnumerator());
        }

        private class CircularEnumerator<T> : IEnumerator<T>
        {
            private readonly IEnumerator _wrapedEnumerator;

            public CircularEnumerator(IEnumerator wrapedEnumerator)
            {
                this._wrapedEnumerator = wrapedEnumerator;
            }

            public object Current => _wrapedEnumerator.Current;

            T IEnumerator<T>.Current =>  (T)Current;

            public void Dispose()
            {
                
            }

            public bool MoveNext()
            {
                if (!_wrapedEnumerator.MoveNext())
                {
                    _wrapedEnumerator.Reset();
                    return _wrapedEnumerator.MoveNext();
                }
                return true;
            }

            public void Reset()
            {
                _wrapedEnumerator.Reset();
            }
        }
    }
    
}