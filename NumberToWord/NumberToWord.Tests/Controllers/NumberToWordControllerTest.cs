using System.Net.Http;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace NumberToWord.Tests.Controllers
{
    [TestClass]
    public class NumberToWordControllerTest
    {
        [TestMethod]
        public void NumberToWords_Number_0()
        {
            // Arrange
            var controller = new NumberToWord.Controllers.NumberToWordController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            string response = controller.ConvertNumberToWord("10");

            // Assert
            Assert.AreEqual("TEN", response);
        }

        [TestMethod]
        public void NumberToWords_Number_11()
        {
            // Arrange
            var controller = new NumberToWord.Controllers.NumberToWordController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            string response = controller.ConvertNumberToWord("11");

            // Assert
            Assert.AreEqual("ELEVEN", response);
        }

        [TestMethod]
        public void NumberToWords_Number_decimal_25()
        {
            // Arrange
            var controller = new NumberToWord.Controllers.NumberToWordController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            string response = controller.ConvertNumberToWord("0.25");

            // Assert
            Assert.AreEqual("ZERO DOLLARS AND TWENTY-FIVE CENTS", response);
        }

        [TestMethod]
        public void NumberToWords_Number_decimal_25_WithStartDecimalChar()
        {
            // Arrange
            var controller = new NumberToWord.Controllers.NumberToWordController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            string response = controller.ConvertNumberToWord(".25");

            // Assert
            Assert.AreEqual("ZERO DOLLARS AND TWENTY-FIVE CENTS", response);
        }

        [TestMethod]
        public void NumberToWords_Number_NegativeNumber()
        {
            // Arrange
            var controller = new NumberToWord.Controllers.NumberToWordController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            string response = controller.ConvertNumberToWord("-10");

            // Assert
            Assert.AreEqual("MINUS TEN", response);
        }

        [TestMethod]
        public void NumberToWords_Number_Hundreds()
        {
            // Arrange
            var controller = new NumberToWord.Controllers.NumberToWordController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            string response = controller.ConvertNumberToWord("878");

            // Assert
            Assert.AreEqual("EIGHT HUNDRED AND SEVENTY-EIGHT", response);
        }


        [TestMethod]
        public void NumberToWords_Number_Thousand()
        {
            // Arrange
            var controller = new NumberToWord.Controllers.NumberToWordController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            string response = controller.ConvertNumberToWord("1323");

            // Assert
            Assert.AreEqual("ONE THOUSAND THREE HUNDRED AND TWENTY-THREE", response);
        }

        [TestMethod]
        public void NumberToWords_Number_Millions()
        {
            // Arrange
            var controller = new NumberToWord.Controllers.NumberToWordController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            string response = controller.ConvertNumberToWord("123456");

            // Assert
            Assert.AreEqual("ONE HUNDRED AND TWENTY-THREE THOUSAND FOUR HUNDRED AND FIFTY-SIX", response);
        }

        [TestMethod]
        public void NumberToWords_Number_WithDecimal()
        {
            // Arrange
            var controller = new NumberToWord.Controllers.NumberToWordController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            string response = controller.ConvertNumberToWord("676767.67");

            // Assert
            Assert.AreEqual("SIX HUNDRED AND SEVENTY-SIX THOUSAND SEVEN HUNDRED AND SIXTY-SEVEN DOLLARS AND SIXTY-SEVEN CENTS", response);
        }


        [TestMethod]
        public void NumberToWords_Number_WithDecimal_1()
        {
            // Arrange
            var controller = new NumberToWord.Controllers.NumberToWordController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            string response = controller.ConvertNumberToWord("10000.01");

            // Assert
            Assert.AreEqual("TEN THOUSAND  DOLLARS AND ONE CENTS", response);
        }

        [TestMethod]
        public void NumberToWords_Number_ManyNumberAfterDecimal()
        {
            // Arrange
            var controller = new NumberToWord.Controllers.NumberToWordController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            string response = controller.ConvertNumberToWord("1000.100001");

            // Assert
            Assert.AreEqual("ONE THOUSAND  DOLLARS AND ONE HUNDRED  THOUSAND AND ONE CENTS", response);
        }

        [TestMethod]
        public void NumberToWords_Number_Long()
        {
            // Arrange
            var controller = new NumberToWord.Controllers.NumberToWordController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            string response = controller.ConvertNumberToWord("123456789.123456789");

            // Assert
            Assert.AreEqual("ONE HUNDRED AND TWENTY-THREE MILLION FOUR HUNDRED AND FIFTY-SIX THOUSAND SEVEN HUNDRED AND EIGHTY-NINE DOLLARS AND ONE HUNDRED AND TWENTY-THREE MILLION FOUR HUNDRED AND FIFTY-SIX THOUSAND SEVEN HUNDRED AND EIGHTY-NINE CENTS", response);
        }
    }
}
