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
        static void help()
        {
            Console.Clear();
            Console.WriteLine("Input Berupa Deret Bilangan dan operator");
            Console.WriteLine("Seperti  2(2*10)+30/(2^2)");
            Console.WriteLine("\nOperator yang bisa digunakan adalah");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("'^' '*' '/' '+' '-'");
            Console.ResetColor();
        }
        static void menu()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write("\t\t\t\t\t  Tekan '");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("0");
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write("' untuk keluar, '");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("h");
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("' untuk Help");
            Console.ResetColor();
        }
        static void Main(string[] args)
        {
            Calculator calc;
            string input;
            do
            {
                menu();
                ArrayList data = new ArrayList();
                Console.Write("Hitung   ::> ");
                input = Console.ReadLine();
                if (input == "0")
                {
                    Console.SetCursorPosition(20, 20);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Thanks for using this Calculator...");
                }
                else if (input == "h" || input == "H")
                    help();
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
                Console.Clear();
            } while (input != "0");
        }
    }
}
