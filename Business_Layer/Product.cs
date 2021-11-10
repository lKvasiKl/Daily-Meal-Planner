using System;

namespace Business_Layer.Objects
{
    public class Product
    {
        private string name;
        private int gramms;
        private float protein;
        private float fats;
        private float carbs;
        private float calories;

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

        public int Gramms
        {
            get
            {
                return gramms;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(gramms));
                }

                gramms = value;
            }
        }

        public float Protein
        {
            get
            {
                return protein;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(protein));
                }

                protein = value;
            }
        }

        public float Fats
        {
            get
            {
                return fats;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(fats));
                }

                fats = value;
            }
        }

        public float Carbs
        {
            get
            {
                return carbs;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(carbs));
                }

                carbs = value;
            }
        }

        public float Calories
        {
            get
            {
                return calories;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(calories));
                }

                calories = value;
            }
        }

        public Product() { }

        public override int GetHashCode()
        {
            return name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if(!(obj is Product))
            {
                return false;
            }

            Product product = obj as Product;
            if(product.name == this.name)
            {
                return true;
            }

            return false;
        }
    }
}
