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
using System.IO;

using Sinapse.Core.Networks;

namespace Sinapse.Extensions.CodeGeneration
{
    public abstract class CodeGenerator
    {

        private NetworkContainerBase m_network;


        //---------------------------------------------


        #region Constructor
        protected CodeGenerator(NetworkContainerBase network)
	    {
            this.m_network = network;
        }
        #endregion


        //---------------------------------------------


        #region Properties
        public NetworkContainerBase Network
        {
            get { return m_network; }
            set { m_network = value; }
        }
        #endregion


        //---------------------------------------------


        #region Abstract Methods
        protected abstract void build(StringBuilder codeBuilder);
    //    protected abstract void generateTransformationLayer();
    //    protected abstract void generateNetwork();
    //    protected abstract void generateMethods();
        #endregion

        #region Protected Methods
        protected string ident(string text, int spaces)
        {
            String blank = new String(' ',spaces);
            return text.Replace("\n", "\n" + blank).Insert(0, blank); ;
        }
        #endregion


        //---------------------------------------------


        #region Public Methods
        public string Generate()
        {
            StringBuilder codeBuilder = new StringBuilder();
            this.build(codeBuilder);
            return codeBuilder.ToString();
        }

        public void Save(string path)
        {
            TextWriter tw = new StreamWriter(path, false, Encoding.Default);
            tw.Write(this.Generate());
            tw.Close();
        }
        #endregion


    }
}
