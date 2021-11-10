using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Objects
{
    public class DailyRation
    {
        public List<MealTime> GetRation { get; set; }

        public DailyRation() 
        {
            GetRation = new();
            GetRation.Add(new MealTime("Breakfast"));
            GetRation.Add(new MealTime("Lunch"));
            GetRation.Add(new MealTime("Dinner"));
        }

        public void Add(MealTime meal)
        {
            GetRation.Add(meal);
        }

        public void Remove(MealTime meal)
        {
            GetRation.Remove(meal);
        }

        public void Remove(MealTime meal, Product product)
        {
            meal.GetMealTime.Remove(product);
        }
    }
}
