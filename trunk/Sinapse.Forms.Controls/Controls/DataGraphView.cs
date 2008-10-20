using System;
using System.Collections.Generic;
using System.Text;
using ZedGraph;

namespace Sinapse.Forms.Controls
{
   public class DataGraphView  : System.Windows.Forms.Control
    {
        public enum ViewMode { Bar, Pie, Boxplot, Scatterplot, Histogram, CumulativeHistogram };


        private ZedGraphControl m_graph;
        private String m_dataMember;
        private object m_dataSource;

        public DataGraphView()
        {
            m_graph = new ZedGraphControl();
            m_graph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Controls.Add(m_graph);
        }

        public ZedGraphControl Graph
        {
            get { return m_graph; }
        }

        public String DataMember
        {
            get { return this.m_dataMember; }
            set { this.m_dataMember = value; }
        }

        public object DataSource
        {
            get { return this.m_dataSource; }
            set { this.m_dataSource = value; }
        }
    }
}
