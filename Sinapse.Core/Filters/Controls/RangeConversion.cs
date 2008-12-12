using System;
using System.Collections.Generic;
using System.Text;

using AForge.Mathematics;
using AForge;

namespace Sinapse.Core.Filters
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    ///   Note: Once the network has been trained using a range conversion, please
    ///   make sure when testing and using the network the maximum and minimum values won't
    ///   ever be extrapolated, otherwise erratic behaviour of the network may occur.
    /// </remarks>
    public class RangeConversion : ICompleteFilter
    {

        private int columnIndex;
        private DoubleRange inputRange;
        private DoubleRange outputRange;

        private int inputCount;


        public RangeConversion()
        {
            
        }

        public int Column
        {
            get { return columnIndex; }
            set { columnIndex = value; }
        }

        public string Name
        {
            get { return "Range Conversion"; }
        }

        public string Description
        {
            get { return "Converts from a scale to another"; }
        }

        public int InputCount
        {
            get { return inputCount; }
        }

        public int OutputCount
        {
            get { return inputCount; }
        }


        public void Apply(object input)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Apply(object[] input)
        {
            input[columnIndex] = DoubleRange.Convert((double)input[columnIndex], inputRange, outputRange);
        }

        public void Apply(object[][] input)
        {
            throw new Exception("The method or operation is not implemented.");
        }



        public void Reverse(object input)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Reverse(object[] input)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Reverse(object[][] input)
        {
            throw new Exception("The method or operation is not implemented.");
        }


    }
}
