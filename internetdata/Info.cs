using System;
using System.Collections.Generic;
using System.Text;
using LinqToDB.Mapping;

namespace internetdata
{
    [Table(Schema = "InternetData", Name = "Info")]
    public partial class Info
    {
        [Column, Nullable] public string IP { get; set; }
        [Column, Nullable] public DateTime Date { get; set; }
        [Column, Nullable] public string request { get; set; }
        [Column, Nullable] public string BasketID { get; set; }
    }
}
