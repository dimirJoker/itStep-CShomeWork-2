using System;
using System.Data;

namespace SimpleCalc
{
    internal class SimpleCalc
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Type an expression: ");
                string expression = Console.ReadLine();

                try
                {
                    DataTable dt = new DataTable();
                    var result = dt.Compute($"{expression}", "");

                    if (result == DBNull.Value)
                    {
                        Console.WriteLine();
                        Console.Write("Going back...");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        try
                        {
                            if (double.IsInfinity((double)result))
                            {
                                Console.WriteLine();
                                Console.Write("Invalid value! Divide by zero.");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.Write($"The result is: {result}");
                                Console.ReadKey();
                            }
                        }
                        catch (InvalidCastException)
                        {
                            Console.WriteLine();
                            Console.Write($"The result is: {result}");
                            Console.ReadKey();
                        }
                    }
                }
                catch (EvaluateException)
                {
                    Console.WriteLine();
                    Console.Write("Invalid value! Only integer and float numbers are allowed.");
                    Console.ReadKey();
                }
                catch (SyntaxErrorException)
                {
                    Console.WriteLine();
                    Console.Write("Invalid value! Only elementary arithmetic operations are allowed.");
                    Console.ReadKey();
                }
            }
        }
    }
}