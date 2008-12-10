using System;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;
using System.Text;

namespace Sinapse.Core.Sources
{
    [Serializable]
    public class TableDataSourceColumn
    {

        public enum ColumnRole { None = 0, Input = 1, Output = 2 };

        private string columnDescription;
        private SystemDataType columnDataType;
        private DataColumn dataColumn;
        private ColumnRole columnRole;
        bool hidden; // Setar quando o usuário esconder na GUI



        public TableDataSourceColumn(DataColumn dataColumn, SystemDataType type, ColumnRole role)
        {
            this.dataColumn = dataColumn;
            this.columnDataType = type;
            this.columnRole = role;
        }

        public TableDataSourceColumn(DataColumn dataColumn)
        {
            this.dataColumn = dataColumn;
        }




        /// <summary>
        ///   Gets or sets the name for this Column
        /// </summary>
        public string Name
        {
            get { return this.dataColumn.ColumnName; }
            set { this.dataColumn.ColumnName = value; }
        }

        /// <summary>
        ///   Gets or sets the display text for this Column
        /// </summary>
        public string Caption
        {
            get { return this.dataColumn.Caption; }
            set { this.dataColumn.Caption = value; }
        }

        /// <summary>
        ///   Gets or sets a text describing which information this Column contains.
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

        public SystemDataType DataType
        {
            get { return this.columnDataType; }
            set { this.columnDataType = value; }
        }

        public ColumnRole Role
        {
            get { return this.columnRole; }
            set { this.columnRole = value; }
        }


        /// <summary>
        ///   Gets the underlying DataColumn associated with this object.
        /// </summary>
        public DataColumn DataColumn
        {
            get { return this.dataColumn; }
        }


    }





    [Serializable]
    public sealed class TableDataSourceColumnCollection :
        System.ComponentModel.BindingList<TableDataSourceColumn>
    {




        #region Constructor
        internal TableDataSourceColumnCollection(TableDataSourceColumn[] columns)
            : base(columns)
        {

        }
        #endregion


        public TableDataSourceColumn[] Select(TableDataSourceColumn.ColumnRole role)
        {
            List<TableDataSourceColumn> cols = new List<TableDataSourceColumn>(this.Count);
            foreach (TableDataSourceColumn col in this)
            {
                if (col.Role == role)
                    cols.Add(col);
            }
            return cols.ToArray();
        }


        public void Add(DataColumn dataColumn, SystemDataType type, TableDataSourceColumn.ColumnRole role)
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
            get
            {
                foreach (TableDataSourceColumn col in this)
                {
                    if (col.DataColumn == dataColumn)
                        return col;
                }
                throw new KeyNotFoundException();
            }
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


        public string[] GetNames(TableDataSourceColumn.ColumnRole role)
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