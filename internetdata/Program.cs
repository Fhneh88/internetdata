using LinqToDB;
using Npgsql;
using System;
using LinqToDB.Data;
using LinqToDB.Mapping;
using System.IO;
using System.Linq;

namespace internetdata
{
    class Program
    {
        public static void InitDB(Database db)
        {

            try
            {
                db.CreateTable<Info>();
            }
            catch (NpgsqlException e)
            {

            }
            
        }
        public static async void Save(string[] x, Database db)
        {
            Info obj = new Info();
            if (x.Length == 0)
                return;
            int i;
            obj.IP = x[1];
            obj.Date = DateTime.Parse(deleteGMT(x[2]));
            obj.request = x[3];
            obj.BasketID = x[4];

            try
            {
                db.Insert((Info)obj);
            }

            catch (Exception e)
            { }

            
        }
        static string deleteGMT(string date)
        {
            string[] tok = date.Split(' ',':');
            tok[0] = String.Join(' ', tok[0], tok[1]);
            tok[0] = String.Join(':', tok[0], tok[2], tok[3]);
            return tok[0];
        }
        static void Queries(Database db)
        {

        }
       
        static void Query1(Database db)
        {
            var q = db.Info.Select(x => x.IP).Distinct().Count();
            StreamWriter sw = new StreamWriter("Queries.txt", true);
            sw.WriteLine("Count of unique customers for month = " + q);
            sw.Close();
        }
        static void Main(string[] args)
        {
            DataConnection.DefaultSettings = new MySettings();
            Database db = new Database();
            InitDB(db);
            //StreamReader streamReader = new StreamReader(@"E:\Users\Arthur\study\8\parsedlog.txt");
            //string s = streamReader.ReadLine();
            //string[] tokens;

            //while (!streamReader.EndOfStream)
            //{
            //    s = streamReader.ReadLine();
            //    tokens = s.Split(';');
            //    tokens[2] = deleteGMT(tokens[2]);
            //    Save(tokens, db);
            //}
            Query1(db);

        }
    }
}
