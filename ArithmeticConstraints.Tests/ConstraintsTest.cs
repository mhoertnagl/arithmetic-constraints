using static ArithmeticConstraints.Constraints;

namespace ArithmeticConstraints.Tests
{
    public class ConstraintsTest
    {
        [Fact]
        public void TestTemeratureConverter()
        {
            var C = Variable("C");
            var F = Variable("F");

            Equal(9 * C, 5 * (F - 32));
            // var _ = 9 * C == 5 * (F - 32);

            Set(C, 0);

            Assert.Equal(32, F.GetValue());

            Unset(C);
            Set(F, 86);

            Assert.Equal(30, C.GetValue());
        }
    }
}