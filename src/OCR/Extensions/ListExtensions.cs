namespace OCR.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FP;

    public static class ListExtensions
    {

        public static IEnumerable<IEnumerable<T>> Transpose<T>(
        this IEnumerable<IEnumerable<T>> @this)
        {
            var enumerators = @this.Select(t => t.GetEnumerator())
                                   .Where(e => e.MoveNext());

            while (enumerators.Any())
            {
                yield return enumerators.Select(e => e.Current);
                enumerators = enumerators.Where(e => e.MoveNext());
            }
        }

        public static string StrJoin<T>(this IEnumerable<T> @this, string delimiter = "") {
            return @this.Select(t => t.ToString()).Aggregate((xs, x) => xs + delimiter + x.ToString());
        }

        public static Either<IEnumerable<L>, IEnumerable<R>> LiftToEither<L, R>(this IEnumerable<Either<L, R>> @this, Func<R, L> rightToLeft)
        {
            return @this.Aggregate(
                Either<IEnumerable<L>, IEnumerable<R>>.Right(new List<R>()),
                (current, next) => next.Case(
                    invalid => Either<IEnumerable<L>, IEnumerable<R>>.Left(current.Case(
                        error => error.Append(invalid),
                        success => success.Select(rightToLeft).Append(invalid)
                    )),
                    valid => current.Case(
                        error => Either<IEnumerable<L>, IEnumerable<R>>.Left(error.Append(rightToLeft(valid))),
                        success => Either<IEnumerable<L>, IEnumerable<R>>.Right(success.Append(valid))
                    )
                )
            );
        }
    }
}