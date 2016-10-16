﻿
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Xml;
namespace DocsByReflection
{
    /// <summary>
    /// Service to handle method documentations.
    /// </summary>
    internal static class DocsMethodService
    {
        /// <summary>
        /// Provides the documentation comments for a specific method.
        /// </summary>
        /// <param name="method">The MethodInfo (reflection data ) of the member to find documentation for</param>
        /// <param name="throwError">If should throw error when documentation is not found. Default is true.</param>
        /// <returns>The XML fragment describing the method</returns>
        [SuppressMessage("Microsoft.Design", "CA1059:MembersShouldNotExposeCertainConcreteTypes", MessageId = "System.Xml.XmlNode")]
        public static XmlElement GetXmlFromMember(MethodBase method, bool throwError = true)
        {
            if (method == null)
                throw new ArgumentNullException(nameof(method));
            
            // Calculate the parameter string as this is in the member name in the XML
            var parameters = new List<string>();

            foreach (var parameterInfo in method.GetParameters())
            {
                parameters.Add(DocsTypeService.GetTypeFullNameForXmlDoc(parameterInfo.ParameterType, true));
            }

            //AL: 15.04.2008 ==> BUG-FIX remove “()” if parametersString is empty
            if (parameters.Count > 0)
            {
                var result = DocsTypeService.GetXmlFromName(method.DeclaringType, 'M', string.Format("{0}({1})", method.Name, String.Join(",", parameters.ToArray())), false);

                // Try a fallback for case where a method with generic parameters is defined on base class.
                if (result == null)
                {
                    var typedParameters = new List<string>();

                    for (int i = 1; i <= parameters.Count; i++)
                    {
                        typedParameters.Add(string.Format("`{0}",i));
                    }

                    return DocsTypeService.GetXmlFromName(method.DeclaringType, 'M', string.Format("{0}({1})", method.Name, String.Join(",", typedParameters.ToArray())), throwError);
                }

                if (result == null && throwError)
                {
                    ThrowHelper.ThrowDocNotFound();
                }

                return result;
            }
            else
            {
                return DocsTypeService.GetXmlFromName(method.DeclaringType, 'M', method.Name, throwError);
            }
        }
    }
}
