using System;


using AForge.Math;

namespace Sinapse.Core.Transformations
{
    public interface ITransformation
    {
        void Apply(Matrix m);

        int Inputs { get; }
        int Outputs { get; }
    }

    public class ITransformationCollection : System.ComponentModel.BindingList<ITransformation>
    {
        public ITransformationCollection()
        {

        }

        public void Apply(Matrix m)
        {
            foreach (ITransformation transform in this)
            {
                transform.Apply(m);
            }
        }
    }
}
