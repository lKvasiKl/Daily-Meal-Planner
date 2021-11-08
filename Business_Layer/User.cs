using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    class User
    {
        private double height;
        private double weight;
        private int age;

        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                if(value < 140 || value > 250)
                {
                    throw new ArgumentOutOfRangeException(nameof(height));
                }
            }
        }

        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value < 30 || value > 150)
                {
                    throw new ArgumentOutOfRangeException(nameof(weight));
                }
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value < 6 || value > 100)
                {
                    throw new ArgumentOutOfRangeException(nameof(age));
                }
            }
        }
    }
}
