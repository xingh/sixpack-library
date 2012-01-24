﻿// MergeExtensions.cs
//
//  Copyright (C) 2012 Antoine Aubry
//  Author: Antoine Aubry
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
using System.Collections.Generic;
using SixPack.Collections.Generic.Extensions;

namespace SixPack.Collections.Algorithms
{
	/// <summary>
	/// Extension methods that allow to merge two sequences.
	/// </summary>
	public static class MergeExtensions
	{
		/// <summary>
		/// Correlates the elements of two sequences based on matching keys simmilarly to a "full outer join" in SQL.
		/// For each results, executes an action
		/// </summary>
		/// <typeparam name="TOuter">The type of the outer sequence elements.</typeparam>
		/// <typeparam name="TInner">The type of the inner sequence elements.</typeparam>
		/// <typeparam name="TKey">The type of the key.</typeparam>
		/// <param name="outer">The outer sequence.</param>
		/// <param name="inner">The inner sequence.</param>
		/// <param name="outerKeySelector">The outer key selector.</param>
		/// <param name="innerKeySelector">The inner key selector.</param>
		/// <param name="uniqueOuterProcessor">An action that is invoked for each element from <paramref name="outer"/> that is not present in <paramref name="inner"/>.</param>
		/// <param name="uniqueInnerProcessor">An action that is invoked for each element from <paramref name="inner"/> that is not present in <paramref name="outer"/>.</param>
		/// <param name="matchProcessor">An action that is invoked for each element from <paramref name="inner"/> that is also present in <paramref name="outer"/>.</param>
		/// <param name="comparer">The comparer used for key comparisons. Defaults to EqualityComparer&lt;TKey&gt;.Default.</param>
		public static void Merge<TOuter, TInner, TKey>(
			this IEnumerable<TOuter> outer,
			IEnumerable<TInner> inner,
			Func<TOuter, TKey> outerKeySelector,
			Func<TInner, TKey> innerKeySelector,
			Action<TOuter> uniqueOuterProcessor,
			Action<TInner> uniqueInnerProcessor,
			Action<TOuter, TInner> matchProcessor,
			IEqualityComparer<TKey> comparer = null
		)
		{
			outer
				.OuterJoin<TOuter, TInner, TKey, Action>(
					inner,
					outerKeySelector,
					innerKeySelector,
					o => () => uniqueOuterProcessor(o),
					i => () => uniqueInnerProcessor(i),
					(o, i) => () => matchProcessor(o, i),
					comparer
				)
				.ForAll(p => p());
		}
	}
}
