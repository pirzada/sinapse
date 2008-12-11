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
    /// <summary>
    /// A Filter is a proccess from which a Input is processed and then transformed in a Output. Some transformations are reversible, where others are not.
    /// </summary>
    /// <remarks>This is a Interface and thus cannot be instantiated.</remarks>
    public interface IFilter
    {
        // Cada filtro teria de suportar Matrix, Vector, DataTable, object[] e object[][]
        // object[] e object[][] seriam os fallbacks, os outros seriam otimizados

        object Input { get; set; }
        object Output { get; }
        void Apply();

        string Name { get; }
        string Description { get; }

        System.Windows.Forms.Control Control { get; }
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
            catch (InputMismatchException ex)
            {
            }
            catch (Exception ex)
            {
            }

            return source;
        }

    }

    
}
