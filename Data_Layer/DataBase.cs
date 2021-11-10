using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Business_Layer.Objects;

namespace Data_Layer.Objects
{
    public class DataBase
    {
        [XmlArray("ArrayOfCategory")]
        public HashSet<Category> db = new();

        private static DataBase instance;

        private DataBase (string path)
        {
            FillInDB(path);
        }

        public static DataBase GetInstance(string path)
        {
            if (instance == null)
            {
                instance = new(path);
            }

            return instance;
        }

        public void FillInDB(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            XmlSerializer deserializer = new(typeof(HashSet<Category>));
            using (FileStream fs = new(path, FileMode.Open, FileAccess.Read))
            {
                db = (HashSet<Category>)deserializer.Deserialize(fs);
            }
        }
        
        public HashSet<Category> Categories
        {
            get
            {
                return db;
            }
        }
    }
}
