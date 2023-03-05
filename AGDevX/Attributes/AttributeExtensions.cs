using System.ComponentModel;
using AGDevX.Exceptions;
using AGDevX.IEnumerables;

namespace AGDevX.Attributes
{
    public static class AttributeExtensions
    {
        public static string? GetDescription<T>(this T source, bool searchInheritanceChain = true)
        {
            if (source == null || source.ToString() == null)
            {
                throw new ExtensionMethodParameterNullException($"The provided { nameof(source) } argument was null");
            }

            var fieldInfo = source.GetType().GetField(source.ToString()!) 
                                ?? throw new ExtensionMethodException($"Unable to get Field Info");

            var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), searchInheritanceChain);

            if (descriptionAttributes.AnySafe())
            {
                return descriptionAttributes[0].Description;
            }
            else
            {
                return null;
            }
        }
    }
}