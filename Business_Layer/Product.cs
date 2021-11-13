using System;

namespace Business_Layer.Objects
{
    public class Product
    {
        BusinessRules rules = new();
        private float protein;
        private float fats;
        private float carbs;
        private float calories;

        public string Name { get; set; }

        public int Gramms { get; set; }

        public float Protein
        {
            get
            {
                return (Gramms * protein) / 100;
            }
            set
            {
                protein = value;
            }
        }

        public float Fats 
        { 
            get
            {
                return (Gramms * fats) / 100;
            }
            set
            {
                fats = value;
            }
        }

        public float Carbs 
        {
            get
            {
                return (Gramms * carbs) / 100;
            }
            set
            {
                carbs = value;
            }
        }

        public float Calories
        {
            get
            {
                return (Gramms * calories) / 100;
            }
            set
            {
                calories = value;
            }
        }

        public Product() 
        {
            rules.rule += (Object obj, ref string message, ref bool isPossible) =>
            {
                if (isPossible)
                {
                    if (obj is Product product && string.IsNullOrEmpty(product.Name))
                    {
                        message = "The Product name can't be empty!";
                        isPossible = false;
                    }
                }
            };

            rules.rule += (Object obj, ref string message, ref bool isPossible) =>
            {
                if (isPossible)
                {
                    if (obj is Product product && product.Gramms <= 0)
                    {
                        message = "The Product gramms can't be zero or negative!";
                        isPossible = false;
                    }
                }
            };

            rules.rule += (Object obj, ref string message, ref bool isPossible) =>
            {
                if (isPossible)
                {
                    if (obj is Product product && product.Protein < 0)
                    {
                        message = "The Product protein can't be zero or negative!";
                        isPossible = false;
                    }
                }
            };

            rules.rule += (Object obj, ref string message, ref bool isPossible) =>
            {
                if (isPossible)
                {
                    if (obj is Product product && product.Fats < 0)
                    {
                        message = "The Product fats can't be zero or negative!";
                        isPossible = false;
                    }
                }
            };

            rules.rule += (Object obj, ref string message, ref bool isPossible) =>
            {
                if (isPossible)
                {
                    if (obj is Product product && product.Carbs < 0)
                    {
                        message = "The Product carbs can't be zero or negative!";
                        isPossible = false;
                    }
                }
            };

            rules.rule += (Object obj, ref string message, ref bool isPossible) =>
            {
                if (isPossible)
                {
                    if (obj is Product product && product.Fats < 0)
                    {
                        message = "The Product fats can't be zero or negative!";
                        isPossible = false;
                    }
                }
            };

            rules.rule += (Object obj, ref string message, ref bool isPossible) =>
            {
                if (isPossible)
                {
                    if (obj is Product product && product.Calories < 0)
                    {
                        message = "The Product calories can't be zero or negative!";
                        isPossible = false;
                    }
                }
            };
        }

        public Product(Product product)
        {
            this.Name = product.Name;
            this.Gramms = product.Gramms;
            this.Protein = product.protein;
            this.Fats = product.fats;
            this.Carbs = product.carbs;
            this.Calories = product.calories;

        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if(!(obj is Product))
            {
                return false;
            }

            Product product = obj as Product;
            if(product.Name == this.Name)
            {
                return true;
            }

            return false;
        }

        public bool Validate (ref string message)
        {
            bool result = true;
            rules.rule(this, ref message, ref result);
            return result;
        }
    }
}
