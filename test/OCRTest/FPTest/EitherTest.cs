namespace OCRTest.FPTest {
    using Xunit;
    using OCR.FP;
    public class EitherTest {
        [Fact]
        public void itShouldHoldOkVal() {
            Assert.True(
                Either<string, string>.Right("hello")
                .Case<bool>(
                    error => false,
                    success => true
                )
            );
        }
        [Fact]
        public void itShouldHoldErrorVal() {
            Assert.False(
                Either<string, string>.Left("foobar")
                .Case<bool>(
                    error => false,
                    success => true
                )
            );
        }

        [Fact]
        public void itShouldSelectOkVal() {
            Assert.Equal(43,
                Either<string, int>.Right(42)
                .Select(n => n + 1)
                .FromRight()
            );
        }

        [Fact]
        public void itShouldSelectErrorVal() {
            Assert.Equal("hello world",
                Either<string, int>.Left("hello")
                .SelectLeft(s => s + " world")
                .FromLeft()
            );
        }

        [Fact]
        public void itShouldChainOkVal() {
            Assert.Equal(43,
                Either<string, int>.Right(42)
                .Chain<int>(n => Either<string, int>.Right(n + 1))
                .FromRight()
            );
        }

        [Fact]
        public void itShouldChainErrorVal() {
            Assert.Equal("error! Caused by Foo",
                Either<string, int>.Left("error!")
                .ChainLeft(s => Either<string, int>.Left(s + " Caused by Foo"))
                .FromLeft()
            );
        }

        [Fact]
        public void itShouldPreserveErrorVal() {
            Assert.Equal("Oh Noes!",
                Either<string, int>.Left("Oh Noes!")
                .Select(n => n + 1)
                .Chain<int>(n => Either<string, int>.Right(n + 5))
                .FromLeft()
            );
        }

        [Fact]
        public void itShouldPreserveOKVal() {
            Assert.Equal(42,
                Either<string, int>.Right(42)
                .SelectLeft(s => s + "!!")
                .ChainLeft<string>(s => Either<string, int>.Left(s + "!!"))
                .FromRight()
            );
        }

        [Fact]
        public void itShouldUnsafelyRetrieveLeft() {
            Assert.Throws<System.InvalidOperationException>(() => Either<int, int>.Right(42).FromLeft());
            Assert.Equal(42, Either<int, int>.Left(42).FromLeft());
        }

        [Fact]
        public void itShouldUnsafelyRetrieveRight() {
            Assert.Throws<System.InvalidOperationException>(() => Either<int, int>.Left(42).FromRight());
            Assert.Equal(42, Either<int, int>.Right(42).FromRight());
        }

        public void itShouldConvertFromJust() {
            Either<string, int> converted = Either<string, int>.FromMaybe(Maybe<int>.Just(42), "foo");

            Assert.Equal(42, converted.FromRight());
        }

        public void itShouldConvertFromNothing() {
            Either<string, int> converted = Either<string, int>.FromMaybe(Maybe<int>.Nothing(), "foo");

            Assert.Equal("foo", converted.FromLeft());
        }
    }
}