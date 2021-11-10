using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Objects
{
    public class MealTime
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
                    throw new ArgumentException(nameof(name));
                }

                name = value;
            }
        }

        public List<Product> GetMealTime { get; set; }

        public MealTime(string name)
        {
            this.Name = name;
            GetMealTime = new();
        }

        public override bool Equals(object obj)
        {
            if (obj is MealTime mealTime)
            {
                if (this.Name == mealTime.Name && this.GetMealTime == mealTime.GetMealTime)
                {
                    return true;
                }
            }


            return false;
        }

    }
}
