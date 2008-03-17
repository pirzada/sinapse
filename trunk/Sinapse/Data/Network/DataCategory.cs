/***************************************************************************
 *   Sinapse Neural Networking Tool         http://sinapse.googlecode.com  *
 *  ---------------------------------------------------------------------- *
 *   Copyright (C) 2006-2008 Cesar Roberto de Souza <cesarsouza@gmail.com> *
 *                                                                         *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 3 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 ***************************************************************************/

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;

namespace Sinapse.Data.Network
{

    internal sealed class DataCategory
    {

        private int id;
        private string columnName;
        private string value;


        //----------------------------------------


        #region Constructor
        public DataCategory(string columnName, int id, string value)
        {
            this.columnName = columnName;
            this.value = value;
            this.id = id;
        }
        #endregion


        //----------------------------------------


        #region Properties
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public String ColumnName
        {
            get { return this.columnName; }
            set { this.columnName = value; }
        }

        public String Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        #endregion


        //----------------------------------------

    }

    internal sealed class DataCategoryCollection : BindingList<DataCategory>
    {

        private string columnName;

        public DataCategoryCollection(string columnName)
        {
            this.columnName = columnName;
        }

        public void Add(int id, string value)
        {
            this.Add(new DataCategory(this.columnName, id, value));
        }
    }
}
