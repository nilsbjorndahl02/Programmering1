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
            //hur många antal gissningar man får sig innan spel avslutas och man förlorar

            do
            {
                Console.WriteLine("Gissa på ordet!");
                string gissning = Console.ReadLine();

                if (ord.Contains(gissning))
                {
                    //fyll på starWord
                    char[] ordChars = ord.ToCharArray();

                    for (int i = 0; i < ordChars.Length; i++)
                    {
                        if (gissning.ToCharArray()[0] == ordChars[i])
                        {
                            stars[i] = gissning.ToCharArray()[0];

                        }
                    }

                    Console.WriteLine(stars);

                    string starWord = new string(stars);

                    if (starWord.Contains("*"))
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Winner Winner Chicken Dinner!");
                        Console.WriteLine("Du vann och hade " + antalGissningar + " gissningar kvar!");
                        break;
                    }

                }
                else
                {
                    Console.WriteLine("Du gissa fel!");
                    antalGissningar--;
                    Console.WriteLine("Du har: " + antalGissningar + " kvar!");

                    //om personen gissar fel
                }
                if (antalGissningar == 0)
                {
                    Console.WriteLine("Du har förlorat Hehe!");
                    Console.WriteLine("Spelet är över mitt hemliga ord var " + ordlista[slumpTal]);
                   
                }

            } while (antalGissningar > 0); 

        }
    }
}
