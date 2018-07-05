using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ccmockingservice.Models;
using ccmockingservice.Utils;
using ccmockingservice.Validator;
using ccmockingservice.DAL;
using System.Data.SqlClient;
using System.Data;

namespace ccmockingservice.Controllers
{
    public class CreditCardController : ApiController
    {
        AbstractCreditCard _ccobj;
        CCServiceDBContext _dbContext;
        public CreditCardController() { }
        
        public CreditCardController(AbstractCreditCard CCObj)
        {
           
            this._ccobj = CCObj;
        }
        public CreditCardController(CreditCardDTO creditCardDTO)
        {
            
            initCreditCardType(creditCardDTO);
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

        private void initCreditCardType(CreditCardDTO creditCardDTO)
        {
            var ccNumber = creditCardDTO.Number;
            if (ccNumber.Length == 16)
            {
                if (ccNumber.StartsWith("4")) _ccobj = new Visa();
                else if (ccNumber.StartsWith("5")) _ccobj = new Mastercard();
                else if (ccNumber.StartsWith("3")) _ccobj = new JCB();
                else _ccobj = new Unknown();
            }
            else if(ccNumber.Length == 15)
            {
                if (ccNumber.StartsWith("3")) _ccobj = new Amex();               
                else _ccobj = new Unknown();
            }
            else _ccobj = new Unknown();
        }

        public ValidationResult FetchValidationResult(CreditCardDTO creditCardDTO)
        {
            return (_ccobj.ValidationResult(creditCardDTO));
        }


        /// <summary>
        /// Checking if credit card number is valid following the pattern of each type of Credit card
        /// if valid then checking for it existence in DB
        /// </summary>
        /// <param name="CreditCardNumber">only number</param>
        /// <param name="Expiry">only number MMYYYY, MM only start with 0,1 otherwise notvalid</param>
        /// <returns></returns>
        [ResponseType(typeof(ValidationResult))]
        public IHttpActionResult Get(string CreditCardNumber, string Expiry)
        {

            try
            {
                var cc = new CreditCardDTO { Number= CreditCardNumber, Expiry= Expiry };
                initCreditCardType(cc);
                var ValResult = FetchValidationResult(cc);
                if (ValResult.Result == GlobalVariables.ValidResult)
                    if (!IsExist(cc))
                        ValResult.Result = GlobalVariables.NotExistResult;
                return Ok(ValResult);
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.TraceError($"Error credit card validation : {e.ToString()}");
                throw new HttpResponseException(HttpStatusCode.ExpectationFailed);
            }

        }



    }
}
