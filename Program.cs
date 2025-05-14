namespace cisla;

class Program
{
    static void Main(string[] args)
    {
        while(true)
        {
            Random rnd = new Random();
            int cislo = rnd.Next (1,100);
            int cislotip = 0;


            Console.WriteLine("Hádej číslo od 1-100");

            while(cislotip!=cislo)
            {
                
            
                Console.Write("Zadej číslo 1-100: ");
                
                 Console.ForegroundColor = ConsoleColor.DarkGreen;
                 string vstup = Console.ReadLine();
                 Console.ResetColor();

                 if(!int.TryParse(vstup , out cislotip))
                 {
                    Console.WriteLine("Zadávej jenom čísla 😡");
                    continue;
                 }
                 


                if(cislotip <cislo) 
                {
                  Console.WriteLine("Zadej větší číslo");
                }
                else if ( cislotip >cislo)
                {
                    Console.WriteLine("Zadej menší číslo");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("správně 😎")  ;  
                    Console.ResetColor();
                }
                

                 


            }
             Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("chceš hrát znovu? a/n");
            Console.ResetColor();
            
            string odp = Console.ReadLine();

            switch (odp)
            {
                case  "a":
                break;

                case  "n":
                Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Díky za hru");
                 Console.ResetColor();
                 Thread.Sleep(500);
                return;
                default:
             Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("neplatná odpověd");
                Console.ResetColor();
                return;
            }
        }
    }
}
