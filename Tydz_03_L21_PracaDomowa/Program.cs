using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tydz_03_L21_PracaDomowa
{
    class Program
    {
        private static string _name;
        private static string _city;
        private static int _birthYear;
        private static int _birthMonth;
        private static int _birthDay;
        private static int _age;
        private static bool isBirthDay;

        static void Main(string[] args)
        {
            Console.WriteLine("Dzień dobry.");

            Questionnaire();

            CalculateAge(_birthYear, _birthMonth, _birthDay);

            Console.WriteLine(Welcome());



            Console.ReadKey();
        }

        static void CalculateAge(int _birthYear, int _birthMonth, int _birthDay)
        {
            DateTime birthDate = new DateTime(_birthYear, _birthMonth, _birthDay);
            DateTime now = DateTime.Now;
            _age = now.Year - birthDate.Year;
            if (birthDate.Date > now.AddYears(-_age))
            {
                _age--;
            }
            if (birthDate.Month == now.Month && birthDate.Day == now.Day)
            {
                isBirthDay = true;
            }
        }

        static string Welcome()
        {
            var letter = "";
            var lastChar = _age.ToString().Substring(_age.ToString().Length - 1) ;
            
            if (lastChar == "2" || lastChar == "3" || lastChar == "4")
            {
                letter = "a";
            }
            var congratulations = "";
            if (isBirthDay == true)
            {
                congratulations = "\nWszystkiego najlepszego z okazji urodzin!";
            }
            return $"Cześć {_name.ToUpper()}. Urodziłeś się w miejscowości {_city.ToUpper()} i masz {_age} lat{letter}.{congratulations}";
        }

        static bool Check(int testValue, int minValue, int maxValue)
        {
            if (testValue >= minValue && testValue<=maxValue)
            {
                return true;
            }
            return false;
        }

        static void Questionnaire()
        {
            try
            {

                _name = GetInputFromUser("imię");
                _city = GetInputFromUser("miejsce urodzenia");

                do
                {
                    int.TryParse(GetInputFromUser("rok urodzenia"), out _birthYear);
                } while (!Check(_birthYear, DateTime.Now.Year-120, DateTime.Now.Year));

                do
                {
                    int.TryParse(GetInputFromUser("miesiac urodzenia"), out _birthMonth);
                } while (!Check(_birthMonth, 1, 12));

                int daysInMonth = DateTime.DaysInMonth(_birthYear, _birthMonth); ;
                do
                {   
                    if (_birthDay > daysInMonth)
                    {
                        Console.WriteLine("Nie ma tyle dni w tym miesiącu.");
                    }
                    int.TryParse(GetInputFromUser("dzień urodzenia"), out _birthDay);
                } while (!Check(_birthDay, 1, daysInMonth));

            }
            catch (Exception ex)
            {
                Console.WriteLine("Wystąpił błąd: {0}", ex.Message);
            }

        }

        static string GetInputFromUser(string inputName)
        {
            
            var inputString = "";
            do
            {
                Console.WriteLine("Wprowadź {0}: ", inputName);
                inputString = Console.ReadLine();
                inputString = inputString.Trim();
            } while (inputString.Length == 0);

            return inputString;
        }
    }
}
