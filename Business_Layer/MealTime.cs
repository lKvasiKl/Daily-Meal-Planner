﻿using System;
using System.Collections.Generic;

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

        public void DelProduct(Product product)
        {
            GetMealTime.Remove(product);
        }
    
        public float GetCalories()
        {
            float calories = 0f;
            foreach(Product product in GetMealTime)
            {
                calories += product.Calories;
            }

            return calories;
        }

        public float GetProtein()
        {
            float protein = 0f;
            foreach (Product product in GetMealTime)
            {
                protein += product.Protein;
            }

            return protein;
        }

        public float GetCarbs()
        {
            float carbs = 0f;
            foreach (Product product in GetMealTime)
            {
                carbs += product.Carbs;
            }

            return carbs;
        }

        public float GetFats()
        {
            float fats = 0f;
            foreach (Product product in GetMealTime)
            {
                fats += product.Fats;
            }

            return fats;
        }
    }
}
