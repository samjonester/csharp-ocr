namespace OCR.FP
{
    using System;
    public class Maybe<T>
    {
        private bool _hasVal;
        private T _val;

        public static Maybe<T> Just(T val) {
            return new Maybe<T> {
                _val = val,
                _hasVal = true
            };
        }

        public static Maybe<T> Nothing() {
            return new Maybe<T> {
                _val = default(T),
                _hasVal = false
            };
        }

        public U Case<U>(Func<U> nothingF, Func<T, U> justF) {
            if (_hasVal) {
                return justF(_val);
            } else {
                return nothingF();
            }
        }

        public Maybe<U> Select<U>(Func<T, U> f) {
            return Case(
                () => Maybe<U>.Nothing(),
                val => Maybe<U>.Just(f(val))
            );
        }

        public Maybe<U> Chain<U>(Func<T, Maybe<U>> f) {
            return Case(
                () => Maybe<U>.Nothing(),
                val => f(val)
            );
        }

        public T FromJust() {
            return Case(
                () => {throw new System.InvalidOperationException("This Maybe is Nothing.");},
                val => val
            );
        }

        public U FromNothing<U>(Func<U> f) {
            return Case(
                () => f(),
                _ => {throw new System.InvalidOperationException("This Maybe is a Just");}
            );
        }
    }
}