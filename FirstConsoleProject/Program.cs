using System;
using FirstConsoleProject.Models;
using FirstConsoleProject.Interfaces;
using FirstConsoleProject.Services;

namespace FirstConsoleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Employee employee = new Employee();
            //Console.WriteLine(employee.No);
            do
            {
                Console.WriteLine("Etmek Istediyiniz Emeliyyatin Nomresini Daxil Edin:");
                Console.WriteLine("1 - Departamentlerin siyahisini gostermek");
                Console.WriteLine("2 - Departament yaratmaq");
                Console.WriteLine("3 - Departamentde deyishiklik etmek");
                Console.WriteLine("4 - Ishcilerin siyahisini gostermek");
                Console.WriteLine("5 - Departamentdeki ishcilerin siyahisini gostermek");
                Console.WriteLine("6 - Ishci elave etmek");
                Console.WriteLine("7 - Ishci uzerinde deyishiklik etmek");
                Console.WriteLine("8 - Departamentden ishci silinmesi");

                string answerStr = Console.ReadLine();
                int answerNum;

                while (!int.TryParse(answerStr, out answerNum) || answerNum < 1 || answerNum > 8)
                {
                    Console.WriteLine("Duzgun Secim Edin");
                    answerStr = Console.ReadLine();
                }
                switch (answerNum)
                {
                    case 1:
                        
                    default:
                        break;
                    case 2:

                    case 3:

                    case 4:

                    case 5:

                    case 6:

                    case 7:

                    case 8:
                        break;
                }

            } while (true);
        }
    }
}

