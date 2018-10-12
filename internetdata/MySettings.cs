using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinqToDB.Configuration;

namespace internetdata
{
    public class ConnectionStringSettings:IConnectionStringSettings
    {
        public string ConnectionString { get; set; }
        public string Name { get; set; }
        public string ProviderName { get; set; }
        public bool IsGlobal => false;
    }
    public class MySettings : ILinqToDBSettings
    {
        public IEnumerable<IDataProviderSettings> DataProviders => Enumerable.Empty<IDataProviderSettings>();

        public string DefaultConfiguration => "PostgreSQL";
        public string DefaultDataProvider => "PostgreSQL";

        public IEnumerable<IConnectionStringSettings> ConnectionStrings
        {
            get
            {
                yield return                   
                    new ConnectionStringSettings
                    {
                        //Server=31.13.134.214,65111;user id=uk;password=2fd03a51-2ad5-4b02-bc0e-27056e489776;MultipleActiveResultSets=True
                        Name = "PostgreSQL",
                        ProviderName = "PostgreSQL",
                        ConnectionString = @"Server=localhost;Port=5432;user id=postgres;Password=Fhneh;Database=Data"
                    };
            }
        }      
    }
}
