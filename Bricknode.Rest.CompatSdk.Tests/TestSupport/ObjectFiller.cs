using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CompatSdkTests.TestSupport;

/// <summary>
/// Recursively populates an object graph with deterministic, non-default values so that a
/// round-trip mapping exercises every property (not just a hand-picked few). Values are
/// JSON-stable (fixed dates, UTC kind, deterministic Guids) so two fills of the same type
/// serialize identically.
/// </summary>
public static class ObjectFiller
{
    private const int MaxDepth = 6;
    private static readonly DateTime BaseDate = new(2021, 2, 3, 4, 5, 6, DateTimeKind.Utc);

    public static T Create<T>() => (T)Create(typeof(T))!;

    public static object? Create(Type type)
    {
        var counter = new int[] { 0 };
        return Build(type, 0, new HashSet<Type>(), counter);
    }

    private static object? Build(Type type, int depth, HashSet<Type> path, int[] counter)
    {
        var underlying = Nullable.GetUnderlyingType(type);
        if (underlying != null)
            return Build(underlying, depth, path, counter);

        var n = ++counter[0];

        if (type == typeof(string)) return "str_" + n;
        if (type == typeof(bool)) return true;
        if (type == typeof(byte)) return (byte)(n % 250 + 1);
        if (type == typeof(sbyte)) return (sbyte)(n % 120 + 1);
        if (type == typeof(short)) return (short)(n + 10);
        if (type == typeof(ushort)) return (ushort)(n + 10);
        if (type == typeof(int)) return n + 100;
        if (type == typeof(uint)) return (uint)(n + 100);
        if (type == typeof(long)) return (long)(n + 1000);
        if (type == typeof(ulong)) return (ulong)(n + 1000);
        if (type == typeof(double)) return n + 0.5d;
        if (type == typeof(float)) return n + 0.5f;
        if (type == typeof(decimal)) return n + 0.25m;
        if (type == typeof(char)) return (char)('A' + (n % 26));
        if (type == typeof(Guid)) return DeterministicGuid(n);
        if (type == typeof(DateTime)) return BaseDate.AddMinutes(n);
        if (type == typeof(DateTimeOffset)) return new DateTimeOffset(BaseDate.AddMinutes(n));
        if (type == typeof(TimeSpan)) return TimeSpan.FromMinutes(n);
        if (type == typeof(byte[])) return new byte[] { (byte)n, (byte)(n + 1) };

        if (type.IsEnum)
        {
            var values = Enum.GetValues(type);
            // pick a non-first value when possible to catch default-vs-set bugs
            return values.Length > 1 ? values.GetValue(1) : values.GetValue(0);
        }

        if (type.IsArray)
        {
            var elementType = type.GetElementType()!;
            var element = Build(elementType, depth + 1, path, counter);
            var array = Array.CreateInstance(elementType, 1);
            array.SetValue(element, 0);
            return array;
        }

        if (type.IsGenericType)
        {
            var def = type.GetGenericTypeDefinition();
            if (def == typeof(List<>) || def == typeof(IList<>) || def == typeof(ICollection<>) ||
                def == typeof(IEnumerable<>) || def == typeof(IReadOnlyList<>) || def == typeof(IReadOnlyCollection<>))
            {
                var elementType = type.GetGenericArguments()[0];
                var listType = typeof(List<>).MakeGenericType(elementType);
                var list = (IList)Activator.CreateInstance(listType)!;
                list.Add(Build(elementType, depth + 1, path, counter));
                return list;
            }
        }

        // Complex type
        if (type.IsAbstract || type.IsInterface)
            return null;

        if (depth >= MaxDepth || path.Contains(type))
            return null;

        object instance;
        try
        {
            instance = Activator.CreateInstance(type, nonPublic: true)!;
        }
        catch
        {
            return null;
        }

        path.Add(type);
        foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                     .Where(p => p.CanRead && p.CanWrite && p.GetIndexParameters().Length == 0))
        {
            var value = Build(property.PropertyType, depth + 1, path, counter);
            if (value != null)
                property.SetValue(instance, value);
        }
        path.Remove(type);

        return instance;
    }

    private static Guid DeterministicGuid(int n)
    {
        var bytes = new byte[16];
        bytes[0] = (byte)(n & 0xFF);
        bytes[1] = (byte)((n >> 8) & 0xFF);
        bytes[15] = (byte)(n & 0xFF);
        return new Guid(bytes);
    }
}
