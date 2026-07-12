using System.Reflection;

namespace Digbyswift.Core.Extensions;

public static class AssemblyExtensions
{
    public static IEnumerable<Type> GetTypesAssignableFrom<T>(this Assembly assembly)
    {
        return assembly.GetTypesAssignableFrom(typeof(T));
    }

    public static IEnumerable<Type> GetTypesAssignableFrom(this Assembly assembly, Type compareType)
    {
        return assembly.DefinedTypes.Where(type => compareType.IsAssignableFrom(type) && compareType != type);
    }
}