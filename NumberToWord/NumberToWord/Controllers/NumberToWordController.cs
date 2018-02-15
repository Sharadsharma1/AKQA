using System;
using System.Web.Http;

namespace NumberToWord.Controllers
{
    /// <summary>
    /// Number to Word Api Controller
    /// This is api controller to convert input number string to words
    /// </summary>
    public class NumberToWordController : ApiController
    {
        //Define Variables
        private string _wholeNo = string.Empty;
        private string _points = string.Empty;
        private string _wholeNumber = string.Empty;
        private string _cents = string.Empty;
        public string FullNumberInWords { get; private set; }

        /// <summary>
        /// Web Api Get Method
        /// </summary>
        /// <param name="input">Number as string</param>
        /// <returns>Number in Words</returns>
        [HttpGet]
        [Route("Api/NumberToWord/ConvertNumberToWord/{input}/")]
        public string ConvertNumberToWord(string input)
        {
            // Check if input number starts with decimal (.)
            // If yes, append it with 0 at the begining
            if (input[0].Equals('.'))
                input = input.PadLeft(input.Length + 1, '0');

            //decimal location in input number 
            var decimalPlace = input.IndexOf(".", StringComparison.Ordinal);

            // Check if the number 
            if (decimalPlace > 0)
            {
                _wholeNo = input.Substring(0, decimalPlace);
                _points = input.Substring(decimalPlace + 1);

                //Get the whole number in words
                _wholeNumber = NumberToWords(Convert.ToInt64(_wholeNo));

                //Get the points number in words
                _cents = NumberToWords(Convert.ToInt64(_points));

                //Appends whole number and points number
                FullNumberInWords = _wholeNumber + " Dollars And " + _cents + " Cents";
            }
            else //if number is whole number
            {
                // if No decimal, then it is whole number
                FullNumberInWords = NumberToWords(Convert.ToInt32(input));
            }

            return FullNumberInWords.ToUpper();
        }


        /// <summary>
        /// Function to convert number to words
        /// </summary>
        /// <param name="number">input number</param>
        /// <returns>Number in Words</returns>
        public static string NumberToWords(Int64 number)
        {
            
            if (number == 0) return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            // if number in millions
            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            // if number in thousand
            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            // if number in hundred
            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                //Unit and Tens Mapping Array
                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                //Select Unit or Tens map according to Number
                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }
            return words;
        }
    }
}
