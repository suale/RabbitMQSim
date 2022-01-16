using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQSim
{
    public static class GlobalDT
    {
        public static DataTable GlobalDt = new DataTable();
        public static DataTable GlobalDtGet
        {
        get { return GlobalDt; }
        }
        static GlobalDT()
        {
            DataColumn a = new DataColumn("ClientNo");
            GlobalDt.Columns.Add(a);
            DataColumn b = new DataColumn("Data");
            GlobalDt.Columns.Add(b);
            DataColumn c = new DataColumn("DataNumber");
            GlobalDt.Columns.Add(c);

        }
    }
}
