using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc;
            string input;
            do
            {
                Console.Clear();
                ArrayList data = new ArrayList();
                Console.Write("Hitung   ::> ");
                input = Console.ReadLine();
                if (input == "0")
                {
                    Console.SetCursorPosition(20, 20);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Thanks for using this Calculator...");
                }
                else
                {
                    calc = new Calculator(input, data);
                    calc.validasi();
                    if (calc.cekError == true)
                    {
                        calc.convert();
                        if (calc.cekError == true)
                            calc.aritmatika();
                        else
                            Console.WriteLine("Input False");
                    }
                    else
                        Console.WriteLine("Input False");
                }
                Console.ReadKey();
            } while (input != "0");
        }
    }
}
