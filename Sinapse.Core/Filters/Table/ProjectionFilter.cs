using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace Sinapse.Core.Filters.Table
{
    class ProjectionFilter : IFilter
    {

        DataTable inputTable;
        DataColumn[] dropColumns;
        DataTable outputTable;



        public void Apply()
        {
            outputTable = inputTable.Copy();          
            foreach (DataColumn column in dropColumns)
            {
                outputTable.Columns.Remove(column);
            }
        }

        public string Name
        {
            get { return "Projection"; }
        }

        public string Description
        {
            get { return "Maintains only the selected DataColumns on the given DataTable"; }
        }

        public System.Windows.Forms.Control Control
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        #endregion
    }
}
