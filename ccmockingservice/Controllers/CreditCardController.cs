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

namespace ccmockingservice.Controllers
{
    public class CreditCardController : ApiController
    {
        AbstractCreditCard _ccobj;
        public CreditCardController() { }

        public CreditCardController(CreditCardDTO creditCardDTO)
        {
            initCreditCardType(creditCardDTO);
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

        //[ResponseType(typeof(ValidationResult))]
        //public IHttpActionResult Get(int id, string dd)
        //{
        //    return Ok(new ValidationResult { CardType = "icenaja"+id, Result = "ofcourseValid"+dd });
        //}

        [ResponseType(typeof(ValidationResult))]
        public IHttpActionResult Get(string CreditCardNumber, string Expiry)
        {

            try
            {
                var cc = new CreditCardDTO { Number= CreditCardNumber, Expiry= Expiry };
                initCreditCardType(cc);
                return Ok(_ccobj.ValidationResult(cc));
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.TraceError($"Error credit card validation : {e.ToString()}");
                throw new HttpResponseException(HttpStatusCode.ExpectationFailed);
            }

        }



    }
}
