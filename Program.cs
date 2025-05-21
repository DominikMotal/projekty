using System;
using System.Threading;

namespace Obesenec
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] slova = { "auto", "skola", "barva", "nehoda", "program", "jablko", "jidlo" };
            Random rnd = new Random();
            string tajneslovo = slova[rnd.Next(slova.Length)];
            
            char[] uhodnute = new string('_', tajneslovo.Length).ToCharArray();
            char[] pouzitetipy = new char[20];
            int pocetpouzitychpis = 0;
            int pokusy = 0;
           

            while (true)
            {
                Console.Clear();

                 int barvy = 10 - pokusy;
            if (barvy >= 7)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (barvy >= 4)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
                Console.WriteLine($"Zbývající pokusy: {barvy}");
                Console.ResetColor();


                Console.WriteLine("Slovo: " + new string(uhodnute));
                Console.Write("Použité písmena: ");
                for (int i = 0; i < pocetpouzitychpis; i++)
                {
                    Console.Write(pouzitetipy[i] + " ");
                }
                Console.WriteLine();

                Console.WriteLine("Zadej písmeno (nebo konec):");
                string vstup = Console.ReadLine();

                if (vstup == "konec")
                    break;

                if (vstup.Length != 1 || !char.IsLetter(vstup[0]))
                {
                    Console.WriteLine("Zadej prosím 1 platné písmeno!");
                    Thread.Sleep(1000);
                    continue;
                }

                char tip = vstup[0];

                if (Array.IndexOf(pouzitetipy, tip, 0, pocetpouzitychpis) != -1)
                {
                    Console.WriteLine("Toto písmeno už jsi zkoušel.");
                    Thread.Sleep(1000);
                    continue;
                }

                pouzitetipy[pocetpouzitychpis++] = tip;

                bool nasel = false;
                for (int i = 0; i < tajneslovo.Length; i++)
                {
                    if (tajneslovo[i] == tip)
                    {
                        uhodnute[i] = tip;
                        nasel = true;
                    }
                }

                if (!nasel)
                {
                    pokusy++;
                }

                if (!uhodnute.Contains('_'))
                {
                    Console.Clear();
                    Console.WriteLine("Gratuluji, uhodl jsi slovo: " + tajneslovo);
                    Console.WriteLine("Chceš hrát znovu? (a/n)");
                    string odp = Console.ReadLine();

                    if (odp == "a")
                    {
                        tajneslovo = slova[rnd.Next(slova.Length)];
                        uhodnute = new string('_', tajneslovo.Length).ToCharArray();
                        pouzitetipy = new char[20];
                        pocetpouzitychpis = 0;
                        pokusy = 0;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Díky za hru!");
                        break;
                    }
                }

                if (pokusy >= 10)
                {
                    Console.Clear();
                    Console.WriteLine(" Slovo bylo: " + tajneslovo);
                    break;
                }
            }
        }
    }
}
