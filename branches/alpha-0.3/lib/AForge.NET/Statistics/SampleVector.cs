/***************************************************************************
 *                                                                         *
 *  Copyright (C) 2006-2008 Cesar Roberto de Souza <cesarsouza@gmail.com>  *
 *                                                                         *
 *  Please note that this code is not part of the original AForge.NET      *
 *  library. This extension was created to support new features needed by  *
 *  Sinapse, a neural networking tool software. Unless otherwise advised,  *
 *  this code relies under protection of the GNU General Public License v3 *
 *                                                                         *
 ***************************************************************************/

using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Text;
using System.Data;

namespace AForge.Statistics
{

    /// <summary>
    ///   Sample Variable
    /// </summary>
    public class SampleVector : AForge.Mathematics.Vector 
    {

        string m_colName;

        public SampleVector(string name, params double[] values)
            : base(values)
        {
            this.m_colName = name;
        }

        public SampleVector(params double[] values)
            : this(String.Empty, values)
        {
        }

        public SampleVector(int size, string name) : base(size)
        {
            this.m_colName = name;
        }

        public SampleVector(int size)
            : this(size, String.Empty)
        {
        }

        public SampleVector(DataColumn dataColumn)
            : base(dataColumn)
        {
            this.m_colName = dataColumn.ColumnName;
        }

        public SampleVector(IListSource values)
            : base(values)
        {
        }


        public String Name
        {
            get { return m_colName; }
            set { this.m_colName = value; }
        }

    }
}
