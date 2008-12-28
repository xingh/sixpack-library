// AssemblyInfo.cs 
//
//  Copyright (C) 2008 Fullsix Marketing Interactivo LDA
//  Author: Marco Cecconi <marco.cecconi@gmail.com>
//  Author: Antoine Aubry <aaubry@gmail.com>
//
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
//
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
// Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA 
//

using System;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

#if DEBUG
[assembly : AssemblyConfiguration("Debug")]
#else
[assembly : AssemblyConfiguration("Release")]
#endif
[assembly : AssemblyCompany("SixPack")]
[assembly : AssemblyProduct("SixPack Library")]
[assembly : AssemblyCopyright("Copyright © 2007, 2008")]
[assembly : AssemblyTrademark("")]
[assembly : AssemblyCulture("")]
[assembly : CLSCompliant(true)]
[assembly : ComVisible(false)]
[assembly : NeutralResourcesLanguage("en")]
