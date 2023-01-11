using System;
using System.Data.CData.Snowflake;

namespace Snowflake
{
    class Program
    {
        static void Main(string[] args)
        {
            const string ConnectionString = "url=https://ql32684.us-east4.gcp.snowflakecomputing.com;user=Mani47;password=Kapmkd@47;PrivateKey=\"C:\\Users\\ManikandanPalanisamy\\Desktop\\SupportDrill\\private-key.pem\";PrivateKeyType=PEMKEY_FILE,Database=LAB_DB;Warehouse=MANI";
            using (SnowflakeConnection connection = new SnowflakeConnection(ConnectionString))
            {
                connection.Open();
                SnowflakeCommand snowflakeCommand = new SnowflakeCommand("SELECT * FROM sys_tables", connection);
                SnowflakeCommand cmd = snowflakeCommand;
                SnowflakeDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    for (int i = rdr.FieldCount - 1; i >= 0; i--)
                    {
                        Console.WriteLine(rdr.GetName(i) + ":" + rdr[i].ToString());
                    }
                    Console.ReadLine();
                }
            }
        }
    }
}