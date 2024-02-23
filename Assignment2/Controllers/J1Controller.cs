using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Assignment2.Controllers
{
    public class J1Controller : ApiController
    {
        /// <summary>
        /// Calculates the total calories from a customers order.
        /// </summary>
        /// <param name="burger">integer representing the burger item the customer ordered</param>
        /// <param name="drink">integer representing the drink item the customer ordered</param>
        /// <param name="side">integer representing the side item the customer ordered</param>
        /// <param name="dessert">integer representing the dessert item the customer ordered</param>
        /// <returns>A message detailing the total calories ordered by a customer</returns>
        /// <example>
        /// GET localhost:xx/api/J1/Menu/4/4/4/4 => “Your total calorie count is 0”
        /// </example>
        /// <example>
        /// GET localhost:xx/api/J1/Menu/1/2/3/4 => “Your total calorie count is 691”
        /// </example>
        [HttpGet]
        [Route("api/J1/Menu/{burger}/{drink}/{side}/{dessert}")]
        public String Menu(int burger, int drink, int side, int dessert)
        {
            int[] burgerCalories = {461, 431, 420};
            int[] drinkCalories = {130, 160, 118};
            int[] sideCalories = {100, 57, 70};
            int[] dessertCalories = {167, 266, 75};
            int total = 0;
            total += GetCalories(burgerCalories,burger);
            total += GetCalories(drinkCalories, drink);
            total += GetCalories(sideCalories, side);
            total += GetCalories(dessertCalories, dessert);
            return ("Your total calorie count is " + total);
        }

        private int GetCalories(int[] calories, int index)
        {
            if(index <4 && index > 0)
            {
                return calories[index-1];
            }
            return 0;
        }
    }
}