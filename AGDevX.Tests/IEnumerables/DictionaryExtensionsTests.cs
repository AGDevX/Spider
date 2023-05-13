using System.Collections.Generic;
using System.Linq;
using AGDevX.Exceptions;
using AGDevX.IEnumerables;
using Xunit;

namespace AGDevX.Tests.IEnumerables;

public class DictionaryExtensionsTests
{
    public class When_calling_ReverseKeysAndValues
    {
        [Fact]
        public void And_the_dictionary_has_at_least_one_record_then_return_the_reversed_dictionary()
        {
            //-- Arrange
            var dictionary = new Dictionary<string, object>
        {
            { "Dave", "Lister" },
            { "Arnold", "Rimmer" },
            { "Cat", "Kryten" }
        };

            //-- Act
            var reversedDictionary = dictionary.ReverseKeysAndValues();

            //-- Assert
            Assert.Equal(dictionary.Select(d => d.Key), reversedDictionary.Select(d => d.Value));
            Assert.Equal(dictionary.Select(d => d.Value), reversedDictionary.Select(d => d.Key));
        }

        [Fact]
        public void And_the_dictionary_is_null_then_return_the_reversed_dictionary()
        {
            //-- Arrange
            Dictionary<string, string>? dictionary = null;

            //-- Act && Assert
            Assert.Throws<ExtensionMethodParameterNullException>(() => dictionary.ReverseKeysAndValues());
        }
    }

    public class When_calling_Concatenate
    {
        [Fact]
        public void And_dict1_has_at_least_one_record_and_dict2_has_at_least_1_value_then_return_concatenated_dictionary()
        {
            //-- Arrange
            var dictionary1 = new Dictionary<string, object>
        {
            { "Dave", "Lister" },
            { "Arnold", "Rimmer" }
        };

            var dictionary2 = new Dictionary<string, object>
        {
            { "Cat", "Kryten" }
        };

            //-- Act
            var concatenatedDictionary = dictionary1.Concatenate(dictionary2);

            //-- Assert
            var dictionary1Keys = dictionary1.Select(d => d.Key).ToList();
            var dictionary2Keys = dictionary2.Select(d => d.Key).ToList();
            var dictionary1And2Keys = dictionary1Keys.Concat(dictionary2Keys).ToList();

            var dictionary1Values = dictionary1.Select(d => d.Value).ToList();
            var dictionary2Values = dictionary2.Select(d => d.Value).ToList();
            var dictionary1And2Values = dictionary1Values.Concat(dictionary2Values).ToList();


            Assert.Equal(dictionary1And2Keys, concatenatedDictionary.Select(d => d.Key).ToList());
            Assert.Equal(dictionary1And2Values, concatenatedDictionary.Select(d => d.Value).ToList());
        }

        [Fact]
        public void And_dict1_is_null_and_dict2_has_at_least_1_value_then_throw_ExtensionMethodParameterNullException()
        {
            //-- Arrange
            Dictionary<string, object>? dictionary1 = null;

            var dictionary2 = new Dictionary<string, object>
        {
            { "Cat", "Kryten" }
        };

            //-- Act && Assert
            Assert.Throws<ExtensionMethodParameterNullException>(() => dictionary1.Concatenate(dictionary2));
        }

        [Fact]
        public void And_dict1_has_at_least_one_record_and_dict2_is_null_then_return_concatenated_dictionary()
        {
            //-- Arrange
            var dictionary1 = new Dictionary<string, object>
        {
            { "Dave", "Lister" },
            { "Arnold", "Rimmer" }
        };

            Dictionary<string, object>? dictionary2 = null;

            //-- Act && Assert
            Assert.Throws<ExtensionMethodParameterNullException>(() => dictionary1.Concatenate(dictionary2));
        }
    }
}