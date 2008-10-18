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


using AForge.Mathematics;

namespace Sinapse.Core.Transformations
{
    public interface ITransformation
    {
        Matrix Apply(Matrix source);

        int Inputs { get; }
        int Outputs { get; }

      //  bool IsDimensionConservative { get; }
    }

    public class ITransformationCollection : System.ComponentModel.BindingList<ITransformation>
    {

        public ITransformationCollection()
        {

        }

        public Matrix Apply(Matrix source)
        {
            foreach (ITransformation transform in this)
            {
                source = transform.Apply(source);
            }

            return source;
        }

    }

    
}
