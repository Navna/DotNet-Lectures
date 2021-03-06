﻿using Lecture1.Operations;
using System;
using System.Globalization;
using System.Net.Http.Headers;

#pragma warning disable CA1303

namespace Lecture1
{
    public static class Program
    {
        public static void Main()
        {
            StructVsClass();

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

        private static void StructVsClass()
        {
            // Работа с типами значений
            Console.WriteLine("VALUE TYPE DEMO:");
            var s1a = new StructExample() { A = 1 }; // На стеке!
            var s1b = new StructExample() { A = 1 }; // На стеке!
            var s2 = new StructExample() { A = 2 }; // На стеке!
            Console.WriteLine(s1a.Equals(s1b));
            Console.WriteLine(s1a.Equals(s2));

            TryChangeStruct(s2);
            Console.WriteLine(s2.A);
            Console.WriteLine();

            // Работа с ссылочными типами
            Console.WriteLine("REFERENCE TYPE DEMO:");
            var c1a = new ClassExample() { A = 1 }; // В куче!
            var c1b = new ClassExample() { A = 1 }; // В куче!
            var c2 = new ClassExample() { A = 2 };  // В куче!
            Console.WriteLine(c1a.Equals(c1b));
            Console.WriteLine(c1a.Equals(c2));
            Console.WriteLine(c1a == c1b);
            Console.WriteLine(c1a == c2);

            TryChangeClass(c2);
            Console.WriteLine(c2.A);
            Console.WriteLine();
        }

        private static void TryChangeStruct(StructExample s)
        {
            s.A = 5;
        }

        private static void TryChangeClass(ClassExample c)
        {
            c.A = 5;
        }
    }
}
