namespace OCRTest.FPTest
{
    using Xunit;
    using OCR.FP;
    public class MaybeTest {
        [Fact]
        public void itShouldHoldVal() {
            Assert.True(
                Maybe<int>.Just(42)
                .Case(
                    () => false,
                    _ => true
                )
            );
        }

        [Fact]
        public void itShouldHoldNothing() {
            Assert.False(
                Maybe<int>.Nothing()
                .Case(
                    () => false,
                    _ => true
                )
            );
        }

        [Fact]
        public void itShouldSelectVal() {
            Assert.Equal(43,
                Maybe<int>.Just(42)
                .Select(n => n + 1)
                .FromJust()
            );
        }

        [Fact]
        public void itShouldChainVal() {
            Assert.Equal(43,
                Maybe<int>.Just(42)
                .Chain<int>(n => Maybe<int>.Just(n + 1))
                .FromJust()
            );
        }

        [Fact]
        public void itShouldSkipMissingVal() {
            Assert.Equal("error!",
                Maybe<int>.Nothing()
                .Select(n => n + 1)
                .Chain<int>(n => Maybe<int>.Just(n + 5))
                .FromNothing(() => "error!")
            );
        }

        [Fact]
        public void itShouldHaveUnsafeGet() {
            Assert.Equal(42,
                Maybe<int>.Just(42).FromJust()
            );

            Assert.Throws<System.InvalidOperationException>(() => Maybe<int>.Nothing().FromJust());
        }
    }
}