using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Sinapse.Core;
using Sinapse.Core.Training;
using Sinapse.Core.Sources;
using Sinapse.Core.Systems;

namespace Sinapse.Windows
{
    public partial class TrainingTableVisualizer : WeifenLuo.WinFormsUI.Docking.DockContent
    {

        TableDataSource dataSource;
        AdaptiveSystem adaptiveSystem;
        DataView currentView;

        public TrainingTableVisualizer()
        {
            InitializeComponent();
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            // Lembrete: O usuário nao deve poder alterar a tabela nesta janela, que
            //  é apenas um visualizador. Então devemos usar cópias de DataTables imutáveis

            int inputCount = dataSource.Columns.Count(TableDataSourceColumn.ColumnRole.Input);
            int outputCount = dataSource.Columns.Count(TableDataSourceColumn.ColumnRole.Output);



            foreach (DataRow row in currentView.Table)
            {
                object[] inputs = dataSource.GetData(row, DataSourceRole.Input);
                object[] outputs = dataSource.GetData(row, DataSourceRole.Output);
                object[] rawOutputs;
                object[] deviations;

                adaptiveSystem.Test(inputs, outputs, rawOutputs, deviations);

                dataSource.SetData(row, DataSourceRole.Input, inputs);
                dataSource.SetData(row, DataSourceRole.Output, outputs);

            }



            outputs = adaptiveSystem.Test(inputs);

            // Copiar o vetor de saída para a linha


        }


    }
}