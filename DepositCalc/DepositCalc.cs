using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DepositCalc
{
    internal class DepositCalc
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Deposit: $");
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

                                var result = deposit * Math.Pow((1 + rate * 30 / 365 / 100), term);
                                var resultFormated = string.Format("{0:0.00}", result);

                                Console.WriteLine();
                                Console.Write($"Profit value: ${resultFormated}");
                                Console.ReadKey();
                            }
                        }
                    }
                }
            }
        }
    }
}
