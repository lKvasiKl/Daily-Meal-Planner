using System;

namespace Business_Layer.Objects
{
    public class Product
    {
        BusinessRules rules = new();

        public string Name { get; set; }

        public int Gramms { get; set; }

        public float Protein { get; set; }

        public float Fats { get; set; }

        public float Carbs { get; set; }

        public float Calories { get; set; }

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
