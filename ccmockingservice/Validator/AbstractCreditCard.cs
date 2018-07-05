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

        public bool IsExist(CreditCardDTO creditCardDTO)
        {
            using (var context = new CCServiceDBContext())
            {
                var returnCodeValue = 0;
                var clientIdParameter = new SqlParameter("@Number", creditCardDTO.Number);
                var returnCode = new SqlParameter("@ReturnCode", SqlDbType.Int);
                returnCode.Direction = ParameterDirection.Output;


                var sql = "exec @ReturnCode = CheckCardExist @Number";
                var data = context.Database.SqlQuery<object>(sql, returnCode, clientIdParameter);

                var item = data.FirstOrDefault();

                returnCodeValue = (int)returnCode.Value;

                return returnCodeValue == 1;

            }
        }

        public abstract ValidationResult ValidationResult(CreditCardDTO creditCardDTO);
        
        

       
    }
}