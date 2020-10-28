using System;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Threading;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till Hangman");
            //consolen välkommnar en.
            Console.WriteLine("Skriv ditt namn");
            //consolen vill att du skriver denns namn.
            string namn = Console.ReadLine();
            //denna string gör så man kan skriva ut sitt namn.
            Console.WriteLine("Hej " + namn);
            //consolen hälsar på dig och skriver ut ditt namn.
            string[] ordlista = new string[3] { "hundleksak", "kiwi", "aprikos" };
            //denna string array är den som vi lägger in orden vi vill ha i vårat spel, just nu är det tre ord och så kommer en av dessa ord slumpas random och bli vald.


            Random random = new Random();
            //detta ör ett ranom nummer generator och kommer slumpa tal för oss.
            int slumpTal = random.Next(ordlista.Length);
            //här så skapas en int som kommer slumpa ordlistan som är våra 3 ord är i.
            string ord = ordlista[slumpTal];

            char[] stars = new char[ord.Length];
            // här så görs en char som kommer räkna ut var våran bokstav vi kommer gissa på kommer vara i vårat ord.
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = '*';
            }
            // denna forloop gör så att alla bokstäver som inte är gissade och utskrivna i orden kommer vara en sjärna.

            int antalGissningar = 10;
            //hur många antal gissningar man får sig innan spel avslutas och man förlorar.

            do
            {
                Console.WriteLine("Gissa på ordet!");
                string gissning = Console.ReadLine();

                if (ord.Contains(gissning))
                {
                    char[] ordChars = ord.ToCharArray();

                    for (int i = 0; i < ordChars.Length; i++)
                    {
                        if (gissning.ToCharArray()[0] == ordChars[i])
                        {
                            stars[i] = gissning.ToCharArray()[0];

                        }
                    }
                        //om bokstaven finns i ordet som du gissade på ska denna for loop byta ut sjärntecknen mot bokstaven som var rätt istället.
                    Console.WriteLine(stars);

                    string starWord = new string(stars);

                    if (starWord.Contains("*"))
                    {
                        continue;
                        //om bokstaven inte fanns i sjärnan så ska programmet bara forsätta tills man gissat rätt och vunnit eller förlorat.
                    }
                    else
                    {
                        Console.WriteLine("Winner Winner Chicken Dinner!");
                        Console.WriteLine("Du vann och hade " + antalGissningar + " gissningar kvar!");
                        break;
                        //om personen vinner får den veta det och hur många gissningar personen hade kvar när den vann.
                    }

                }
                else
                {
                    Console.WriteLine("Du gissa fel!");
                    antalGissningar--;
                    Console.WriteLine("Du har: " + antalGissningar + " kvar!");
                    //om personen gissar fel så får du veta det och du får också veta hur många gissningar du har kvar och antal gissningar minskar.
                }
                if (antalGissningar == 0)
                {
                    Console.WriteLine("Du har förlorat Hehe!");
                    Console.WriteLine("Spelet är över mitt hemliga ord var " + ordlista[slumpTal]);
                    //om antalet gissningar är 0 så har du förlorat och får veta vad det hemliga ordet var.
                }

            } while (antalGissningar > 0); 
            //detta ska köras så länge antalet gissningar är större än 0.
        }
    }
}
