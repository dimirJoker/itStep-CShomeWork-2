using System;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;

namespace All_in_oneCalc
{
    internal class AllInOneCalc
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Simple calculator");
                Console.WriteLine("2. Fuel calculator");
                Console.WriteLine("3. Deposit calculator");
                Console.WriteLine("0. Exit");
                Console.WriteLine();
                Console.Write("Type an option number: ");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey select = keyInfo.Key;

                switch (select)
                {
                    default:
                        {
                            Console.WriteLine();
                            Console.Write("Invalid input! The only existed options number are allowed.");
                            Console.ReadKey();
                            break;
                        }
                    case ConsoleKey.D0:
                    case ConsoleKey.NumPad0:
                        {
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("Now closing...");
                            Console.WriteLine();
                            Environment.Exit(0);
                            break;
                        }
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        {
                            Console.Clear();
                            Console.WriteLine("(none to back)");
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
                            catch (DivideByZeroException)
                            {
                                Console.WriteLine();
                                Console.Write("Invalid value! Divide by zero.");
                                Console.ReadKey();
                            }
                            goto case ConsoleKey.D1;
                        }
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        {
                            Console.Clear();
                            Console.WriteLine("(none to back)");
                            Console.Write("Fuel count: ");
                            string fuelCountSTR = Console.ReadLine();

                            if (fuelCountSTR == "")
                            {
                                Console.WriteLine();
                                Console.Write("Going back...");
                                Console.ReadKey();
                                break;
                            }
                            else
                            {
                                var validPattern = @"^(0*[1-9][0-9]*(\.[0-9]+)?|0+\.[0-9]*[1-9][0-9]*)$";
                                string invalidMassage = "Invalid value! Only positive integer and float numbers are allowed.";

                                if (!Regex.IsMatch(fuelCountSTR, validPattern))
                                {
                                    Console.WriteLine();
                                    Console.Write(invalidMassage);
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.Write("Fuel usage: ");
                                    string fuelUsageSTR = Console.ReadLine();

                                    if (!Regex.IsMatch(fuelUsageSTR, validPattern))
                                    {
                                        Console.WriteLine();
                                        Console.Write(invalidMassage);
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Accelerate:
                                        Console.WriteLine();
                                        Console.Write("Accelerate value: ");
                                        string accelValueSTR = Console.ReadLine();

                                        if (!Regex.IsMatch(accelValueSTR, validPattern))
                                        {
                                            Console.WriteLine();
                                            Console.Write(invalidMassage);
                                            Console.ReadKey();
                                            goto Accelerate;
                                        }
                                        else
                                        {
                                            var ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                                            ci.NumberFormat.NumberDecimalSeparator = ".";

                                            float fuelCount = float.Parse(fuelCountSTR, ci);
                                            float fuelUsage = float.Parse(fuelUsageSTR, ci);
                                            float accelValue = float.Parse(accelValueSTR, ci);

                                            var time = fuelCount / fuelUsage;
                                            var maxSpeed = accelValue * time;
                                            var maxDistance = accelValue * (time * time) / 2;

                                            var speedFormated = string.Format("{0:0.00}", maxSpeed);
                                            var distanceFormated = string.Format("{0:0.00}", maxDistance);

                                            Console.WriteLine();
                                            Console.WriteLine($"Max. speed: {speedFormated}");
                                            Console.Write($"Max. distance: {distanceFormated}");
                                            Console.ReadKey();
                                        }
                                    }
                                }
                            }
                            goto case ConsoleKey.D2;
                        }
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        {
                            Console.Clear();
                            Console.WriteLine("(none to back)");
                            Console.Write("Regular deposit: $");
                            string depositSTR = Console.ReadLine();

                            if (depositSTR == "")
                            {
                                Console.WriteLine();
                                Console.Write("Going back...");
                                Console.ReadKey();
                                break;
                            }
                            else
                            {
                                var validPattern = @"^(0*[1-9][0-9]*(\.[0-9]+)?|0+\.[0-9]*[1-9][0-9]*)$";
                                string invalidMassage = "Invalid value! Only positive integer and float numbers are allowed.";

                                if (!Regex.IsMatch(depositSTR, validPattern))
                                {
                                    Console.WriteLine();
                                    Console.Write(invalidMassage);
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.Write("Interest rate: %");
                                    string rateSTR = Console.ReadLine();

                                    if (!Regex.IsMatch(rateSTR, validPattern))
                                    {
                                        Console.WriteLine();
                                        Console.Write(invalidMassage);
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine();
                                        Console.Write("Deposit term: month ");
                                        string termSTR = Console.ReadLine();

                                        if (!Regex.IsMatch(termSTR, validPattern))
                                        {
                                            Console.WriteLine();
                                            Console.Write(invalidMassage);
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            var ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                                            ci.NumberFormat.NumberDecimalSeparator = ".";

                                            float deposit = float.Parse(depositSTR, ci);
                                            float rate = float.Parse(rateSTR, ci);
                                            float term = float.Parse(termSTR, ci);

                                            var result = (deposit * Math.Pow((1 + rate * 30 / 365 / 100), term))*term;
                                            var resultFormated = string.Format("{0:0.00}", result);

                                            Console.WriteLine();
                                            Console.Write($"Profit value: ${resultFormated}");
                                            Console.ReadKey();
                                        }
                                    }
                                }
                            }
                            goto case ConsoleKey.D3;
                        }
                }
            }
        }
    }
}
