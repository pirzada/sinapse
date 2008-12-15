using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Netron.Diagramming;
using Netron.Diagramming.Core;
using Netron.Diagramming.Win;

using Sinapse.Diagramming.Shapes;


namespace Sinapse.Diagramming
{
    public partial class NetworkDiagram : UserControl
    {

        private int[] hiddenLayersCount;
        private int spaceBetweenLayers = 30;

        private List<String> inputLabels;
        private List<String> outputLabels;

        private List<InputShape> inputShapes;
        private List<OutputShape> outputShapes;


        private List<List<NeuronShape>> hiddenLayers;
        


        public NetworkDiagram()
        {
            InitializeComponent();

            hiddenLayersCount = new int[] { 5, 10 };

            inputLabels = new List<string>();
            inputLabels.Add("Idade");
            inputLabels.Add("Diabetes");

            outputLabels = new List<string>();
            outputLabels.Add("Obito");


            Create();
        }



        public void Create()
        {
    /*        


            // First populate the input layers
            inputShapes = new List<InputShape>(inputLabels.Count);
            int maxInputWidth = 0;
            int lastPosition = 0;

            for (int i = 0; i < inputLabels.Count; i++)
            {
                InputShape shape = new InputShape();
                shape.AutoSize = true;
                shape.Text = inputLabels[0];
                inputShapes.Add(shape);
                
                if (shape.Rectangle.Width > maxInputWidth)
                    maxInputWidth = shape.Rectangle.Width;
            }

            


            // Now handle the hidden neuron layers
            hiddenLayers = new List<List<NeuronShape>>(hiddenLayers.Count);
            for (int i = 0; i < hiddenLayersCount.Length; i++)
            {
                List<NeuronShape> layer = new List<NeuronShape>();
                for (int j = 0; j < hiddenLayersCount[i]; j++)
                {
                    NeuronShape shape = new NeuronShape();
                    shape.Location.X = lastPosition;
                    shape.Location.Y = shape.;
                    outputShapes.Add(shape);
                    diagramControl1.AddShape(shape);
                }

                lastPosition = lastPosition + spaceBetweenLayers;

              //  diagramControl1.
                if (i == 0)
                {
                    connectInputs(inputShapes, layer);
                }
                hiddenLayers.Add(layer);
            }



            // Then the output layers
            outputShapes = new List<InputShape>(outputShapes.Count);

            for (int i = 0; i < outputLabels.Count; i++)
            {
                OutputShape shape = new OutputShape();
                shape.AutoSize = true;
                shape.Text = outputLabels[0];
                shape.Add(shape);
            }

            

            // Check which is the biggest layer (in height)

            // center all other layers accordingly


            // Put then on the diagram, aligned to the right
            foreach (InputShape shape in inputShapes)
            {
                shape.Location = maxInputWidth - shape.Width;
                diagramControl1.AddShape(shape);
            }

            lastPosition = maxInputWidth + spaceBetweenLayers;



            // Then place them on their correct positions




            // And finally connect everything accordingly


            */


            
        }

        /*
        private void connectNeurons(List<InputShape> h1, List<NeuronShape> h2)
        {
            foreach (InputShape n1 in h1)
            {
                foreach (NeuronShape n2 in h2)
                {
                    diagramControl1.AddConnection(n1, n2);
                }
            }
        }

        private void connectInputs(List<NeuronShape> h1, List<NeuronShape> h2)
        {
            foreach (NeuronShape n1 in h1)
            {
                foreach (NeuronShape n2 in h2)
                {
                    diagramControl1.AddConnection(n1, n2);
                }
            }
        }
        private void connectOutputs(List<NeuronShape> h1, List<OutputShape> h2)
        {
            foreach (NeuronShape n1 in h1)
            {
                foreach (OutputShape n2 in h2)
                {
                    diagramControl1.AddConnection(n1, n2);
                }
            }
        }
   
        */

    }
}
