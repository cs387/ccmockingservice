using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ccmockingservice.Models;
namespace ccmockingservice.Validator
{
    public interface ICreditCardValidator
    {
        bool IsCorrectFormat(CreditCardDTO creditCardDTO);
        //bool IsExist(CreditCardDTO creditCardDTO);
        ValidationResult ValidationResult(CreditCardDTO creditCardDTO);
    }
}