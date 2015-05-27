using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Data
{
    public class DataProvider
    {
    // ReSharper disable once InconsistentNaming
        private static readonly Database database;

        static DataProvider()
        {
            database = new Database("DBConnStr");
        }

        public Database Database {
            get { return database; }
        }
    }
}
