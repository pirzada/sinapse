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
        private TableDataSource dataSource;
        private AdaptiveSystem adaptiveSystem;



        public abstract void Start();
        public abstract void Stop();
        public abstract void Pause();
        public abstract void Reset();


        public event EventHandler TrainingStarted;
        public event EventHandler TrainingStopped;
        public event EventHandler TrainingPaused;
        public event EventHandler TrainingReset;
        public event EventHandler TrainingComplete;
        public event EventHandler AdaptiveSystemChanged;
        public event EventHandler DataSourceChanged;


        public TrainingHistory History
        {
            get { return history; }
        }

        public TableDataSource DataSource
        {
            get { return dataSource; }
            protected set { dataSource = value; }
        }

        public AdaptiveSystem AdaptiveSystem
        {
            get { return adaptiveSystem; }
            protected set { adaptiveSystem = value; }
        }



        protected virtual void OnAdaptiveSystemChanged()
        {
            if (AdaptiveSystemChanged != null)
                AdaptiveSystemChanged.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnDataSourceChanged()
        {
            if (AdaptiveSystemChanged != null)
                AdaptiveSystemChanged.Invoke(this, EventArgs.Empty);
        }


    }
}
