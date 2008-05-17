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
