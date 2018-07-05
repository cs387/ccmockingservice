using ccmockingservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using ccmockingservice.Utils;
namespace ccmockingservice.Validator
{
    public class Amex : AbstractCreditCard
    {
        public override bool IsCorrectFormat(CreditCardDTO creditCardDTO)
        {
            var isValidExpiry = base.IsCorrectFormat(creditCardDTO);

            Regex reg = new Regex(@"^3\d{14}$");
            Match ismatch = reg.Match(creditCardDTO.Number);
           
            return ismatch.Success && isValidExpiry;
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