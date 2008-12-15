using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using Netron.Diagramming.Core;

namespace Sinapse.Diagramming.Shapes
{
    public class InputShape : SimpleShapeBase
    {
        
        Connector connOutput;


        public InputShape()
        {
            addConnectors();
        }



        public Connector Output
        {
            get { return connOutput; }
        }



        private void addConnectors()
        {
            connOutput = new Connector(new Point(Rectangle.Right, (int)(Rectangle.Top + Rectangle.Height / 2)), Model);
            connOutput.Name = "Output Connector";
            connOutput.Parent = this;
            Connectors.Add(connOutput);
        }



        public override void Paint(System.Drawing.Graphics g)
        {
            base.Paint(g);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;


            // Paint the small triangle next to the text
            Point[] triangle = { new Point(TextRectangle.X + TextRectangle.Width + 5,  TextRectangle.Y),
                                 new Point(TextRectangle.X + TextRectangle.Width + 10, TextRectangle.Y + TextRectangle.Height/2),
                                 new Point(TextRectangle.X + TextRectangle.Width + 5,  TextRectangle.Y + TextRectangle.Height) };

            g.FillPolygon(Brushes.Black, triangle);


            // Paint the Connector
            connOutput.Paint(g);


            // Paint the Text
            if (!String.IsNullOrEmpty(Text))
                g.DrawString(Text, ArtPallet.DefaultFont, Brushes.Black, TextRectangle);
          
        }


        
        public override string EntityName
        {
            get { return "Input"; }
        }
    }
}
