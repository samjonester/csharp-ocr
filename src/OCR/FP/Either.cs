namespace OCR.FP {
    using System;
    public class Either<L, R> {
        private bool _isR;
        private L _l;
        private R _r;

        public static Either<L, R> Right(R r) {
            return new Either<L, R> {
                _r = r,
                _isR = true
            };
        }

        public static Either<L, R> Left(L l) {
            return new Either<L, R> {
                _l = l,
                _isR = false
            };
        }
        public U Case<U>(Func<L, U> leftF, Func<R, U> rightF) {
            if (_isR) {
                return rightF(_r);
            } else {
                return leftF(_l);
            }
        }

        public Either<L, U> Select<U>(Func<R, U> f) {
            return Case(
                l => Either<L, U>.Left(_l),
                r => Either<L, U>.Right(f(_r))
            );
        }

        public Either<U, R> SelectLeft<U>(Func<L, U> f) {
            return Case(
                l => Either<U, R>.Left(f(l)),
                r => Either<U, R>.Right(r)
            );
        }

        public Either<L, U> Chain<U>(Func<R, Either<L, U>> f) {
            return Case(
                l => Either<L, U>.Left(l),
                r => f(r)
            );
        }

        public Either<U, R> ChainLeft<U>(Func<L, Either<U, R>> f) {
            return Case(
                l => f(l),
                r => Either<U, R>.Right(r)
            );
        }


        public L FromLeft() {
            return Case(
                l => l,
                r => {throw new System.InvalidOperationException("Either is a Right");}
            );
        }

        public R FromRight() {
            return Case(
                _ => {throw new System.InvalidOperationException("Either is a Left");},
                r => r
            );
        }

        public static Either<L, R> FromMaybe(Maybe<R> maybe, L leftVal) {
            return maybe.Case(
                () => Either<L, R>.Left(leftVal),
                val => Either<L, R>.Right(val)
            );
        }
    }
}