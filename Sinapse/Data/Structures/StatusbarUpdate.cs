using System;
using System.Collections.Generic;
using System.Text;

namespace Sinapse.Data.Structures
{

    public enum UpdateBy { Epochs, Time };

    
    internal struct StatusbarUpdate
    {

        internal int Epoch;
        internal int Progress;
        internal double EpochsBySecond;
        internal double ErrorTraining;
        internal double ErrorValidation;


        internal void Reset()
        {
            Epoch = 0;
            Progress = 0;
            ErrorTraining = 0;
            ErrorValidation = 0;
            EpochsBySecond = 0;
        }
    }
}
