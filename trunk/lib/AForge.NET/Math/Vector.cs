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

namespace AForge.Math
{

    /// <summary>
    /// A spatial vector, or simply vector, is a geometric
    /// object which has both a magnitude and a direction.
    /// </summary>
    public class Vector : ICloneable
    {

        private double[] vector;
        private int length; // cache vector size for performance


        //---------------------------------------------


        #region Constructor
        public Vector(int size)
        {
            this.vector = new double[size];
            this.length = size;
        }

        public Vector(double[] vector)
        {
            this.vector = (double[])vector.Clone();
            this.length = vector.GetLength(0);
        }

        public Vector(Vector vector)
        {
            this.vector = vector.vector;
            this.length = vector.length;
        }
        #endregion


        //---------------------------------------------


        #region Properties
        public double this[int index]
        {
            get { return this.vector[index]; }
            set { this.vector[index] = value; }
        }

        public double Norm
        {
            get
            {
                double sum = 0.0;
                for (int i = 0; i < length; ++i)
                {
                    sum += System.Math.Pow(this.vector[i], 2);
                }
                return System.Math.Sqrt(sum);
            }
        }

        public int Length
        {
            get { return this.length; }
        }
        #endregion


        //---------------------------------------------


        #region Public Methods
        public Vector Normalize()
        {
            Vector nv = new Vector(this.length);
            double norm = this.Norm;

            for (int i = 0; i < this.length; i++)
            {
                nv[i] = this[i] / norm;
            }

            return nv;
        }

        public void IsOrthogonal(Vector vector)
        {
            throw new NotImplementedException();
        }

        public void SwapRow(int row1, int row2)
        {
            double aux = this[row1];
            this[row1] = this[row2];
            this[row2] = aux;
        }

        public double[] ToDoubleArray()
        {
            return (double[])this.vector.Clone();
        }

        public object Clone()
        {
            return new Vector(this);
        }

        public override string ToString()
        {
            String str = String.Empty;
            for (int i = 0; i < this.length; i++)
            {
                str += this.vector[i];

                if (i < this.length - 1)
                    str += "\t";
            }
            return str;
        }
        #endregion


    }
}
