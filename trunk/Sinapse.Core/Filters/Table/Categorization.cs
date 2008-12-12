using System;
using System.Collections.Generic;
using System.Text;

namespace Sinapse.Core.Filters.Table
{
    /// <summary>
    ///   This filter can replace strings into numbers, indexing every different
    ///  word in a Dictionary, deleting the column and then inserting a new column
    ///  with only nummeric (integer) data.
    /// </summary>
    class Categorization : ICompleteFilter
    {
        Dictionary<int, string> dictionary;

        int columnIndex;
        int inputCount;

        public string Name
        {
            get { return "Categorization Filter"; }
        }

        public string Description
        {
            get { return "Replaces string with discrete nummeric captions"; }
        }

        public int InputCount
        {
            get { return inputCount; }
        }

        public int OutputCount
        {
            // This is a non-destructive filter, so the number
            //  of outputs should equal the number of inputs
            get { return inputCount; }
        }

        public int Column
        {
            get { return columnIndex; }
            set { columnIndex = value; }
        }


        public void Apply(object input)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Apply(object[] input)
        {
            string str = (string)input[columnIndex];

            // Check if this string is already in the dictionary
            if (!dictionary.ContainsValue(str))
            {
                // No, it isn't
                int key = dictionary.Count;
                dictionary.Add(key, str);
                input[columnIndex] = key;
            }
            else
            {
                // It is on the dictionary, so we must search for
                //  the key associated with it.
                // [this doesn't seems right, but will make reversion easier]
                // TODO: Rethink the dictionary approach for categorization filter.
                foreach (KeyValuePair<int, string> pair in dictionary)
                {
                    if (pair.Value == str)
                        input[columnIndex] = pair.Key;
                }
            }
            
        }

        public void Apply(object[][] input)
        {
            foreach (object[] row in input)
            {
                Apply(row);
            }
        }

        public void Reverse(object input)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Reverse(object[] input)
        {
            int key = (int)input[columnIndex];

            // Check if the key is in the dictionary
            if (!dictionary.ContainsKey(key))
            {
                // No, it isn't. This wasn't expected
                //throw new InvalidOperationException();
                input[columnIndex] = "#N/D";
            }
            else
            {
                // It was on the dictionary, proceed as normal
                input[columnIndex] = dictionary[key];
            }
        }

        public void Reverse(object[][] input)
        {
            foreach (object[] row in input)
            {
                Reverse(row);
            }
        }


    }
}
