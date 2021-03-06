﻿using ccmockingservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using ccmockingservice.Utils;
namespace ccmockingservice.Validator
{
    public class Mastercard : AbstractCreditCard
    {
        public override bool IsCorrectFormat(CreditCardDTO creditCardDTO)
        {
            var isValidExpiry = base.IsCorrectFormat(creditCardDTO);

            Regex reg = new Regex(@"^5\d{15}$");
            Match ismatch = reg.Match(creditCardDTO.Number);
            if (ismatch.Success && isValidExpiry)
            {
                var year = creditCardDTO.Expiry.Substring(creditCardDTO.Expiry.Length - 4);

                return int.Parse(year).IsPrime();
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