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

namespace Sinapse.Core.Filters
{
    public abstract class IFilter
    {
        public abstract object Input { get; set; }
        public abstract object Output { get; protected set; }
        public abstract void Apply();
    }

    public class IFilterCollection : System.ComponentModel.BindingList<IFilter>
    {

        public IFilterCollection()
        {

        }

        public object Apply(object source)
        {
            try
            {
                foreach (IFilter filter in this)
                {
                    filter.Input = source;
                    filter.Apply();
                    source = filter.Output;
                }
            }
            catch
            {
            }

            return source;
        }

    }

    
}
