using System;
using System.Collections.Generic;
using System.Text;

using Sinapse.Core.Systems;
using Sinapse.Core.Sources;
using Sinapse.Core.Filters;


namespace Sinapse.Core.Training
{
    public abstract class TrainingSession : ISinapseComponent
    {
        public enum SessionState { Stopped, Paused, Running, Error };

        private SinapseComponent workplaceComponent;

        private TrainingHistory history;
        private TableDataSource dataSource;
        private AdaptiveSystem adaptiveSystem;
        private SessionState state;
        private string notes;
        

        public abstract void Start();
        public abstract void Stop();
        public abstract void Pause();
        public abstract void Reset();


        public event EventHandler Started;
        public event EventHandler Stopped;
        public event EventHandler Paused;
        public event EventHandler Reseted;
        public event EventHandler Completed;
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

        public SessionState State
        {
            get { return state; }
            protected set { state = value; }
        }

        public string Notes
        {
            get { return notes; }
            set { notes = value; }
        }



        protected virtual void OnAdaptiveSystemChanged(EventArgs e)
        {
            if (AdaptiveSystemChanged != null)
                AdaptiveSystemChanged.Invoke(this, e);
        }

        protected virtual void OnDataSourceChanged(EventArgs e)
        {
            if (AdaptiveSystemChanged != null)
                AdaptiveSystemChanged.Invoke(this, e);
        }

        protected virtual void OnStarted(EventArgs e)
        {
            if (Started != null)
                Started.Invoke(this, e);
        }

        protected virtual void OnStopped(EventArgs e)
        {
            if (Stopped != null)
                Stopped.Invoke(this, e);
        }

        protected virtual void OnPaused(EventArgs e)
        {
            if (Paused != null)
                Paused.Invoke(this, e);
        }

        protected virtual void OnCompleted(EventArgs e)
        {
            if (Completed != null)
                Completed.Invoke(this, e);
        }








        #region IWorkplaceComponent Members

        public string Name
        {
            get { return workplaceComponent.Name; }
            set { workplaceComponent.Name = value; }
        }

        public string Description
        {
            get { return workplaceComponent.Description; }
            set { workplaceComponent.Description = value; }
        }

        public string Remarks
        {
            get { return workplaceComponent.Remarks; }
            set { workplaceComponent.Remarks = value; }
        }

        public bool HasChanges
        {
            get { return workplaceComponent.HasChanges; }
            protected set { workplaceComponent.HasChanges = value; }
        }

        public event EventHandler Changed;
        public event EventHandler Closed;

        #endregion


    }
}
