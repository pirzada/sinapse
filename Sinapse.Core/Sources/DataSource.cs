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
using System.Collections.Generic;
using System.Text;
using System.Data;

using AForge.Mathematics;

using Sinapse.Core.Filters;
using Sinapse.Core.Systems;


namespace Sinapse.Core.Sources
{

    [Flags]
    public enum DataSourceSet { None = 0, Training = 2, Testing = 8, Validation = 16, };

    public enum DataSourceRole { None = 0, Input = 1, Output = 2 };

    /// <summary>
    ///   This class encompass a Adaptive System DataSource, or in other words, a
    ///   source of information that can be used to train and feed Adaptive Systems.
    ///   A common example of data sources are tables of sample data or a collection
    ///   of images.
    /// </summary>
    public interface IDataSource 
    {
        void Shuffle();

        object GetData(DataSourceSet set);
        object GetData(DataSourceSet set, DataSourceRole role);
        object GetData(DataSourceSet set, int subset);
        object GetData(DataSourceSet set, int subset, DataSourceRole role);

        event EventHandler Changed;
        event EventHandler DataChanged;
    }
}
