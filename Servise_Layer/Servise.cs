#nullable enable
using System;
using System.Collections.Generic;
using Business_Layer.Objects;
using Data_Layer.Objects;

namespace Servise_Layer.Object
{
    public static class Servise
    {
        private static CategoryDAO? categoryDAO;
        private static ProductDAO? productDAO;
        private static DailyRation ration;

        public static void SetPath(string path)
        {
            categoryDAO = new(path);
            productDAO = new(path);
            ration = new();
        }

        public static HashSet<Category> GetCategories()
        {
            if(categoryDAO == null)
            {
                throw new ArgumentNullException(nameof(categoryDAO));
            }

            return categoryDAO.GetCategories();
        }

        public static Category? GetCategory(string name)
        {
            foreach (Category category in GetCategories())
            {
                if (category.Name == name)
                {
                    return category;
                }
            }

            return null;
        }

        public static HashSet<Product> GetProductsOf(string name)
        {
            if (categoryDAO == null)
            {
                throw new ArgumentNullException(nameof(categoryDAO));
            }

            Category? products = GetCategory(name);
            if (products == null)
            {
                throw new ArgumentNullException(nameof(products));
            }

            return products.GetProducts;
        }

        public static List<MealTime> GetRation ()
        {
            return ration.GetRation;
        }

        public static void AddMeal(MealTime meal)
        {
            ration.Add(meal);
        }

        public static void DelMeal(MealTime meal)
        {
            ration.Remove(meal);
        }

    }
}
