using System;
using System.Collections.Generic;
using System.Xml.Serialization;


namespace Business_Layer.Objects
{
    public class Category
    {
        private string name;
        public string description;

        [XmlAttribute("name")]
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

        [XmlArray("Products")]
        public HashSet<Product> GetProducts { get; set; }

        public Category() { }
    }
}
