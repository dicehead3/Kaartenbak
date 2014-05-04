using System.Collections.Generic;
using Utilities.Exceptions;

namespace Utilities.ExtensionMethods
{
    public static class GenericExtensions
    {
        public static T Unique<T>(this T input, ICollection<T> collection)
        {
            const string exceptionMessage = "'{0} already exists in collection";
            if (collection.Contains(input))
            {
                throw new Baka(string.Format(exceptionMessage, input));
            }
            return input;
        }

        public static T Required<T>(this T input) where T : class
        {
            if (input == null)
            {
                throw new Baka(typeof(T).Name + "is required.");
            }
            return input;
        }
    }
}
