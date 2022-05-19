using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace FuelCalc
{
    internal class FuelCalc
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
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
                            Console.WriteLine();
                            Console.Write("Accelerate value: ");
                            string accelValueSTR = Console.ReadLine();

                            if (!Regex.IsMatch(accelValueSTR, validPattern))
                            {
                                Console.WriteLine();
                                Console.Write(invalidMassage);
                                Console.ReadKey();
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
            }
        }
    }
}
