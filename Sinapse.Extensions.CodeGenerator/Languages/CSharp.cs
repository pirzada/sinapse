/***************************************************************************
 *   Sinapse Neural Networking Tool         http://sinapse.googlecode.com  *
 *  ---------------------------------------------------------------------- *
 *   Copyright (C) 2006-2008 Cesar Roberto de Souza <cesarsouza@gmail.com> *
 *                                                                         *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 3 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 ***************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

using AForge;
using AForge.Neuro;

using Sinapse.Core.Networks;


namespace Sinapse.Extensions.CodeGeneration
{
    internal sealed class CSharpGenerator : CodeGenerator
    {

        public CSharpGenerator(NetworkContainer network)
            : base(network)
        {
        }


        protected override void build(StringBuilder cB)
        {


        }


        //---------------------------------------------


        #region Network Compute Functions

        private string createActivationFunction()
        {
            return String.Empty;
        }

        private string createActivationFunction(BipolarSigmoidFunction function)
        {
            return String.Format("return ((2 / (1 + Math.Exp( -{0} * x))) - 1);", function.Alpha);
        }

        private string createActivationFunction(SigmoidFunction function)
        {
            return String.Format("return ( 1 / ( 1 + Math.Exp( -{0} * x ) ) );", function.Alpha);
        }

        private string createActivationFunction(ThresholdFunction function)
        {
            return "return ( x >= 0 ) ? 1 : 0;";
        }
        #endregion


        //---------------------------------------------


        #region Network Weight Generation Functions
        private string createNetworkGenerator()
        {
      /*      StringBuilder sb = new StringBuilder();
            sb.AppendFormat("this.network = new double[{0}][][];\n",nNetwork.LayersCount);

            for (int i = 0; i < nNetwork.LayersCount; ++i)
            {
                sb.AppendFormat("\nthis.network[{0}] = new double [{1}][];\n", i, nNetwork[i].NeuronsCount);
                
                for (int j = 0; j < nNetwork[i].NeuronsCount; ++j)
                {
                    sb.AppendFormat("this.network[{0}][{1}] = new double[] {2};\n", i, j, createNeuronArray(i,j));
                }
            }
       */
            return String.Empty;
        }

        private string createNeuronArray(int layer, int neuron)
        {
            StringBuilder sb = new StringBuilder();
            Neuron nNeuron = this.Network.Network[layer][neuron];

            sb.Append("{ ");
            for (int i = 0; i < nNeuron.InputsCount; ++i)
            {
                sb.Append(nNeuron[i]);
                if (i < nNeuron.InputsCount - 1)
                {
                    sb.Append(", ");
                }
            }
            sb.Append(" }");
            return sb.ToString();
        }
        #endregion

        
        //---------------------------------------------


        #region Normalization Functions
   /*     private string createNormalizationFunctions()
        {
            StringBuilder sb = new StringBuilder();

            DoubleRange from, to;
            foreach (String col in this.Network.Schema.AllColumns)
            {

                from = this.Network.Schema.DataRanges.GetRange(col);
                to = this.Network.Schema.DataRanges.ActivationFunctionRange;
                      
                if ((this.Network.Schema.IsCategory(col)))
                {
                    sb.AppendFormat("private double normalize_{0}(string value)\n", col.Replace(" ", "_"));
                    sb.AppendLine("{");
                    sb.AppendLine("   double id;");
                    sb.AppendLine();
                    sb.AppendLine("   switch (value)");
                    sb.AppendLine("   {");

                    foreach (DataCategory category in this.Network.Schema.DataCategories.GetCaptionList(col))
                    {
                        sb.AppendFormat("      case {0}:\n", category.Value);
                        sb.AppendFormat("         id = {0};\n", category.Id);
                        sb.AppendLine  ("      break;\n\n");
                    }
                    sb.AppendLine("   }");
                    
                    sb.AppendLine("}");
                }
                else
                {
                    sb.AppendFormat("private double normalize_{0}(double value)\n", col.Replace(" ", "_"));
                    sb.AppendLine("{");
                }
                // return ((value - from.Min) * (to.Length) / (from.Length)) + to.Min;
                sb.AppendFormat("return ((value - {0}) * ({1}) / ({2}) + {3};",from.Min,to.Length,from.Length, to.Min);
                sb.Append("\n}\n\n");
            }

            return sb.ToString();
        }

        private string createRevertFunctions()
        {
            StringBuilder sb = new StringBuilder();

            DoubleRange from, to;
            foreach (String col in this.Network.Schema.AllColumns)
            {

                from = this.Network.Schema.DataRanges.ActivationFunctionRange;
                to = this.Network.Schema.DataRanges.GetRange(col);

                if ((this.Network.Schema.IsCategory(col)))
                {
                    sb.AppendFormat("private string revert_{0}(double value, double threshold)\n", col.Replace(" ", "_"));
                    sb.AppendLine("{");
                    sb.Append("   double normData = ");
                    sb.AppendFormat("((value - {0}) * ({1}) / ({2}) + {3};", from.Min, to.Length, from.Length, to.Min);

                    sb.AppendLine();
                    sb.AppendLine("   switch (normData)");
                    sb.AppendLine("   {");

                    foreach (DataCategory category in this.Network.Schema.DataCategories.GetCaptionList(col))
                    {
                        sb.AppendFormat("      case {0}:\n", category.Value);
                        sb.AppendFormat("         id = {0};\n", category.Id);
                        sb.AppendLine("      break;\n\n");
                    }
                    sb.AppendLine("   }");

                    sb.AppendLine("}");
                }
                else
                {
                    sb.AppendFormat("private string revert_{0}(double value)\n", col.Replace(" ", "_"));
                    sb.AppendLine("{");
                    sb.AppendFormat("return ((value - {0}) * ({1}) / ({2}) + {3};", from.Min, to.Length, from.Length, to.Min);
                }
                // return ((value - from.Min) * (to.Length) / (from.Length)) + to.Min;
                sb.Append("\n}\n\n");
            }

            return sb.ToString();
        }
    */ 
        #endregion


    }
}
