using System;
using System.Reflection;
using System.Collections.Generic;

namespace TrainFit.Comparers
{
    public static class ComparerHelper
    {
        public static bool InstancePropertiesAreEqual<T>(T expectedProperties, T actualProperties, params string[] ignoredProperties) where T : class
        {
            if (expectedProperties != null && actualProperties != null)
            {
                Type type = typeof(T);
                List<string> ignoreList = new List<string>(ignoredProperties);
                foreach (PropertyInfo pi in type.GetTypeInfo().DeclaredProperties)
                {
                    if (!ignoreList.Contains(pi.Name))
                    {
                        object expectedValue = type.GetRuntimeProperty(pi.Name).GetValue(expectedProperties, null);
                        object actualValue = type.GetRuntimeProperty(pi.Name).GetValue(actualProperties, null);

                        if (expectedValue != actualValue && (expectedValue == null || !expectedValue.Equals(actualValue)))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            return expectedProperties == actualProperties;
        }

    }
}
