using Task0;

namespace Task0Test
{
    [TestClass]
    public sealed class CalculatorTest
    {
        [TestMethod]
        public void add_addTwoNumbers_correctResult()
        {
            var calculator = new Task0.Calculator();
            Assert.AreEqual(3, calculator.add(1, 2));
        }

        [TestMethod]
        public void substract_substractTwoNumbers_correctResult()
        {
            var calculator = new Task0.Calculator();
            Assert.AreEqual(1, calculator.substract(2, 1));
        }

        [TestMethod]
        public void multiply_multiplyTwoNumbers_correctResult()
        {
            var calculator = new Task0.Calculator();
            Assert.AreEqual(6, calculator.multiply(2, 3));
        }

        [TestMethod]
        public void divide_divideTwoNumbers_correctResult()
        {
            var calculator = new Task0.Calculator();
            Assert.AreEqual(2, calculator.divide(6, 3));
        }
    }
}
