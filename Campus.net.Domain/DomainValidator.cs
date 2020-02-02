using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.Domain
{
    internal static class DomainValidator
    {
        internal static void ValidateId(Guid id)
        {
            if (id.Equals(Guid.Empty)) throw new ArgumentNullException(nameof(id));
        }

        internal static void ValidateString(string str, int minLength, int maxLength)
        {
            if (string.IsNullOrEmpty(str)) throw new ArgumentNullException(nameof(str));
            if (str.Length < minLength || str.Length > maxLength) throw new ArgumentException($"'{str}' does not fit the required length");
        }

        internal static void ValidateObject<T>(T obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
        }

        internal static void ValidateNumber(int number, int minValue, int maxValue)
        {
            if (number < minValue || number > maxValue) throw new ArgumentException($"'{number}' does not fit the required gap");//omg
        }
    }
}
