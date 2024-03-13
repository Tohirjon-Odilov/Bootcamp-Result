using Calculator;

namespace CalcUnitTest
{
    public class SuperCalcUnitTests
    {
        [Fact]
        public void Add()
        {
            int x = 15;
            int y = 45;
            int exeptedValue = 60;

            int res = SuperCalculator.Add(x, y);

            Assert.Equal(exeptedValue, res);
        }

        [Theory]
        [InlineData(10, 10, 20)]
        [InlineData(12, 11, 23)]
        [InlineData(21, 99, 120)]
        public void AddWithTheory(int x, int y, int exVal)
        {
            int res = SuperCalculator.Add(x, y);
            Assert.Equal(res, exVal);
        }

        [Fact]
        public void Substract()
        {
            int x = 10;
            int y = 10;
            int exval = 10;

            int res = SuperCalculator.Substract(x, y);

            Assert.Equal(exval, res);
        }


        [Theory]
        [InlineData(23, 2, 5)]
        [InlineData(200, 1, 199)]
        [InlineData(0, 2, -2)]
        public void SubstractWithTheory(int x, int y, int exVal)
        {
            int res = SuperCalculator.Substract(x, y);

            Assert.Equal(exVal, res);
        }

        [Fact]
        public void Multiple()
        {
            int x = 10;
            int y = 5;
            int exval = 50;

            int res = SuperCalculator.Multiple(x, y);

            Assert.Equal(exval, res);
        }

        [Theory]
        [InlineData(5, -1, -5)]
        [InlineData(0, 9, 0)]
        [InlineData(4, 1, 4)]
        public void MultipleWithTheory(int x, int y, int exVal)
        {
            int res = SuperCalculator.Multiple(x, y);

            Assert.Equal(exVal, res);
        }

        [Fact]
        public void TestDevide()
        {
            int x = 10;
            int y = 5;
            int exval = 2;

            int res = SuperCalculator.Devide(x, y);

            Assert.Equal(exval, res);
        }

        [Theory]
        [InlineData(10, 0, 0)]
        [InlineData(0, 10, 0)]
        [InlineData(50, 10, 5)]
        public void DevideWithTheory(int x, int y, int exVal)
        {
            if (y == 0)
            {
                Assert.Throws<DivideByZeroException>(() => SuperCalculator.Devide(x, y));
            } else
            {
                var res = SuperCalculator.Devide(x, y);
                Assert.Equal(exVal, res);
            }
        }
    }
}
