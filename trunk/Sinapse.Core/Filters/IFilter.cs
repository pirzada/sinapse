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
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

using AForge.Mathematics;

using System.Data;

namespace Sinapse.Core.Filters
{
    /// <summary>
    ///   A Filter is a proccess from which a Input is processed and then transformed in a Output.
    ///   Some transformations are reversible, where others are not.
    ///   
    ///   All filters operate on objects. The object must be cast to the correct class before
    ///   it can be manipulated. Currently, only DataTables are supported.
    /// </summary>
    /// <remarks>This is a Interface and thus cannot be instantiated.</remarks>
    public interface IFilter
    {

        void Apply(object input); // For special transport units (Matrix and such) that can be optimized
    }


    /// <summary>
    ///   A filter which can be reversed.
    /// </summary>
    interface ICompleteFilter : IFilter
    {
        void Reverse(object input);
    }


    [Serializable]
    public class FilterCollection : System.ComponentModel.BindingList<IFilter>
    {

        /// <summary>
        ///   Constructs a new filter collection.
        /// </summary>
        /// <param name="reversible"></param>
        public FilterCollection()
        {
        }


        /// <summary>
        ///   Gets a value indicating if all filters are reversible.
        /// </summary>
        public bool IsReversible
        {
            get
            {
                foreach (IFilter filter in this)
                {
                    if ((filter is ICompleteFilter) == false)
                        return false;
                }
                return true;
            }
        }

        
        /// <summary>
        ///   Applies the forward filter process.
        /// </summary>
        /// <param name="input"></param>
        public void Apply(object input)
        {
            try
            {
                foreach (IFilter filter in this)
                {
                    filter.Apply(input);
                }
            }
            catch (Exception ex)
            {
            }
        }


        /// <summary>
        ///   Reverses the filter process
        /// </summary>
        /// <param name="input"></param>
        public void Reverse(object input)
        {
            try
            {
                foreach (ICompleteFilter filter in this.GetReverseEnumerator())
                {
                    filter.Reverse(input);
                }
            }
            catch (Exception ex)
            {
            }
        }

        
        /// <summary>
        ///   Gets an enumerator to iterate the class backwards
        ///   using the foreach loop.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IFilter> GetReverseEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this[i];
            }
        }




        /// <summary>
        ///   Lists all filters installed on this system.
        /// </summary>
        /// <returns></returns>
        public static Type[] ListFilters()
        {
            List<Type> filters = new List<Type>();

            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type type in assembly.GetTypes())
                {
                    foreach (Type interfaceType in type.GetInterfaces())
                    {
                        if (interfaceType == typeof(IFilter))
                        {
                            filters.Add(type);
                        }
                    }
                }
            }
            return filters.ToArray();
        }


    }

}
