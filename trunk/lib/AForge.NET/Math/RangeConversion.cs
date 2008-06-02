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
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Data;



namespace AForge.Mathematics
{
    /// <summary>
    ///   This class provides methods for performing range conversions
    ///   of a Matrix columns, similar to a conversion scale.
    /// </summary>
    public class RangeConversion
    {

        private DoubleRange[] m_originalRanges;
        private DoubleRange[] m_destinationRanges;


        public RangeConversion(DoubleRange[] originalRanges, DoubleRange[] destinationRanges)
        {
            this.m_originalRanges = originalRanges;
            this.m_destinationRanges = destinationRanges;
        }

        public RangeConversion(DoubleRange[] destinationRanges)
        {
            this.m_originalRanges = null;
            this.m_destinationRanges = destinationRanges;
        }

        public Matrix Transform(Matrix matrix)
        {
            if (this.m_originalRanges == null)
            {
                throw new NotImplementedException();
            }

            Matrix result = new Matrix(matrix.Rows, matrix.Columns);

            for (int j = 0; j < matrix.Columns; j++)
            {
                for (int i = 0; i < matrix.Rows; i++)
                {
                    result[i][j] = Convert(result[i][j], m_originalRanges[j], m_destinationRanges[j]);
                }
            }

            return result;
        }

        public Matrix Revert(Matrix matrix)
        {
            if (this.m_originalRanges == null)
            {
                throw new NotImplementedException();
            }

            Matrix result = new Matrix(matrix.Rows, matrix.Columns);

            for (int j = 0; j < matrix.Columns; j++)
            {
                for (int i = 0; i < matrix.Rows; i++)
                {
                    result[i][j] = Convert(result[i][j], m_destinationRanges[j], m_originalRanges[j]);
                }
            }

            return result;
        }

        public static double Convert(double x, DoubleRange original, DoubleRange destination)
        {
            return ((x - original.Min) * destination.Length / original.Length) + destination.Min;
        }


    }
}
