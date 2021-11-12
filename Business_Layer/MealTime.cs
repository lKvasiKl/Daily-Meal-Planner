using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Objects
{
    public class MealTime
    {
        BusinessRules rules = new();
        public string Name { get; set; }
        public List<Product> GetMealTime { get; set; }
        public MealTime(string name)
        {
            this.Name = name;
            GetMealTime = new();
            rules.rule += (Object obj, ref string massage, ref bool isPossible) =>
            {
                if (isPossible)
                {
                    if (obj is MealTime mealTime && string.IsNullOrEmpty(mealTime.Name))
                    {
                        massage = "The Meal Time name can't be empty!";
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
    }
}
