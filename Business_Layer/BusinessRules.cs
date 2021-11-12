using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Objects
{
    public class BusinessRules
    {
        public delegate void isPossible(Object obj, ref string message, ref bool isPossible);
        public isPossible rule;    
    }
}
