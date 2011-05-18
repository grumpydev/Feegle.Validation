namespace Feegle.Validation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class ReflectionExtensions
    {
        internal const string UnknownNameValue = "Unknown";

        public static string GetParameterName<T>(this Func<T> propertyDelegate)
        {
            if (propertyDelegate == null)
            {
                throw new ArgumentNullException("propertyDelegate");
            }

            if (propertyDelegate.Method == null)
            {
                return UnknownNameValue;
            }

            var methodBody = propertyDelegate.Method.GetMethodBody();
            if (methodBody == null)
            {
                return UnknownNameValue;
            }

            var il = methodBody.GetILAsByteArray();
            var fieldHandle = BitConverter.ToInt32(il, 2);

            var target = propertyDelegate.Target;
            if (target == null)
            {
                return UnknownNameValue;
            }

            var field = target.GetType().Module.ResolveField(fieldHandle);
            if (field == null)
            {
                return UnknownNameValue;
            }

            return field.Name ?? UnknownNameValue;
        }

        public static IEnumerable<string> GetPropertyNames<T>(this IEnumerable<IValidationPair<T>> validationPairs)
        {
            return validationPairs.Select(p => p.PropertyDelegate.GetParameterName())
                                  .Where(s => s != UnknownNameValue).ToArray();
        }
    }
}