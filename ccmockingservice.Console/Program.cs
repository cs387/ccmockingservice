using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ccmockingservice.Console
{
    class Program
    {
        private static string[] generateCreditCards(int startWith, int length)
        {
            System.Console.WriteLine("---gen new set of cc---");
            int count = 4;

            string[] arrCreditCards = new string[count];
            for (int i = 0; i < count; i++)
            {
                var genToken = generateCreditCardNumber(startWith, length);
                arrCreditCards[i] = genToken;
                //System.Console.WriteLine($"Gen Token : {genToken}");
            }
            return arrCreditCards;

        }
        private static string generateCreditCardNumber(int startWith, int length)
        {
            Random _random = new Random(Guid.NewGuid().GetHashCode());

            int[] checkArray = new int[length - 1];

            var cardNum = new int[length];

            for (int d = length - 2; d >= 0; d--)
            {
                cardNum[d] = _random.Next(0, 9);
                checkArray[d] = (cardNum[d] * (((d + 1) % 2) + 1)) % 9;
            }
            cardNum[0] = startWith;
            cardNum[length - 1] = (checkArray.Sum() * 9) % 10;

            var sb = new StringBuilder();

            for (int d = 0; d < length; d++)
            {
                sb.Append(cardNum[d].ToString());
            }
            System.Console.WriteLine($"value = {sb.ToString()}");
            return sb.ToString();
        }
        static void Main(string[] args)
        {
            
           string []dd= generateCreditCards(4, 16);
            System.Console.ReadKey();
        }
    }
}
