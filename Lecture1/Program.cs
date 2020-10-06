using Lecture1.Operations;
using System;
using System.Globalization;

#pragma warning disable CA1303

namespace Lecture1
{
    public static class Program
    {
        public static void Main()
        {
            // Цепочка обязанностей. См.: https://refactoring.guru/ru/design-patterns/chain-of-responsibility
            var operationHandlers = new IOperation[] { Sum.Instance, Difference.Instance };

            Console.Write("Enter operation: ");
            var operation = Console.ReadLine();

            var processed = false;
            foreach (var operationHandler in operationHandlers)
                if (operationHandler.IsOperationSupported(operation))
                {
                    var lhs = ReadInt("Enter 1st arg: ");
                    var rhs = ReadInt("Enter 2nd arg: ");
                    var result = operationHandler.Compute(lhs, rhs);
                    Console.WriteLine(result);
                    processed = true;
                    break;
                }

            if (!processed)
                Console.WriteLine("Unsupported operation!");
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
