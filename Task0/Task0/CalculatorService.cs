namespace Calculator.Logic
{
    public class CalculatorService
    {
        public double add(double a, double b)
        {
            return a + b;
        }

        public double substract(double a, double b)
        {
            return a - b;
        }

        public double multiply(double a, double b)
        {
            return a * b;
        }

        public double divide(double a, double b)
        {
            if (b == 0)
            {
                throw new System.ArgumentException("Cannot divide by zero.");
            }
            return a / b;
        }
    }
}
