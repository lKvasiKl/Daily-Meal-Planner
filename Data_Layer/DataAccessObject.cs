using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Objects
{
    public abstract class DataAccessObject
    {
        protected DataBase dataBase;

        public DataAccessObject(string path)
        {
            dataBase = DataBase.GetInstance(path);
        }
    }
}
