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
using System.Collections.Generic;
using System.Text;
using System.Data;

using AForge.Mathematics;

using Sinapse.Core.Filters;
using Sinapse.Core.Systems;


namespace Sinapse.Core.Sources
{

    
    /// <summary>
    ///   This class encompass a Neural Network DataSource, or in other words, a
    ///   source of information that can be used to train and feed Neural Networks.
    ///   A common example of data sources are tables of sample data or a collection
    ///   of images.
    /// </summary>
    [Serializable]
    public abstract class DataSourceBase : WorkplaceContent
    {

        private String m_title;
        private String m_description;
        private String m_remarks;

        public event EventHandler NameChanged;

        //----------------------------------------

        #region Constructor
        protected DataSourceBase(String title)
        {
            this.m_title = title;
            this.m_description = String.Empty;
            this.m_remarks = String.Empty;
        }
        #endregion

        //----------------------------------------

        #region Properties
        public String Name
        {
            get { return this.m_title; }
            set
            {
                this.m_title = value;

                if (this.NameChanged != null)
                    this.NameChanged.Invoke(this, EventArgs.Empty);
            }
        }

        public String Description
        {
            get { return this.m_description; }
            set { this.m_description = value; }
        }

        public String Remarks
        {
            get { return this.m_remarks; }
            set { this.m_remarks = value; }
        }
        #endregion

        //----------------------------------------


    }
}
