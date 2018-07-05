using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ccmockingservice.Models;
using ccmockingservice.Controllers;
namespace ccmockingservice.Tests
{
    [TestClass]
    public class TestService
    {
        [TestMethod]
        public void TestValid_Visa()
        {
            var ccDTO = new CreditCardDTO { Number = "4348601342777256", Expiry = "052020" };
            var controller = new CreditCardController(ccDTO);

            var result = controller.FetchValidationResult(ccDTO);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.CardType.ToLower(), "visa");
            Assert.AreEqual(result.Result.ToLower(), "valid");
        }

        [TestMethod]
        public void TestInValid_Visa()
        {
            var ccDTO = new CreditCardDTO { Number = "4348601342777256", Expiry = "052021" };
            var controller = new CreditCardController(ccDTO);

            var result = controller.FetchValidationResult(ccDTO);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.CardType.ToLower(), "visa");
            Assert.AreEqual(result.Result.ToLower(), "invalid");
        }

        [TestMethod]
        public void TestValid_Mastercard()
        {
            var ccDTO = new CreditCardDTO { Number = "5554705785720271", Expiry = "022281" };
            var controller = new CreditCardController(ccDTO);

            var result = controller.FetchValidationResult(ccDTO);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.CardType.ToLower(), "mastercard");
            Assert.AreEqual(result.Result.ToLower(), "valid");
        }

        [TestMethod]
        public void TestInValid_Mastercard()
        {
            var ccDTO = new CreditCardDTO { Number = "5554705785720271", Expiry = "022280" };
            var controller = new CreditCardController(ccDTO);

            var result = controller.FetchValidationResult(ccDTO);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.CardType.ToLower(), "mastercard");
            Assert.AreEqual(result.Result.ToLower(), "invalid");
        }

        [TestMethod]
        public void TestValid_Amex()
        {
            var ccDTO = new CreditCardDTO { Number = "316433111615513", Expiry = "022281" };
            var controller = new CreditCardController(ccDTO);

            var result = controller.FetchValidationResult(ccDTO);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.CardType.ToLower(), "amex");
            Assert.AreEqual(result.Result.ToLower(), "valid");
        }
        [TestMethod]
        public void TestInValid_Amex()
        {
            var ccDTO = new CreditCardDTO { Number = "31643311XX15513", Expiry = "022281" };
            var controller = new CreditCardController(ccDTO);

            var result = controller.FetchValidationResult(ccDTO);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.CardType.ToLower(), "amex");
            Assert.AreEqual(result.Result.ToLower(), "invalid");
        }
        [TestMethod]
        public void TestValid_JCB()
        {
            var ccDTO = new CreditCardDTO { Number = "3260262426585401", Expiry = "022281" };
            var controller = new CreditCardController(ccDTO);

            var result = controller.FetchValidationResult(ccDTO);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.CardType.ToLower(), "jcb");
            Assert.AreEqual(result.Result.ToLower(), "valid");
        }

        [TestMethod]
        public void TestInValid_JCB()
        {
            var ccDTO = new CreditCardDTO { Number = "326026WWW6585401", Expiry = "022281" };
            var controller = new CreditCardController(ccDTO);

            var result = controller.FetchValidationResult(ccDTO);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.CardType.ToLower(), "jcb");
            Assert.AreEqual(result.Result.ToLower(), "invalid");
        }
    }
}
