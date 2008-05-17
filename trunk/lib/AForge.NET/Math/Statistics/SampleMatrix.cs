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
using System.Text;

using AForge.Math;


namespace AForge.Statistics
{

    /// <summary>
    ///     SampleMatrix provides operations of sample statistics
    /// </summary>
    /// <remarks>
    ///     In statistics, a sample is a subset of a population.
    /// </remarks>
    public class SampleMatrix : AForge.Math.Matrix
    {

        public enum DataModel { RowsAsObservations, ColumnsAsObservations };

        private string[] m_colNames;
        private string m_title;


        //---------------------------------------------


        #region Constructors
        /// <summary>
        /// Creates a new SampleMatrix object, where each columns corresponds
        /// to a variable and each row to an observation of those variables.
        /// </summary>
        /// <param name="matrix">The base matrix</param>
        /// <param name="model">The matrix model</param>
        public SampleMatrix(double[][] matrix, DataModel model)
            : base(matrix)
        {
            if (model == DataModel.ColumnsAsObservations)
                this.Array = (double[][])this.Transpose();

            this.generateDefaultNames();
        }

        public SampleMatrix(int rows, int columns)
            : base(rows, columns)
        {
            this.generateDefaultNames();
        }

        public SampleMatrix(System.Data.DataTable dataTable) : base (dataTable.Rows.Count, dataTable.Columns.Count)
        {
            dataTable.AcceptChanges();

            this.m_colNames = new string[dataTable.Columns.Count];
            
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Columns; j++)
                {
                    if (dataTable.Columns[j].DataType == typeof(System.String))
                    {
                        this.Array[i][j] = Double.Parse((string)dataTable.Rows[i][j]);
                    }
                    else
                    {
                        this.Array[i][j] = (Double)dataTable.Rows[i][j];
                    }
                    this.ColumnNames[j] = dataTable.Columns[j].Caption;
                }
            }
        }

        /// <summary>
        /// Creates a new SampleMatrix object, where each columns corresponds
        /// to a variable and each row to an observation of those variables.
        /// </summary>
        /// <param name="matrix">The base matrix</param>
        /// <param name="model">The matrix model</param>
        public SampleMatrix(double[,] matrix, DataModel model)
            : base(matrix)
        {
            if (model == DataModel.ColumnsAsObservations)
                this.Array = (double[][])this.Transpose();

            this.generateDefaultNames();
        }

        /// <summary>
        /// Creates a new SampleMatrix object, where each columns corresponds
        /// to a variable and each row to an observation of those variables.
        /// </summary>
        /// <param name="matrix">The base matrix</param>
        /// <param name="model">The matrix model</param>
        public SampleMatrix(Matrix matrix, DataModel model)
            : base(matrix)
        {
            if (model == DataModel.ColumnsAsObservations)
                this.Array = (double[][])this.Transpose();

            this.generateDefaultNames();
        }

        public SampleMatrix(Matrix matrix)
            : this(matrix, DataModel.RowsAsObservations)
        {
        }

        /// <summary>
        /// Creates a new SampleMatrix object, where each columns corresponds
        /// to a variable and each row to an observation of those variables.
        /// </summary>
        /// <param name="matrix">The matrix to be copied.</param>
        public SampleMatrix(SampleMatrix matrix)
            : base((Matrix)matrix)
        {
            this.m_colNames = matrix.m_colNames;
        }
        #endregion


        //---------------------------------------------


        #region Properties
        /// <summary>The number of observations contained on this sample</summary>
        public int Observations
        {
            get { return base.Rows; }
        }

        /// <summary>The number of variables (data dimension) of this sample</summary>
        public int Variables
        {
            get { return base.Columns; }
        }

        /// <summary>The column (variables) labels of this sample.</summary>
        public string[] ColumnNames
        {
            get { return this.m_colNames; }
        }

        /// <summary>Retrieves a item from the sample</summary>
        /// <param name="variable">The variable index of the requested item</param>
        /// <param name="observation">The observation index of the requested item</param>
        public new double this[int variable, int observation]
        {
            get
            {
                // Always consider columns as variables, rows as observations
                return base[observation, variable];
            }
            set
            {
                base[observation, variable] = value;
            }
        }

        /// <summary>Retrieves a item from the sample</summary>
        /// <param name="variable">The variable label of the requested item</param>
        /// <param name="observation">The observation index of the requested item</param>
        public double this[string variable, int observation]
        {
            get
            {
                int index = System.Array.IndexOf(this.m_colNames, variable);
                return this[index, observation];
            }
            set
            {
                int index = System.Array.IndexOf(this.m_colNames, variable);
                this[index, observation] = value;
            }
        }
        #endregion


        //---------------------------------------------


        #region Public Methods
        /// <summary>Converts this sample matrix to an ordinary matrix</summary>
        public Matrix ToMatrix()
        {
            return this.ToMatrix(DataModel.RowsAsObservations);
        }

        /// <summary>Converts this sample matrix to an ordinary matrix, using the given data organization model</summary>
        /// <param name="model">The data model for the generated matrix</param>
        public Matrix ToMatrix(DataModel model)
        {
            Matrix m = (Matrix)this;

            if (model == DataModel.RowsAsObservations)
                return m;

            else return m.Transpose();
        }

        public override System.Data.DataTable ToDataTable()
        {
            System.Data.DataTable dataTable = base.ToDataTable(this.m_title);
                        
            for (int i = 0; i < dataTable.Columns.Count; i++)
			{
                dataTable.Columns[i].ColumnName = m_colNames[i];
            }

            return dataTable;
        }

        /// <summary>Converts this sample matrix to a string representation</summary>
        public string ToString(bool includeHeaders)
        {
            if (includeHeaders)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < this.Variables; i++)
                {
                    sb.Append(this.m_colNames[i]);

                    if (i < this.Variables - 1)
                        sb.Append("\t");
                }

                sb.AppendLine();
                sb.Append(base.ToString());
                return sb.ToString();
            }
            else
            {
                return base.ToString();
            }
        }

        /// <summary>Creates a shallow copy of this object</summary>
        public new SampleMatrix Clone()
        {
            return new SampleMatrix(this);
        }
        #endregion


        //---------------------------------------------


        #region Private Methods
        private void generateDefaultNames()
        {
            m_colNames = new string[this.Variables];

            for (int i = 0; i < this.Variables; i++)
                m_colNames[i] = "Column " + i;
        }
        #endregion


    }

}
