using System;
using System.Collections.Generic;
using System.Text;

namespace Sinapse.Data
{
    internal sealed class NetworkState
    {
        public int Epoch;
        public double ErrorRate;
        public string StatusText;
        public List<Double> ErrorList;

        public NetworkState()
        {
            this.Epoch = 0;
            this.ErrorRate = 0D;
            this.ErrorList = new List<double>();
            this.StatusText = String.Empty;
        }

        public double[,] GetErrors()
        {
            //Create error's dynamics
            //Array's length cannot exceed 16000!
            double[,] errorMatrix = new double[ErrorList.Count, 2];
            for (int i = 0; i < ErrorList.Count; i++)
            {
                errorMatrix[i, 0] = i;
                errorMatrix[i, 1] = ErrorList[i];
            }
            return errorMatrix;
        }


    }
}
