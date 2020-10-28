using System;
using System.Reflection.Metadata.Ecma335;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till Hangman");
            Console.WriteLine("Skriv ditt namn");
            string namn = Console.ReadLine();
            Console.WriteLine("hej " + namn);
            string[] ordlista = new string[3] { "hundleksak", "kiwi", "aprikos" };

            Random random = new Random();

            int slumpTal = random.Next(ordlista.Length);

            string ord = ordlista[slumpTal];

            char[] stars = new char[ord.Length];

            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = '*';
            }

            int antalGissningar = 10;

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

            } while (antalGissningar > 0);

        }
    }
}
