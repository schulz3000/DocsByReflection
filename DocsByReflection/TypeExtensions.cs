using System;

namespace DocsByReflection
{
#if NET35 || NET40
    public static class TypeExtensions
    {
        public static Type GetTypeInfo(this Type type)
        {
            return type;
        }
    }
#endif
}
