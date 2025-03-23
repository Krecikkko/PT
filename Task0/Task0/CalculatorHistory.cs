using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Data
{
    public class CalculatorHistory
    {
        private readonly string filePath = "history.txt";

        public void saveCalculation(string operation, double result)
        {
            string entry = $"{operation} = {result}";
            File.AppendAllText(filePath, entry + Environment.NewLine);
        }

        public List<string> readHistory()
        {
            if (!File.Exists(filePath))
            {
                return new List<string>();
            }
            return new List<string>(File.ReadAllLines(filePath));
        }
    }
}
