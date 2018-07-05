using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using ccmockingservice.Models;


namespace ccmockingservice.Validator
{
    public class Visa : AbstractCreditCard
    {
        public override bool IsCorrectFormat(CreditCardDTO creditCardDTO)
        {
           var isValidExpiry= base.IsCorrectFormat(creditCardDTO);

           Regex reg= new Regex(@"^4\d{15}$");
           Match ismatch =  reg.Match(creditCardDTO.Number);
           if(ismatch.Success && isValidExpiry)
            {
               var year= creditCardDTO.Expiry.Substring(creditCardDTO.Expiry.Length - 4);

                return DateTime.IsLeapYear(int.Parse(year));
            }
            return false;
        }

        public override ValidationResult ValidationResult(CreditCardDTO creditCardDTO)
        {
            var result = "";
            if (this.IsCorrectFormat(creditCardDTO))
                result = GlobalVariables.ValidResult;
            else result = GlobalVariables.InvalidResult;
            return new ValidationResult { CardType = this.GetType().Name, Result = result };

        }
    }
}