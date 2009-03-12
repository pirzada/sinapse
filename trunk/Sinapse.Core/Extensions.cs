using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace Sinapse.Core
{
    static class Extensions
    {
        public static object[][] ToArray(this DataRow[] rows)
        {
            object[][] data = new object[rows.Length][];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = rows[i].ItemArray;
            }
            return data;
        }

        public static object[][] ToArray(this DataTable table)
        {
            object[][] data = new object[table.Rows.Count][];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = table.Rows[i].ItemArray;
            }
            return data;
        }
    }
}
