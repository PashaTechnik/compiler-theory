using System;

namespace compiler_theory
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser p = new Parser();
            double q = Parser.CalculateExpression("(2 + 2) - (2 * 7)");
            Console.WriteLine(q);
            
            double f(double x) => x * x / (x - 1);
            var result = MathСalculations.Simpson(f, -1, 10, 1000);
            Console.WriteLine("S = {0}", result);

        }
    }
}