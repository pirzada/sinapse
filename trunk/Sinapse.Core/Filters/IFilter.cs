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

using AForge.Mathematics;

namespace Sinapse.Core.Filters
{
    /// <summary>
    /// A Filter is a proccess from which a Input is processed and then transformed in a Output. Some transformations are reversible, where others are not.
    /// </summary>
    /// <remarks>This is a Interface and thus cannot be instantiated.</remarks>
    public interface IFilter
    {

/*
        object Input { get; set; }
        object Output { get; }
*/
        int InputCount { get; }
        int OutputCount { get; }

        void Apply(object input); // For special transport units (Matrix and such) that can be optimized
        void Apply(object[] input); // For single entries
        void Apply(object[][] input); // For a full set of entries

        string Name { get; }
        string Description { get; }

    }

    /// <summary>
    ///   A filter which can be reversed.
    /// </summary>
    interface ICompleteFilter : IFilter
    {
        void Reverse(object input);
        void Reverse(object[] input);
        void Reverse(object[][] input);
    }


    public class FilterCollection : System.ComponentModel.BindingList<IFilter>
    {

        private bool reversible;

        public int InputCount
        {
            get
            {
                if (this.Count == 0)
                    return 0;
                else return this[0].InputCount;
            }
        }

        public int OutputCount
        {
            get
            {
                if (this.Count == 0)
                    return 0;
                else return this[this.Count - 1].OutputCount;
            }
        }
        

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

        public FilterCollection(bool reversible)
        {
            this.reversible = reversible;
        }

        public void Apply(object input)
        {
            throw new NotImplementedException();
        }

        public void Apply(object[] input)
        {
            try
            {
                foreach (IFilter filter in this)
                {
                    filter.Apply(input);
                }
            }
            catch (InputMismatchException ex)
            {
            }
            catch (Exception ex)
            {
            }
        }

        public void Apply(object[][] input)
        {
            try
            {
                foreach (IFilter filter in this)
                {
                    filter.Apply(input);
                }
            }
            catch (InputMismatchException ex)
            {
            }
            catch (Exception ex)
            {
            }
        }


        public void Revert(object input)
        {
            throw new NotImplementedException();
        }

        public void Reverse(object[][] input)
        {
            try
            {
                foreach (ICompleteFilter filter in this.GetReverseEnumerator())
                {
                    filter.Reverse(input);
                }
            }
            catch (InputMismatchException ex)
            {
            }
            catch (Exception ex)
            {
            }
        }

        public void Reverse(object[] input)
        {
            try
            {
                foreach (ICompleteFilter filter in this.GetReverseEnumerator())
                {
                    filter.Reverse(input);
                }
            }
            catch (InputMismatchException ex)
            {
            }
            catch (Exception ex)
            {
            }
        }


        public IEnumerable<IFilter> GetReverseEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this[i];
            }
        }

    }
}
