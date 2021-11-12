using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Objects
{
    public class User
    {
        BusinessRules rules = new();
        public double Height { get; set; }
        public double Weight { get; set; }
        public int Age { get; set; }
        public double ActivityCoef { get; set; } = 0.0d;
        public User ()
        {
            rules.rule += (Object obj, ref string message, ref bool isPossible) =>
            {
                if (isPossible)
                {
                    if (obj is User user && (user.Height < 140 || user.Height > 250))
                    {
                        message = "The Users Height can't be less then 140 and more than 250!";
                        isPossible = false;
                    }
                }
            };

            rules.rule += (Object obj, ref string message, ref bool isPossible) =>
            {
                if (isPossible)
                {
                    if (obj is User user && (user.Weight < 30 || user.Weight > 150))
                    {
                        message = "The Users Weight can't be less then 30 and more than 150!";
                        isPossible = false;
                    }
                }
            };

            rules.rule += (Object obj, ref string message, ref bool isPossible) =>
            {
                if (isPossible)
                {
                    if (obj is User user && (user.Age < 6 || user.Age > 100))
                    {
                        message = "The Users Age can't be less then 6 and more than 100!";
                        isPossible = false;
                    }
                }
            };
        }

        public bool Validate(ref string message)
        {
            bool result = true;
            rules.rule(this, ref message, ref result);
            return result;
        }

        public double GetDailyRate()
        {
            return (447.593 + 9.247 * Weight + 3.098 * Height - 4.330 * Age) * ActivityCoef;
        }
    }
}
