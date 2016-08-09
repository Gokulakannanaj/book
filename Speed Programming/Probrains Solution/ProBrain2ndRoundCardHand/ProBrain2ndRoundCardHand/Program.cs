using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProBrain2ndRoundCardHand
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("CardHands.txt");
            List<string> Card = new List<string>();

            int c=0,Length = int.Parse(reader.ReadLine());
            for (int i = 0; i < Length; i++)
            {
                string sample = reader.ReadLine();
                string[] bits = sample.Split(' ');
                for (int j = 1; j <= int.Parse(bits[0]); j++)
                {
                    Card.Add(bits[j]);    
                }
            
            }
            int counter = 0;
            while (counter < Card.Count)
            {
                /*
                for (int i = counter+1; i < Card.Count; i++)
                {
                    c = Card.IndexOf(Card.ElementAt(counter), i);
                    if (c != -1)
                    {
                        Card.Remove(Card.ElementAt(counter));
                    }
                }
                 */

                int i = counter + 1;
                c = Card.IndexOf(Card.ElementAt(counter), i);
                if (c != -1)
                {
                    Card.Remove(Card.ElementAt(counter));
                    counter--;
                }
                counter++;
            }

            Console.WriteLine(Card.Count);
        }
    }
}
