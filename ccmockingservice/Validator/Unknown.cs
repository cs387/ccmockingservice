using ccmockingservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using ccmockingservice.Utils;
namespace ccmockingservice.Validator
{
    public class Unknown : AbstractCreditCard
    {
        public override bool IsCorrectFormat(CreditCardDTO creditCardDTO)
        {
            return false;
        }

        public override ValidationResult ValidationResult(CreditCardDTO creditCardDTO)
        {
            var result = "";
            result = GlobalVariables.InvalidResult;
            return new ValidationResult { CardType = this.GetType().Name, Result = result };

        }
    }
}