using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Calc
{
    class Program
    {
        static void Main(string[] args)
        {
            

            try
            {
                Console.WriteLine("Podaj 1 liczbę:");
                var number1 = GetNumber();

                Console.WriteLine("Jaką operację chcesz wykonać? Możliwe operacje to: +, -, /, *");
                var action = Console.ReadLine();

                Console.WriteLine("Podaj 2 liczbę:");
                var number2 = GetNumber();

                var result = Calculate(number1, number2, action);

                Console.WriteLine("Wynik Twojego działania to: " + result);

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);

            }
            finally
            {
                Console.ReadKey();
            }
        }
        private static int GetNumber()
        {
            if (!int.TryParse(Console.ReadLine(), out int number))
            {
                throw new Exception("Wprowadć liczbę całkowitą.");
            }
            return number;
        }

        private static int Calculate(int number1, int number2, string action)
        {

            switch (action)
            {
                case "+":
                    return number1 + number2;
                    
                case "-":
                    return number1 - number2;
                    
                case "/":
                    return number1 / number2;
                    
                case "*":
                    return number1 * number2;

                default:
                    throw new Exception("Wybrałeś złą operację!");

            }

        }
    }
}
