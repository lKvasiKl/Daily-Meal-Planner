using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Layer.Objects;

namespace Data_Layer.Objects
{
    public class CategoryDAO : DataAccessObject
    {
        public CategoryDAO(string path) : base(path) { }

        public HashSet<Category> GetCategories()
        {
            return dataBase.Categories;
        }
    }
}
