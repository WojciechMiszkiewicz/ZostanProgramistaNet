using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tydz_04_L11_PracaDomowa
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dzień dobry.\n");

            Console.WriteLine(GetProgramDescription());

            bool cont = true;
            do
            {
                cont = CheckNumber();
            } while (cont == true);

            Console.ReadKey();
        }

        /// <summary>
        /// Metoda uruchamiająca grę, nie wymaga parametrów.
        /// </summary>
        static bool CheckNumber()
        {
            int _userNumber;
            try
            {
                Console.Write("Wprowadź liczbę całkowitą: ");
                var answer = Console.ReadLine();
                if (answer.ToUpper() == "K")
                {
                    Console.WriteLine("\nPrzerywam pracę!");
                    return false;
                }
                if (int.TryParse(answer, out _userNumber) == true)
                {
                    
                    if (_userNumber % 2 == 0)
                    {
                        Console.WriteLine("To liczba parzysta.");
                    }
                    else
                    {
                        Console.WriteLine("To liczba NIEparzysta.");
                    }

                }
                else
                {
                    Console.WriteLine("To nie jest liczba!");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("W czasie pracy aplikacji wystąpił błąd: " + ex.Message);
            }
            finally
            {
                
            }
            return true;
        }

        static string GetProgramDescription()
        {
            var description = "Program wykrywa, czy wprowadziłeś liczbę parzystą czy nieparzystą i informuje Cię o wyniku." +
                "\nAby zakończyć program wpisz literę 'K' jak Koniec i wciśnij Enter.";
            return description;
        }


    }
}
