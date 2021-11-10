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

        public static void SetPath(string path)
        {
            categoryDAO = new(path);
            productDAO = new(path);
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

    }
}
