using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Amazon.DynamoDBv2.Model;
using Cuemon;

namespace WBPA.Amazon.DynamoDb
{
    /// <summary>
    /// Provides access to factory methods for creating <see cref="AttributeValue"/> instances.
    /// </summary>
    public static class AttributeValueFactory
    {
        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="value">The <see cref="byte"/> to use as the value of the element to add.</param>
        public static AttributeValue CreateNumber(byte value)
        {
            return CreateNumber(value.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="value">The <see cref="sbyte"/> to use as the value of the element to add.</param>
        public static AttributeValue CreateNumber(sbyte value)
        {
            return CreateNumber(value.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="value">The <see cref="short"/> to use as the value of the element to add.</param>
        public static AttributeValue CreateNumber(short value)
        {
            return CreateNumber(value.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="value">The <see cref="ushort"/> to use as the value of the element to add.</param>
        public static AttributeValue CreateNumber(ushort value)
        {
            return CreateNumber(value.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="value">The <see cref="int"/> to use as the value of the element to add.</param>
        public static AttributeValue CreateNumber(int value)
        {
            return CreateNumber(value.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="value">The <see cref="uint"/> to use as the value of the element to add.</param>
        public static AttributeValue CreateNumber(uint value)
        {
            return CreateNumber(value.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="value">The <see cref="long"/> to use as the value of the element to add.</param>
        public static AttributeValue CreateNumber(long value)
        {
            return CreateNumber(value.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="value">The <see cref="ulong"/> to use as the value of the element to add.</param>
        public static AttributeValue CreateNumber(ulong value)
        {
            return CreateNumber(value.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="value">The <see cref="float"/> to use as the value of the element to add.</param>
        public static AttributeValue CreateNumber(float value)
        {
            return CreateNumber(value.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="value">The <see cref="decimal"/> to use as the value of the element to add.</param>
        public static AttributeValue CreateNumber(decimal value)
        {
            return CreateNumber(value.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="value">The <see cref="double"/> to use as the value of the element to add.</param>
        public static AttributeValue CreateNumber(double value)
        {
            return CreateNumber(value.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="value">The <see cref="string"/> to use as the value of the element to add.</param>
        public static AttributeValue CreateString(string value)
        {
            return new AttributeValue()
            {
                S = value
            };
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="values">A sequence of <see cref="string"/> to use as the value of the element to add.</param>
        public static AttributeValue CreateStringSequence(IEnumerable<string> values)
        {
            Validator.ThrowIfNull(values, nameof(values));
            return new AttributeValue()
            {
                SS = values.ToList()
            };
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="value">The <see cref="Stream"/> to use as the value of the element to add.</param>
        public static AttributeValue CreateBinary(Stream value)
        {
            var attribute = new AttributeValue();
            var ms = new MemoryStream();
            value?.CopyTo(ms);
            attribute.B = ms;
            return attribute;
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="values">A sequence of <see cref="Stream"/> to use as the value of the element to add.</param>
        public static AttributeValue CreateBinarySequence(IEnumerable<Stream> values)
        {
            Validator.ThrowIfNull(values, nameof(values));
            var attribute = new AttributeValue();
            attribute.BS = values.Select(v =>
            {
                var ms = new MemoryStream();
                v?.CopyTo(ms);
                return ms;
            }).ToList();
            return attribute;
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="value">The <see cref="bool"/> to use as the value of the element to add.</param>
        public static AttributeValue CreateBoolean(bool value)
        {
            return new AttributeValue()
            {
                BOOL = value
            };
        }

        /// <summary>
        /// Adds an element with the provided key to the dictionary.
        /// </summary>
        public static AttributeValue CreateNull()
        {
            return new AttributeValue()
            {
                NULL = true
            };
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="values">A sequence of <see cref="byte"/> to use as the value of the element to add.</param>
        public static AttributeValue CreateNumberSequence(IEnumerable<byte> values)
        {
            Validator.ThrowIfNull(values, nameof(values));
            return CreateNumberSequence(values.Select(v => v.ToString(CultureInfo.InvariantCulture)));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="values">A sequence of <see cref="sbyte"/> to use as the value of the element to add.</param>
        public static AttributeValue CreateNumberSequence(IEnumerable<sbyte> values)
        {
            Validator.ThrowIfNull(values, nameof(values));
            return CreateNumberSequence(values.Select(v => v.ToString(CultureInfo.InvariantCulture)));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="values">A sequence of <see cref="short"/> to use as the value of the element to add.</param>
        public static AttributeValue CreateNumberSequence(IEnumerable<short> values)
        {
            Validator.ThrowIfNull(values, nameof(values));
            return CreateNumberSequence(values.Select(v => v.ToString(CultureInfo.InvariantCulture)));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="values">A sequence of <see cref="ushort"/> to use as the value of the element to add.</param>
        public static AttributeValue CreateNumberSequence(IEnumerable<ushort> values)
        {
            Validator.ThrowIfNull(values, nameof(values));
            return CreateNumberSequence(values.Select(v => v.ToString(CultureInfo.InvariantCulture)));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="values">A sequence of <see cref="int"/> to use as the value of the element to add.</param>
        public static AttributeValue CreateNumberSequence(IEnumerable<int> values)
        {
            Validator.ThrowIfNull(values, nameof(values));
            return CreateNumberSequence(values.Select(v => v.ToString(CultureInfo.InvariantCulture)));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="values">A sequence of <see cref="uint"/> to use as the value of the element to add.</param>
        public static AttributeValue CreateNumberSequence(IEnumerable<uint> values)
        {
            Validator.ThrowIfNull(values, nameof(values));
            return CreateNumberSequence(values.Select(v => v.ToString(CultureInfo.InvariantCulture)));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="values">A sequence of <see cref="long"/> to use as the value of the element to add.</param>
        public static AttributeValue CreateNumberSequence(IEnumerable<long> values)
        {
            Validator.ThrowIfNull(values, nameof(values));
            return CreateNumberSequence(values.Select(v => v.ToString(CultureInfo.InvariantCulture)));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="values">A sequence of <see cref="ulong"/> to use as the value of the element to add.</param>
        public static AttributeValue CreateNumberSequence(IEnumerable<ulong> values)
        {
            Validator.ThrowIfNull(values, nameof(values));
            return CreateNumberSequence(values.Select(v => v.ToString(CultureInfo.InvariantCulture)));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="values">A sequence of <see cref="float"/> to use as the value of the element to add.</param>
        public static AttributeValue CreateNumberSequence(IEnumerable<float> values)
        {
            Validator.ThrowIfNull(values, nameof(values));
            return CreateNumberSequence(values.Select(v => v.ToString(CultureInfo.InvariantCulture)));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="values">A sequence of <see cref="decimal"/> to use as the value of the element to add.</param>
        public static AttributeValue CreateNumberSequence(IEnumerable<decimal> values)
        {
            Validator.ThrowIfNull(values, nameof(values));
            return CreateNumberSequence(values.Select(v => v.ToString(CultureInfo.InvariantCulture)));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="values">A sequence of <see cref="double"/> to use as the value of the element to add.</param>
        public static AttributeValue CreateNumberSequence(IEnumerable<double> values)
        {
            Validator.ThrowIfNull(values, nameof(values));
            return CreateNumberSequence(values.Select(v => v.ToString(CultureInfo.InvariantCulture)));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="value">The <see cref="Dictionary{TKey,TValue}"/> to use as the value of the element to add.</param>
        public static AttributeValue CreateMap(Dictionary<string, AttributeValue> value)
        {
            Validator.ThrowIfNull(value, nameof(value));
            return new AttributeValue()
            {
                M = value
            };
        }

        private static AttributeValue CreateNumber(string value)
        {
            return new AttributeValue()
            {
                N = value
            };
        }

        private static AttributeValue CreateNumberSequence(IEnumerable<string> values)
        {
            return new AttributeValue()
            {
                NS = values.ToList()
            };
        }
    }
}