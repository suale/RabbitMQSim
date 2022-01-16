using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMQSim
{
    internal class DBWriter
    {
        public void Write()//DataTable dtCpy
        {
            string csDestination = @"Server = localhost\SQLEXPRESS; Database = RabbitMQDB;     
                        Trusted_Connection = True;";
            using (SqlConnection connection2 = new SqlConnection(csDestination))
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection2))
            {
                connection2.Open();
                Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                bulkCopy.DestinationTableName = "dbo.Table1";
                DataTable dtCpy = new DataTable();
                lock (GlobalDT.GlobalDt)
                {
                    if (GlobalDT.GlobalDt != null)
                    {
                        dtCpy = GlobalDT.GlobalDt.Copy();
                    }
                }
                
               
                bulkCopy.WriteToServer(dtCpy);
                GlobalDT.GlobalDtGet.Clear();
                Console.WriteLine("döndü");
                connection2.Close();
            }
        }
    }
}
