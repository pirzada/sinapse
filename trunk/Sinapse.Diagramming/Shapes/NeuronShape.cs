using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using Netron.Diagramming.Core;

namespace Sinapse.Diagramming.Shapes
{
    public class NeuronShape : ShapeBase
    {
        Connector connInput;
        Connector connOutput;


        public NeuronShape()
        {
            addConnectors();
        }

        public Connector Input
        {
            get { return connInput; }
        }

        public Connector Output
        {
            get { return connOutput; }
        }
        

        private void addConnectors()
        {
            connInput = new Connector(new Point(Rectangle.Left, (int)(Rectangle.Top + Rectangle.Height / 2)), Model);
            connInput.Name = "Input Connector";
            connInput.Parent = this;
            Connectors.Add(connInput);

            connOutput = new Connector(new Point(Rectangle.Right, (int)(Rectangle.Top + Rectangle.Height / 2)), Model);
            connOutput.Name = "Output Connector";
            connOutput.Parent = this;
            Connectors.Add(connOutput);
        }


        public override void Paint(System.Drawing.Graphics g)
        {
            base.Paint(g);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //the shadow
            if (ArtPallet.EnableShadows)
                g.FillEllipse(ArtPallet.ShadowBrush, Rectangle.X + 5, Rectangle.Y + 5, Rectangle.Width, Rectangle.Height);

            //the actual bundle
            g.FillEllipse(Brush, Rectangle);

            //the edge of the bundle
            if (Hovered || IsSelected)
                g.DrawEllipse(ArtPallet.HighlightPen, Rectangle);
            else
                g.DrawEllipse(ArtPallet.BlackPen, Rectangle);
            
            //the connectors
            for (int k = 0; k < Connectors.Count; k++)
            {
                Connectors[k].Paint(g);
            }

            //here we keep it really simple:
         /*   if (!string.IsNullOrEmpty(Text))
                g.DrawString(Text, ArtPallet.DefaultFont, Brushes.Black, TextRectangle);
          */ 
        }




        public override string EntityName
        {
            get { return "Neuron"; }
        }

    }
}
