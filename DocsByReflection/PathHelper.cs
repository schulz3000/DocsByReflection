using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DocsByReflection
{
	/// <summary>
	/// Internal path helper.
	/// </summary>
	public static class PathHelper
	{
		#region Methods
		/// <summary>
		/// Gets the assembly document file name from code base.
		/// </summary>
		/// <returns>The assembly document file name from code base.</returns>
		/// <param name="assemblyCodeBase">Assemby code base.</param>
		public static string GetAssemblyDocFileNameFromCodeBase(string assemblyCodeBase)
		{
			if (String.IsNullOrEmpty (assemblyCodeBase)) {
				throw new ArgumentNullException (nameof(assemblyCodeBase));
			}

			var prefix = "file:///";

			if (assemblyCodeBase.StartsWith (prefix, StringComparison.OrdinalIgnoreCase)) {
				var filePath = assemblyCodeBase.Substring (prefix.Length);

                //RuntimeInformation

                if (!IsWindows) {
					filePath = "/" + filePath;
				}

				return Path.ChangeExtension (filePath, ".xml");
			}
			else
			{
				throw new DocsByReflectionException("Could not ascertain assembly filename from assembly code base '{0}'.",assemblyCodeBase);
			}
		}

        static bool IsWindows
        {
            get
            {
#if COREFX
                return RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
#else
            return !(Environment.OSVersion.Platform== PlatformID.MacOSX || Environment.OSVersion.Platform == PlatformID.Unix);
#endif
            }
        }

        #endregion
    }
}