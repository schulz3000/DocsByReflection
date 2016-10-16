//Except where stated all code and programs in this project are the copyright of Jim Blackler, 2008.
//jimblackler@gmail.com
//
//This is free software. Libraries and programs are distributed under the terms of the GNU Lesser
//General Public License. Please see the files COPYING and COPYING.LESSER.

using System;
using System.Runtime.Serialization;

namespace DocsByReflection
{
    /// <summary>
    /// An exception thrown by the DocsByReflection library
    /// </summary>
   	[Serializable]
    public class DocsByReflectionException : Exception
	{
		#region Constructors
		/// <summary>
		/// Initializes a new <see cref="DocsByReflectionException"/> class.
		/// </summary>
		public DocsByReflectionException()
		{
		}

		/// <summary>
        /// Initializes a new exception instance with the specified
        /// error message and a reference to the inner exception that is the cause of
        /// this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or null if none.</param>
        public DocsByReflectionException(string message, Exception innerException)
            : base(message, innerException)
        {

		}

        public DocsByReflectionException(string message, params string[] args)
            : base(string.Format(message,args))
        {

        }        
        #endregion
    }
}
