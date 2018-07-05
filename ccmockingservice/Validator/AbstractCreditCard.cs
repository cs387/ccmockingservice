using ccmockingservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using ccmockingservice.DAL;
using System.Data.SqlClient;
using System.Data;

namespace ccmockingservice.Validator
{
    public abstract class AbstractCreditCard : ICreditCardValidator
    {
        private bool IsValidExpiry(CreditCardDTO creditCardDTO)
        {
            Regex reg = new Regex(@"^[0-1]\d{5}$");
            Match ismatch = reg.Match(creditCardDTO.Expiry);
            return ismatch.Success;
        }

        public virtual bool IsCorrectFormat(CreditCardDTO creditCardDTO)
        {
            return IsValidExpiry(creditCardDTO);
        }
               

        public abstract ValidationResult ValidationResult(CreditCardDTO creditCardDTO);
        
        

       
    }
}