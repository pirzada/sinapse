using System;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;
using System.Text;

using Sinapse.Core;
using Sinapse.Core.Systems;

namespace Sinapse.Core.Sources
{
    [Serializable]
    public class TableDataSourceColumn
    {
        private DataTable table;

        private string columnName; // key
        private string columnDescription;
        private SystemDataType columnDataType;
        private DataSourceRole columnRole;
        bool hidden; // Setar quando o usuário esconder na GUI



        public TableDataSourceColumn(DataColumn dataColumn, SystemDataType type, DataSourceRole role)
        {
            this.table = dataColumn.Table;
            this.columnName = dataColumn.ColumnName;
            this.columnDataType = type;
            this.columnRole = role;
        }

        public TableDataSourceColumn(DataColumn dataColumn)
        {
            this.table = dataColumn.Table;
            this.columnName = dataColumn.ColumnName;
        }


        /// <summary>
        ///   Gets or sets the display text for this Column
        /// </summary>
        public string Caption
        {
            get { return this.DataColumn.Caption; }
            set { this.DataColumn.Caption = value; }
        }

        /// <summary>
        ///   Gets or sets a text describing which information this column contains.
        /// </summary>
        public string Description
        {
            get { return this.columnDescription; }
            set { this.columnDescription = value; }
        }

        /// <summary>
        ///   Gets or sets whether this column should remain hidden from the user.
        /// </summary>
        public bool Hidden
        {
            get { return hidden; }
            set { hidden = value; }
        }

        /// <summary>
        ///   Gets or sets the type of data stored by this column.
        /// </summary>
        public SystemDataType DataType
        {
            get { return this.columnDataType; }
            set { this.columnDataType = value; }
        }

        /// <summary>
        ///   Gets or sets the role for this column, if Input or Output.
        /// </summary>
        public DataSourceRole Role
        {
            get { return this.columnRole; }
            set { this.columnRole = value; }
        }

        /// <summary>
        ///   Gets the DataColumn associated with this object.
        /// </summary>
        public DataColumn DataColumn
        {
            get { return table.Columns[this.columnName]; }
        }

        /// <summary>
        ///   Gets the name of the DataColumn associated with this object.
        /// </summary>
        public string Name
        {
            get { return this.columnName; }
        }

    }





    [Serializable]
    public sealed class TableDataSourceColumnCollection : BindingList<TableDataSourceColumn>
    {


        public TableDataSourceColumnCollection(IList<TableDataSourceColumn> columns)
            : base(columns)
        {
        }

        public TableDataSourceColumnCollection()
            : base()
        {
        }



        public TableDataSourceColumn[] Select(DataSourceRole role)
        {
            List<TableDataSourceColumn> cols = new List<TableDataSourceColumn>(this.Count);
            foreach (TableDataSourceColumn col in this)
            {
                if (col.Role == role)
                    cols.Add(col);
            }
            return cols.ToArray();
        }


        public void Add(DataColumn dataColumn, SystemDataType type, DataSourceRole role)
        {
            Add(new TableDataSourceColumn(dataColumn, type, role));
        }



        /// <summary>
        ///   Gets the associated column info for the given DataColumn.
        /// </summary>
        /// <param name="dataColumn"></param>
        /// <returns></returns>
        public TableDataSourceColumn this[DataColumn dataColumn]
        {
            get            {                return this[dataColumn.ColumnName];}
        }

        /// <summary>
        ///   Gets the associated column info for the given column name.
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public TableDataSourceColumn this[string columnName]
        {
            get
            {
                foreach (TableDataSourceColumn col in this)
                {
                    if (col.Name == columnName)
                        return col;
                }
                throw new KeyNotFoundException();
            }
        }

        public int GetCount(DataSourceRole role)
        {
            int count = 0;
            foreach (TableDataSourceColumn col in this)
            {
                if (col.Role == role)
                    count++;
            }
            return count;
        }

        public string[] GetNames(DataSourceRole role)
        {
            List<string> names = new List<string>(this.Count);
            foreach (TableDataSourceColumn col in this)
            {
                if (col.Role == role)
                    names.Add(col.Name);
            }
            return names.ToArray();
        }


    }
}