namespace ccmockingservice.Migrations
{
    using ccmockingservice.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<ccmockingservice.DAL.CCServiceDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ccmockingservice.DAL.CCServiceDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.CreditCards.AddOrUpdate(p => p.Number, generateCreditCards(4, 16)); //visa
            context.CreditCards.AddOrUpdate(p => p.Number, generateCreditCards(5, 16)); //mastercard
            context.CreditCards.AddOrUpdate(p => p.Number, generateCreditCards(3, 15)); //amex
            context.CreditCards.AddOrUpdate(p => p.Number, generateCreditCards(3, 16)); //JCB
            context.SaveChanges();

        }

        private CreditCardEntity[] generateCreditCards(int startWith, int length)
        {

            int count = 4;

            CreditCardEntity[] arrCreditCards = new CreditCardEntity[count];
            for (int i = 0; i < count; i++)
            {
                var genToken = generateCreditCardNumber(startWith, length);
                arrCreditCards[i] = new CreditCardEntity { Number = genToken };

            }
            return arrCreditCards;

        }
        private string generateCreditCardNumber(int startWith, int length)
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
            return sb.ToString();
        }
    }
}
