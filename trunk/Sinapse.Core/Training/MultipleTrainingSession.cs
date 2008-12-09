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

        private List<BackpropagationTrainingSession> trainingSessions;

        public MultipleTrainingSession()
        {

        }

        public List<BackpropagationTrainingSession> Sessions
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}
