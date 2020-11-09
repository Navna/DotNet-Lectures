using Lecture2.Operations;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Lecture2
{
    public class Program
    {
        public static void Main()
        {
            var map = new Dictionary<string, IOperation>()
            {
                { "+", Sum.Instance },
                { "-", Difference.Instance }
            };

            Console.Write("Enter operation: ");
            var operation = Console.ReadLine();

            if (map.TryGetValue(operation, out var operationHandler))
            {
                var lhs = ReadInt("Enter 1st arg: ");
                var rhs = ReadInt("Enter 2nd arg: ");
                var result = operationHandler.Compute(lhs, rhs);
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Unsupported operation!");
            }
        }

        private static int ReadInt(string prompt)
        {
            string line;
            int result;
            do
            {
                Console.Write(prompt);
                line = Console.ReadLine();
            } while (!int.TryParse(line, NumberStyles.Integer, CultureInfo.InvariantCulture, out result));
            return result;
        }
    }
}
