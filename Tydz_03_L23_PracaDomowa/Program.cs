using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tydz_03_L23_PracaDomowa
{
    class Program
    {
        private static int _minValue;
        private static int _maxValue;
        private static int _searchValue;
        private static int _userAnswer;
        private static List<int> _userAnswersList = new List<int>();
        private static int _numberOfTries;
        static void Main(string[] args)
        {
            Console.WriteLine("Dzień dobry.\n");

            Console.WriteLine(GetGameInfo());

            if (Question())
            {
                StartGame();
            }
           

            Console.ReadKey();
        }

        static void StartGame()
        {
            _minValue = 0;
            _maxValue = 100;
            var random = new Random();
            _searchValue = random.Next(_minValue, _maxValue+1);
            Console.WriteLine(_searchValue);
            try
            {
                do
                {
                    Console.Write("Wprowadź szukaną liczbę: ");
                    var answer = Console.ReadLine();
                    if (answer.ToUpper() == "K")
                    {
                        Console.WriteLine("\nPrzerywam grę!");
                        return;
                    }
                    if (int.TryParse(answer, out _userAnswer) == true)
                    {
                        _numberOfTries++;
                        if (_userAnswersList.Contains(_userAnswer) == true)
                        {
                            Console.WriteLine("\nTaką liczbę już podawałeś. Skup się!");
                        }
                        else
                        {

                            if (_userAnswer < _searchValue)
                            {
                                Console.WriteLine("Twoja liczba jest za mała.");
                            }
                            else if (_userAnswer > _searchValue)
                            {
                                Console.WriteLine("Twoja liczba jest za duża.");
                            }
                            else
                            {
                                Console.WriteLine($"Odgladłeś liczbę przy {_numberOfTries} próbach. GRATULUJĘ!");
                            }
                            _userAnswersList.Add(_userAnswer);
                        }
                    }
                    else
                    {
                        Console.WriteLine("To nie jest liczba!");
                    }
                } while (_userAnswer != _searchValue);


            }
            catch (Exception ex)
            {
                Console.WriteLine("W czasie pracy aplikacji wystąpił błąd: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("\n\nDo widzenia!");
            }

        }

        static bool Question()
        {
            string answer = "";
            do
            {
                Console.WriteLine("Czy chcesz rozpocząć grę? T/N");
                answer = Console.ReadLine().ToUpper();
                if (answer == "T")
                {
                    return true;
                }
                else if (answer == "N")
                {
                    return false;
                }
            } while (true);
        }

        static string GetGameInfo()
        {
            var description = "Jest to gra, która polega na odgadnięciu przez Ciebie liczby wylosowanej przez komputer.\n" +
                "Liczby są z zakresu od 0 do 100, a ilość prób jest nieogranoiczona i zliczana. Im mniej prób, tym lepszy wynik. " +
                "\nAby zakończyć grę wpisz literę 'K' jak Koniec i wciśnij Enter.";
            return description;
        }
    }


}
