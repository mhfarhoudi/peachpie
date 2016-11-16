﻿using Pchp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pchp.Library
{
    /// <summary>
	/// Implements PHP function over constants.
	/// </summary>
	/// <threadsafety static="true"/>
    public static class Constants
    {
        /// <summary>
        /// Defines a constant.
        /// </summary>
        /// <param name="ctx">Current runtime context.</param>
        /// <param name="name">The name of the constant. Can be arbitrary string.</param>
        /// <param name="value">The value of the constant. Can be <B>null</B> or a scalar or array.</param>
        /// <param name="caseInsensitive">Whether the name is case insensitive.</param>
        /// <returns>Whether the new constant has been defined.</returns>
        public static bool define(Context ctx, string name, PhpValue value, bool caseInsensitive = false)
            => ctx.DefineConstant(name, value, caseInsensitive);

        /// <summary>
        /// Determines whether a constant is defined.
        /// </summary>
        /// <param name="ctx">Current runtime context.</param>
        /// <param name="name">The name of the constant.</param>
        /// <returns>Whether the constant is defined.</returns>
        public static bool defined(Context ctx, string name)
            => ctx.IsConstantDefined(name);

        /// <summary>
		/// Retrieves a value of a constant.
		/// </summary>
		/// <param name="ctx">Current runtime context.</param>
        /// <param name="name">The name of the constant.</param>
		/// <returns>The value.</returns>
		public static PhpValue constant(Context ctx, string name)
            => ctx.GetConstant(name);

        /// <summary>
        /// Retrieves defined constants.
        /// </summary>
        /// <param name="ctx">Current runtime context.</param>
        /// <param name="categorize">Returns a multi-dimensional array with categories in the keys of the first dimension and constants and their values in the second dimension. </param>
        /// <returns>Retrives the names and values of all the constants currently defined.</returns>
        public static PhpArray get_defined_constants(Context ctx, bool categorize = false)
        {
            var result = new PhpArray();

            if (categorize)
            {
                throw new NotImplementedException();
            }
            else
            {
                foreach (var c in ctx.GetConstants())
                {
                    result.Add(c.Key, c.Value);
                }
            }

            //
            return result;
        }
    }
}
