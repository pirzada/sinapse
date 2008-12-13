using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using AForge.Neuro;

namespace Sinapse.Editors
{
    public partial class ActivationNetworkDesigner : UserControl
    {
        private IActivationFunction function;

        public ActivationNetworkDesigner()
        {
            InitializeComponent();

            this.cbActivationFunction.DisplayMember = "Name";
            this.cbActivationFunction.DataSource = GetTypesImplementingInterface(typeof(IActivationFunction));
        }


        /// <summary>
        /// Returns all types in the current AppDomain implementing the interface or inheriting the type. 
        /// </summary>
        public static Type[] GetTypesImplementingInterface(Type baseType)
        {
            
            List<Type> childTypes = new List<Type>();

            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type type in assembly.GetTypes())
                {
                    foreach (Type interfaceType in type.GetInterfaces())
                    {
                        if (interfaceType.Equals(baseType))
                        {
                            childTypes.Add(type);
                        }
                    }
                }
            }
            return childTypes.ToArray();
        }

        private void cbActivationFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            Type functionType = cbActivationFunction.SelectedItem as Type;
            if (functionType != null)
            {

                this.function = (IActivationFunction)System.Activator.CreateInstance(functionType);
                this.propertyGrid1.SelectedObject = function;
            }
        }
    }
}
