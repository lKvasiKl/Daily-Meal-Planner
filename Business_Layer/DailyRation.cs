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

        public float GetCalories()
        {
            float calories = 0f;
            foreach (MealTime meal in GetRation)
            {
                {
                    calories += meal.GetCalories();
                }
            }

            return calories;
        }

        public float GetProtein()
        {
            float protein = 0f;
            foreach (MealTime meal in GetRation)
            {
                {
                    protein += meal.GetProtein();
                }
            }

            return protein;
        }

        public float GetCarbs()
        {
            float carbs = 0f;
            foreach (MealTime meal in GetRation)
            {
                {
                    carbs += meal.GetCarbs();
                }
            }

            return carbs;
        }

        public float GetFats()
        {
            float fats = 0f;
            foreach (MealTime meal in GetRation)
            {
                {
                    fats += meal.GetFats();
                }
            }

            return fats;
        }
    }
}
