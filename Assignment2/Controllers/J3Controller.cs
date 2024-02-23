using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Http;

namespace Assignment2.Controllers
{
    public class J3Controller : ApiController
    {
        /// <summary>
        /// Calculates the minimal number of seconds needed to type a word on a numberpad. 
        /// Assuming that 1 press takes 1 second, and that a 2 second pause is required to input consecutive numbers on the same key.
        /// </summary>
        /// <param name="input">represents the word being typed</param>
        /// <returns>A message detailing the minimal number of seconds to type the input word</returns>
        /// <example>
        /// GET localhost:xx/api/J3/PhoneMessaging/dada => "This word takes 4 seconds to type"
        /// </example>
        /// <example>
        /// GET localhost:xx/api/J3/PhoneMessaging/abba => "This word takes 12 seconds to type"
        /// </example>
        /// <example>
        /// GET localhost:xx/api/J3/PhoneMessaging/cell => "This word takes 13 seconds to type"
        /// </example>
        [HttpGet]
        [Route("api/J3/PhoneMessaging/{input}")]
        public string PhoneMessaging(string input)
        {
            char previous = input[0];
            int time = ButtonMap(previous);
            foreach (char c in input.Substring(1))
            {
                time += ButtonMap(c);
                if  (c == previous)
                {
                    time += 2;
                }
                else
                {
                    time += CalcPause(c, previous);
                    time += CalcPause(previous, c);
                }
                previous = c;
            }
            return ("This word takes " + time +" seconds to type");
        }

        /// <summary>
        /// Calculates the minimal number of seconds needed to type a single character on a number pad. 
        /// Assuming that 1 press takes 1 second.
        /// </summary>
        /// <param name="character">represents the character being typed</param>
        /// <returns>An integer representing the minimal number of seconds to type the input character</returns>
        /// <example>
        /// ButtonMap(a) => 1
        /// </example>
        /// <example>
        /// ButtonMap(b) => 2
        /// </example>
        /// <example>
        /// ButtonMap(c) => 3
        /// </example>
        private int ButtonMap(char character)
        {
            string adjusted = character.ToString().ToLower();
            string first = "adgjmptw";
            string second = "behknqux";
            string third = "cfilorvy";
            string fourth = "sz";
            if (first.Contains(adjusted))
            {
                return 1;
            }else if (second.Contains(adjusted))
            {
                return 2;
            }else if (third.Contains(adjusted))
            {
                return 3;
            }
            else if (fourth.Contains(adjusted))
            {
                return 4;
            }
            return 0;
        }

        /// <summary>
        /// Calculates the minimal number of seconds needed to pause between the input of 2 characters on a number pad. 
        /// Assuming that a 2 second pause is required to input consecutive numbers on the same key.
        /// </summary>
        /// <param name="current">represents the current character being typed</param>
        /// <param name="previous">represents the last character that was typed</param>
        /// <returns>An integer representing the minimal number of seconds to wait between the inputs character</returns>
        /// <example>
        /// ButtonMap(a,b) => 2
        /// </example>
        /// <example>
        /// ButtonMap(b,a) => 2
        /// </example>
        /// <example>
        /// ButtonMap(a,d) => 0
        /// </example>
        private int CalcPause(char current, char previous) 
        {
            string grouped = "abc,def,ghi,jkl,mno,pqrs,tuv,wxyz";
            string input = (current.ToString() + previous.ToString()).ToLower();
            if (grouped.Contains(input))
            {
                return 2;
            }
            return 0;
        }
    }
}