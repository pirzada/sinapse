using System;
using System.Collections.Generic;
using System.Text;

namespace Sinapse.Core.Training
{
    /// <summary>
    /// Multi-threaded multiple training sessions.
    /// </summary>
    public class MultipleTrainingSession
    {

        private List<TrainingSession> trainingSessions;

        public MultipleTrainingSession()
        {

        }

        public List<TrainingSession> Sessions
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}
