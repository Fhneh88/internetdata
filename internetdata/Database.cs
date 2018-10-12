using LinqToDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace internetdata
{
    public partial class Database : LinqToDB.Data.DataConnection
    {

        public ITable<Info> Info { get { return this.GetTable<Info>(); } }
        
        public Database()
        { }
        public Database(string configuration) : base(configuration)
        {

        }
    }
}
