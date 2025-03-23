using Calculator.Data;
using Calculator.Logic;

namespace CalculatorTest
{
    [TestClass]
    public sealed class CalculatorTest
    {
        [TestMethod]
        public void calculatorService_addTwoNumbers_correctResult()
        {
            var calculator = new CalculatorService();
            Assert.AreEqual(3, calculator.add(1, 2));
        }

        [TestMethod]
        public void calculatorService_substractTwoNumbers_correctResult()
        {
            var calculator = new CalculatorService();
            Assert.AreEqual(1, calculator.substract(2, 1));
        }

        [TestMethod]
        public void calculatorService_multiplyTwoNumbers_correctResult()
        {
            var calculator = new CalculatorService();
            Assert.AreEqual(6, calculator.multiply(2, 3));
        }

        [TestMethod]
        public void calculatorService_divideTwoNumbers_correctResult()
        {
            var calculator = new CalculatorService();
            Assert.AreEqual(2, calculator.divide(6, 3));
        }

        [TestMethod]
        public void calculatorService_divideByZero_throwsArgumentException()
        {
            var calculator = new CalculatorService();
            Assert.ThrowsException<System.ArgumentException>(() => calculator.divide(6, 0));
        }

        [TestMethod]
        public void calculatorHistory_saveAndLoadSave_correctData()
        {
            var calculator = new CalculatorService();
            var history = new CalculatorHistory();

            double a = 5, b = 3;
            double result = calculator.add(a, b);
            string operation = $"{a} + {b}";

            history.saveCalculation(operation, result);

            foreach (var line in history.readHistory())
            {
                Assert.AreEqual(operation + " = " + result, line);
            }
        }
    }
}
