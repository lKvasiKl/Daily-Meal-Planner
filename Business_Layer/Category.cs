using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Objects
{
    public class Category
    {
        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(name));
                }

                name = value;
            }
        }

        public HashSet<Product> GetProducts { get; set; }

        public Category() { }
    }
}
