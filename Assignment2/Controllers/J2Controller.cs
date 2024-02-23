using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Assignment2.Controllers
{
    public class J2Controller : ApiController
    {
        /// <summary>
        /// Calculates total different ways two dice with variable sides can roll the value of 10.
        /// </summary>
        /// <param name="diceOne">represents the number of sides of the first die</param>
        /// <param name="diceTwo">represents the number of sides of the second die</param>
        /// <returns>A string detailing the amount of different ways to you can roll 10</returns>
        /// <example>
        /// localhost:xx/api/J2/DiceGame/6/8 => "There are 5 ways to get the sum 10"
        /// </example>
        /// <example>
        /// localhost:xx/api/J2/DiceGame/12/4 => "There are 4 ways to get the sum 10"
        /// </example>
        /// <example>
        /// localhost:xx/api/J2/DiceGame/3/3 => "There are 0 ways to get the sum 10"
        /// </example>
        /// <example>
        /// localhost:xx/api/J2/DiceGame/5/5 => "There is 1 ways to get the sum 10"
        /// </example>
        [HttpGet]
        [Route("api/J2/DiceGame/{diceOne}/{diceTwo}")]
        public String Menu(int diceOne, int diceTwo)
        {
            if(diceOne > 9)
            {
                diceOne = 9;
            }
            if(diceTwo > 9)
            {
                diceTwo = 9;
            }
            int sum = diceOne - (9 - diceTwo);
            if (sum < 0)
            {
                return ("There are 0 ways to get the sum 10");
            }
            else if (sum == 1)
            {
                return ("There is 1 way to get the sum 10");
            }
            return ("There are " + sum + " ways to get the sum 10");
        }
    }
}