#nullable enable
using System;
using Business_Layer.Objects;

namespace Data_Layer.Objects
{
    public class ProductDAO : DataAccessObject
    {
        public ProductDAO (string path) : base(path) { }

        public Product? GetProduct(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            foreach (Category category in dataBase.Categories)
            {
                foreach(Product product in category.GetProducts)
                {
                    if (product.Name == name)
                    {
                        return product;
                    }
                }
            }

            return null;
        }
    }
}
