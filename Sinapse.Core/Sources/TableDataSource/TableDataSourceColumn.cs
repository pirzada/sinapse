using System;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

using Sinapse.Core;
using Sinapse.Core.Systems;

namespace Sinapse.Core.Sources
{
    [Serializable]
    public class TableDataSourceColumn : INotifyPropertyChanged
    {
        private DataTable table;

        private string columnName; // key
        private string columnDescription;
        private SystemDataType columnDataType;
        bool visible; // Setar quando o usuário mostrar/esconder na GUI



        public TableDataSourceColumn(DataColumn dataColumn, SystemDataType type)
        {
            this.table = dataColumn.Table;
            this.columnName = dataColumn.ColumnName;
            this.columnDataType = type;
            this.visible = true;
        }

        public TableDataSourceColumn(DataColumn dataColumn)
            : this(dataColumn, SystemDataType.Nummeric)
        {
        }


        /// <summary>
        ///   Gets or sets the display text for this Column
        /// </summary>
        public string Caption
        {
            get { return this.DataColumn.Caption; }
            set
            {
                if (this.DataColumn.Caption != value)
                {
                    this.DataColumn.Caption = value;
                    OnPropertyChanged("Caption");
                }
            }
        }

        /// <summary>
        ///   Gets or sets a text describing which information this column contains.
        /// </summary>
        public string Description
        {
            get { return this.columnDescription; }
            set
            {
                if (this.columnDescription != value)
                {
                    this.columnDescription = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        /// <summary>
        ///   Gets or sets whether this column should by visible by the user.
        /// </summary>
        public bool Visible
        {
            get { return visible; }
            set
            {
                if (this.visible != value)
                {
                    this.visible = value;
                    OnPropertyChanged("Visible");
                }
            }
        }

        /// <summary>
        ///   Gets or sets the type of data stored by this column.
        /// </summary>
        public SystemDataType DataType
        {
            get { return this.columnDataType; }
            set
            {
                if (this.columnDataType != value)
                {
                    this.columnDataType = value;
                    OnPropertyChanged("DataType");
                }
            }
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




        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(property));
        }
        #endregion

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

/*

        public TableDataSourceColumn[] Select(InputOutput role)
        {
            List<TableDataSourceColumn> cols = new List<TableDataSourceColumn>(this.Count);
            foreach (TableDataSourceColumn col in this)
            {
                if (col.Role == role)
                    cols.Add(col);
            }
            return cols.ToArray();
        }

        */
        public void Add(DataColumn dataColumn, SystemDataType type, InputOutput role)
        {
            Add(new TableDataSourceColumn(dataColumn, type));
        }



        /// <summary>
        ///   Gets the associated column info for the given DataColumn.
        /// </summary>
        /// <param name="dataColumn"></param>
        /// <returns></returns>
        public TableDataSourceColumn this[DataColumn dataColumn]
        {
            get { return this[dataColumn.ColumnName]; }
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

        public bool Contains(string columnName)
        {
            foreach (TableDataSourceColumn col in this)
            {
                if (col.Name == columnName)
                    return true;
            }
            return false;
        }
        /*
        public int GetCount(InputOutput role)
        {
            int count = 0;
            foreach (TableDataSourceColumn col in this)
            {
                if (col.Role == role)
                    count++;
            }
            return count;
        }
        */
        /*
        public string[] GetNames(InputOutput role)
        {
            List<string> names = new List<string>(this.Count);
            foreach (TableDataSourceColumn col in this)
            {
                if (col.Role == role)
                    names.Add(col.Name);
            }
            return names.ToArray();
        }
        */

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            // Fix for deserialization of items which implement INotifyPropertyChanged

            List<TableDataSourceColumn> items = new List<TableDataSourceColumn>(Items);
            int index = 0;

            // call SetItem again on each item to re-establish event hookups
            foreach (TableDataSourceColumn item in items)
            {
                // explicitly call the base version in case SetItem is overridden
                base.SetItem(index++, item);
            }
        }

    }
}