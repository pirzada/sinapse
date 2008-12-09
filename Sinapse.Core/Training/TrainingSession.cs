using System;
using System.Collections.Generic;
using System.Text;

using Sinapse.Core.Systems;
using Sinapse.Core.Sources;
using Sinapse.Core.Filters;


namespace Sinapse.Core.Training
{
    public abstract class TrainingSession
    {
        private TrainingHistory history;
        private DataSource dataSource;

        // Adapter filters are necessary to match outputs from a Data Source
        //  into inputs from a Adaptive System and vice-versa
        private IFilterCollection inputAdapterFilters;
        private IFilterCollection outputAdapterFilters;


        public TrainingHistory History
        {
            get { return history; }
        }


        public abstract AdaptiveSystem AdaptiveSystem { get; protected set; }


        public abstract void Start();
        public abstract void Stop();
        public abstract void Pause();
        public abstract void Reset();


        public DataSource DataSource
        {
            get { return dataSource; }
            protected set { dataSource = value; }
        }

        public IFilterCollection InputAdapters
        {
            get { return inputAdapterFilters; }
        }

        public IFilterCollection OutputAdapters
        {
            get { return outputAdapterFilters; }
        }


    }
}
