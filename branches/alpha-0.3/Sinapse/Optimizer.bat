@echo off

echo  ***************************************************************************
echo  *   Sinapse Neural Networking Tool         http://sinapse.googlecode.com  *
echo  *  ---------------------------------------------------------------------- *
echo  *   Copyright (C) 2006-2008 Cesar Roberto de Souza [cesarsouza@gmail.com] *
echo  *                                                                         *
echo  *                                                                         *
echo  *   This program is free software; you can redistribute it and/or modify  *
echo  *   it under the terms of the GNU General Public License as published by  *
echo  *   the Free Software Foundation; either version 3 of the License, or     *
echo  *   (at your option) any later version.                                   *
echo  *                                                                         *
echo  *   This program is distributed in the hope that it will be useful,       *
echo  *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
echo  *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
echo  *   GNU General Public License for more details.                          *
echo  *                                                                         *
echo  ***************************************************************************
echo. 
echo. 
echo     Please wait while Sinapse native binary images are being generated...
echo.
echo.
sleep 5

C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\ngen.exe install "Sinapse.exe"

cls