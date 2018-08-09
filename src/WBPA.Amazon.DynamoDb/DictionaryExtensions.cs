using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Amazon.DynamoDBv2.Model;
using Cuemon;
using Cuemon.Collections.Generic;

namespace WBPA.Amazon.DynamoDb
{
    /// <summary>
    /// Extension methods for the <see cref="Dictionary{TKey,TValue}"/>.
    /// </summary>
    public static class DictionaryExtensions
    {
        public static string GetString(this IDictionary<string, AttributeValue> dic, string key)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            return dic.GetValueOrDefault(key)?.S;
        }

        public static T GetNumber<T>(this IDictionary<string, AttributeValue> dic, string key) where T : IConvertible
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            var valueOrDefault = dic.GetValueOrDefault(key);
            return valueOrDefault == null ? default(T) : valueOrDefault.N.As<T>();
        }

        public static Stream GetBinary(this IDictionary<string, AttributeValue> dic, string key)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            return dic.GetValueOrDefault(key)?.B;
        }

        public static IEnumerable<string> GetStringSequence(this IDictionary<string, AttributeValue> dic, string key)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            return dic.GetValueOrDefault(key)?.SS;
        }

        public static IEnumerable<T> GetNumberSequence<T>(this IDictionary<string, AttributeValue> dic, string key) where T : IConvertible
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            var valueOrDefault = dic.GetValueOrDefault(key);
            return valueOrDefault?.NS.Select(s => s.As<T>()) ?? Enumerable.Empty<T>();
        }

        public static IEnumerable<Stream> GetBinarySequence(this IDictionary<string, AttributeValue> dic, string key)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            return dic.GetValueOrDefault(key)?.BS;
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="string"/> to use as the key of the element to add.</param>
        /// <param name="value">The <see cref="byte"/> to use as the value of the element to add.</param>
        public static void AddNumber(this IDictionary<string, AttributeValue> dic, string key, byte value)
        {
            dic.Add(key, AttributeValueFactory.CreateNumber(value));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="string"/> to use as the key of the element to add.</param>
        /// <param name="value">The <see cref="sbyte"/> to use as the value of the element to add.</param>
        public static void AddNumber(this IDictionary<string, AttributeValue> dic, string key, sbyte value)
        {
            dic.Add(key, AttributeValueFactory.CreateNumber(value));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="string"/> to use as the key of the element to add.</param>
        /// <param name="value">The <see cref="short"/> to use as the value of the element to add.</param>
        public static void AddNumber(this IDictionary<string, AttributeValue> dic, string key, short value)
        {
            dic.Add(key, AttributeValueFactory.CreateNumber(value));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="string"/> to use as the key of the element to add.</param>
        /// <param name="value">The <see cref="ushort"/> to use as the value of the element to add.</param>
        public static void AddNumber(this IDictionary<string, AttributeValue> dic, string key, ushort value)
        {
            dic.Add(key, AttributeValueFactory.CreateNumber(value));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="string"/> to use as the key of the element to add.</param>
        /// <param name="value">The <see cref="int"/> to use as the value of the element to add.</param>
        public static void AddNumber(this IDictionary<string, AttributeValue> dic, string key, int value)
        {
            dic.Add(key, AttributeValueFactory.CreateNumber(value));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="string"/> to use as the key of the element to add.</param>
        /// <param name="value">The <see cref="uint"/> to use as the value of the element to add.</param>
        public static void AddNumber(this IDictionary<string, AttributeValue> dic, string key, uint value)
        {
            dic.Add(key, AttributeValueFactory.CreateNumber(value));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="string"/> to use as the key of the element to add.</param>
        /// <param name="value">The <see cref="long"/> to use as the value of the element to add.</param>
        public static void AddNumber(this IDictionary<string, AttributeValue> dic, string key, long value)
        {
            dic.Add(key, AttributeValueFactory.CreateNumber(value));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="string"/> to use as the key of the element to add.</param>
        /// <param name="value">The <see cref="ulong"/> to use as the value of the element to add.</param>
        public static void AddNumber(this IDictionary<string, AttributeValue> dic, string key, ulong value)
        {
            dic.Add(key, AttributeValueFactory.CreateNumber(value));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="string"/> to use as the key of the element to add.</param>
        /// <param name="value">The <see cref="float"/> to use as the value of the element to add.</param>
        public static void AddNumber(this IDictionary<string, AttributeValue> dic, string key, float value)
        {
            dic.Add(key, AttributeValueFactory.CreateNumber(value));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="string"/> to use as the key of the element to add.</param>
        /// <param name="value">The <see cref="decimal"/> to use as the value of the element to add.</param>
        public static void AddNumber(this IDictionary<string, AttributeValue> dic, string key, decimal value)
        {
            dic.Add(key, AttributeValueFactory.CreateNumber(value));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="string"/> to use as the key of the element to add.</param>
        /// <param name="value">The <see cref="double"/> to use as the value of the element to add.</param>
        public static void AddNumber(this IDictionary<string, AttributeValue> dic, string key, double value)
        {
            dic.Add(key, AttributeValueFactory.CreateNumber(value));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="string"/> to use as the key of the element to add.</param>
        /// <param name="value">The <see cref="string"/> to use as the value of the element to add.</param>
        public static void AddString(this IDictionary<string, AttributeValue> dic, string key, string value)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            Validator.ThrowIfNullOrWhitespace(key, nameof(key));
            dic.Add(key, AttributeValueFactory.CreateString(value));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="string"/> to use as the key of the element to add.</param>
        /// <param name="values">A sequence of <see cref="string"/> to use as the value of the element to add.</param>
        public static void AddStringSequence(this IDictionary<string, AttributeValue> dic, string key, IEnumerable<string> values)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            Validator.ThrowIfNullOrWhitespace(key, nameof(key));
            Validator.ThrowIfNull(values, nameof(values));
            dic.Add(key, AttributeValueFactory.CreateStringSequence(values));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="string"/> to use as the key of the element to add.</param>
        /// <param name="value">The <see cref="Stream"/> to use as the value of the element to add.</param>
        public static void AddBinary(this IDictionary<string, AttributeValue> dic, string key, Stream value)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            Validator.ThrowIfNullOrWhitespace(key, nameof(key));
            dic.Add(key, AttributeValueFactory.CreateBinary(value));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="string"/> to use as the key of the element to add.</param>
        /// <param name="values">A sequence of <see cref="Stream"/> to use as the value of the element to add.</param>
        public static void AddBinarySequence(this IDictionary<string, AttributeValue> dic, string key, IEnumerable<Stream> values)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            Validator.ThrowIfNullOrWhitespace(key, nameof(key));
            Validator.ThrowIfNull(values, nameof(values));
            dic.Add(key, AttributeValueFactory.CreateBinarySequence(values));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="string"/> to use as the key of the element to add.</param>
        /// <param name="value">The <see cref="bool"/> to use as the value of the element to add.</param>
        public static void AddBoolean(this IDictionary<string, AttributeValue> dic, string key, bool value)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            Validator.ThrowIfNullOrWhitespace(key, nameof(key));
            dic.Add(key, AttributeValueFactory.CreateBoolean(value));
        }

        /// <summary>
        /// Adds an element with the provided key to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="string"/> to use as the key of the element to add.</param>
        public static void AddNull(this IDictionary<string, AttributeValue> dic, string key)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            Validator.ThrowIfNullOrWhitespace(key, nameof(key));
            dic.Add(key, AttributeValueFactory.CreateNull());
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="string"/> to use as the key of the element to add.</param>
        /// <param name="values">A sequence of <see cref="byte"/> to use as the value of the element to add.</param>
        public static void AddNumberSequence(this IDictionary<string, AttributeValue> dic, string key, IEnumerable<byte> values)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            Validator.ThrowIfNullOrWhitespace(key, nameof(key));
            Validator.ThrowIfNull(values, nameof(values));
            dic.Add(key, AttributeValueFactory.CreateNumberSequence(values));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="string"/> to use as the key of the element to add.</param>
        /// <param name="values">A sequence of <see cref="sbyte"/> to use as the value of the element to add.</param>
        public static void AddNumberSequence(this IDictionary<string, AttributeValue> dic, string key, IEnumerable<sbyte> values)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            Validator.ThrowIfNullOrWhitespace(key, nameof(key));
            Validator.ThrowIfNull(values, nameof(values));
            dic.Add(key, AttributeValueFactory.CreateNumberSequence(values));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="string"/> to use as the key of the element to add.</param>
        /// <param name="values">A sequence of <see cref="short"/> to use as the value of the element to add.</param>
        public static void AddNumberSequence(this IDictionary<string, AttributeValue> dic, string key, IEnumerable<short> values)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            Validator.ThrowIfNullOrWhitespace(key, nameof(key));
            Validator.ThrowIfNull(values, nameof(values));
            dic.Add(key, AttributeValueFactory.CreateNumberSequence(values));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="string"/> to use as the key of the element to add.</param>
        /// <param name="values">A sequence of <see cref="ushort"/> to use as the value of the element to add.</param>
        public static void AddNumberSequence(this IDictionary<string, AttributeValue> dic, string key, IEnumerable<ushort> values)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            Validator.ThrowIfNullOrWhitespace(key, nameof(key));
            Validator.ThrowIfNull(values, nameof(values));
            dic.Add(key, AttributeValueFactory.CreateNumberSequence(values));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="string"/> to use as the key of the element to add.</param>
        /// <param name="values">A sequence of <see cref="int"/> to use as the value of the element to add.</param>
        public static void AddNumberSequence(this IDictionary<string, AttributeValue> dic, string key, IEnumerable<int> values)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            Validator.ThrowIfNullOrWhitespace(key, nameof(key));
            Validator.ThrowIfNull(values, nameof(values));
            dic.Add(key, AttributeValueFactory.CreateNumberSequence(values));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="string"/> to use as the key of the element to add.</param>
        /// <param name="values">A sequence of <see cref="uint"/> to use as the value of the element to add.</param>
        public static void AddNumberSequence(this IDictionary<string, AttributeValue> dic, string key, IEnumerable<uint> values)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            Validator.ThrowIfNullOrWhitespace(key, nameof(key));
            Validator.ThrowIfNull(values, nameof(values));
            dic.Add(key, AttributeValueFactory.CreateNumberSequence(values));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="string"/> to use as the key of the element to add.</param>
        /// <param name="values">A sequence of <see cref="long"/> to use as the value of the element to add.</param>
        public static void AddNumberSequence(this IDictionary<string, AttributeValue> dic, string key, IEnumerable<long> values)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            Validator.ThrowIfNullOrWhitespace(key, nameof(key));
            Validator.ThrowIfNull(values, nameof(values));
            dic.Add(key, AttributeValueFactory.CreateNumberSequence(values));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="string"/> to use as the key of the element to add.</param>
        /// <param name="values">A sequence of <see cref="ulong"/> to use as the value of the element to add.</param>
        public static void AddNumberSequence(this IDictionary<string, AttributeValue> dic, string key, IEnumerable<ulong> values)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            Validator.ThrowIfNullOrWhitespace(key, nameof(key));
            Validator.ThrowIfNull(values, nameof(values));
            dic.Add(key, AttributeValueFactory.CreateNumberSequence(values));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="string"/> to use as the key of the element to add.</param>
        /// <param name="values">A sequence of <see cref="float"/> to use as the value of the element to add.</param>
        public static void AddNumberSequence(this IDictionary<string, AttributeValue> dic, string key, IEnumerable<float> values)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            Validator.ThrowIfNullOrWhitespace(key, nameof(key));
            Validator.ThrowIfNull(values, nameof(values));
            dic.Add(key, AttributeValueFactory.CreateNumberSequence(values));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="string"/> to use as the key of the element to add.</param>
        /// <param name="values">A sequence of <see cref="decimal"/> to use as the value of the element to add.</param>
        public static void AddNumberSequence(this IDictionary<string, AttributeValue> dic, string key, IEnumerable<decimal> values)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            Validator.ThrowIfNullOrWhitespace(key, nameof(key));
            Validator.ThrowIfNull(values, nameof(values));
            dic.Add(key, AttributeValueFactory.CreateNumberSequence(values));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="string"/> to use as the key of the element to add.</param>
        /// <param name="values">A sequence of <see cref="double"/> to use as the value of the element to add.</param>
        public static void AddNumberSequence(this IDictionary<string, AttributeValue> dic, string key, IEnumerable<double> values)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            Validator.ThrowIfNullOrWhitespace(key, nameof(key));
            Validator.ThrowIfNull(values, nameof(values));
            dic.Add(key, AttributeValueFactory.CreateNumberSequence(values));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="string"/> to use as the key of the element to add.</param>
        /// <param name="value">The <see cref="Dictionary{TKey,TValue}"/> to use as the value of the element to add.</param>
        public static void AddMap(this IDictionary<string, AttributeValue> dic, string key, Dictionary<string, AttributeValue> value)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            Validator.ThrowIfNullOrWhitespace(key, nameof(key));
            Validator.ThrowIfNull(value, nameof(value));
            dic.Add(key, AttributeValueFactory.CreateMap(value));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="AttributeName"/> to use as the key of the element to add.</param>
        /// <param name="value">The <see cref="byte"/> to use as the value of the element to add.</param>
        public static void AddNumber(this IDictionary<AttributeName, AttributeValue> dic, string key, byte value)
        {
            dic.Add(key, AttributeValueFactory.CreateNumber(value));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="AttributeName"/> to use as the key of the element to add.</param>
        /// <param name="value">The <see cref="sbyte"/> to use as the value of the element to add.</param>
        public static void AddNumber(this IDictionary<AttributeName, AttributeValue> dic, string key, sbyte value)
        {
            dic.Add(key, AttributeValueFactory.CreateNumber(value));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="AttributeName"/> to use as the key of the element to add.</param>
        /// <param name="value">The <see cref="short"/> to use as the value of the element to add.</param>
        public static void AddNumber(this IDictionary<AttributeName, AttributeValue> dic, string key, short value)
        {
            dic.Add(key, AttributeValueFactory.CreateNumber(value));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="AttributeName"/> to use as the key of the element to add.</param>
        /// <param name="value">The <see cref="ushort"/> to use as the value of the element to add.</param>
        public static void AddNumber(this IDictionary<AttributeName, AttributeValue> dic, string key, ushort value)
        {
            dic.Add(key, AttributeValueFactory.CreateNumber(value));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="AttributeName"/> to use as the key of the element to add.</param>
        /// <param name="value">The <see cref="int"/> to use as the value of the element to add.</param>
        public static void AddNumber(this IDictionary<AttributeName, AttributeValue> dic, string key, int value)
        {
            dic.Add(key, AttributeValueFactory.CreateNumber(value));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="AttributeName"/> to use as the key of the element to add.</param>
        /// <param name="value">The <see cref="uint"/> to use as the value of the element to add.</param>
        public static void AddNumber(this IDictionary<AttributeName, AttributeValue> dic, string key, uint value)
        {
            dic.Add(key, AttributeValueFactory.CreateNumber(value));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="AttributeName"/> to use as the key of the element to add.</param>
        /// <param name="value">The <see cref="long"/> to use as the value of the element to add.</param>
        public static void AddNumber(this IDictionary<AttributeName, AttributeValue> dic, string key, long value)
        {
            dic.Add(key, AttributeValueFactory.CreateNumber(value));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="AttributeName"/> to use as the key of the element to add.</param>
        /// <param name="value">The <see cref="ulong"/> to use as the value of the element to add.</param>
        public static void AddNumber(this IDictionary<AttributeName, AttributeValue> dic, string key, ulong value)
        {
            dic.Add(key, AttributeValueFactory.CreateNumber(value));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="AttributeName"/> to use as the key of the element to add.</param>
        /// <param name="value">The <see cref="float"/> to use as the value of the element to add.</param>
        public static void AddNumber(this IDictionary<AttributeName, AttributeValue> dic, string key, float value)
        {
            dic.Add(key, AttributeValueFactory.CreateNumber(value));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="AttributeName"/> to use as the key of the element to add.</param>
        /// <param name="value">The <see cref="decimal"/> to use as the value of the element to add.</param>
        public static void AddNumber(this IDictionary<AttributeName, AttributeValue> dic, string key, decimal value)
        {
            dic.Add(key, AttributeValueFactory.CreateNumber(value));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="AttributeName"/> to use as the key of the element to add.</param>
        /// <param name="value">The <see cref="double"/> to use as the value of the element to add.</param>
        public static void AddNumber(this IDictionary<AttributeName, AttributeValue> dic, string key, double value)
        {
            dic.Add(key, AttributeValueFactory.CreateNumber(value));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="AttributeName"/> to use as the key of the element to add.</param>
        /// <param name="value">The <see cref="string"/> to use as the value of the element to add.</param>
        public static void AddString(this IDictionary<AttributeName, AttributeValue> dic, string key, string value)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            Validator.ThrowIfNullOrWhitespace(key, nameof(key));
            dic.Add(key, AttributeValueFactory.CreateString(value));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="AttributeName"/> to use as the key of the element to add.</param>
        /// <param name="values">A sequence of <see cref="string"/> to use as the value of the element to add.</param>
        public static void AddStringSequence(this IDictionary<AttributeName, AttributeValue> dic, string key, IEnumerable<string> values)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            Validator.ThrowIfNullOrWhitespace(key, nameof(key));
            Validator.ThrowIfNull(values, nameof(values));
            dic.Add(key, AttributeValueFactory.CreateStringSequence(values));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="AttributeName"/> to use as the key of the element to add.</param>
        /// <param name="value">The <see cref="Stream"/> to use as the value of the element to add.</param>
        public static void AddBinary(this IDictionary<AttributeName, AttributeValue> dic, string key, Stream value)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            Validator.ThrowIfNullOrWhitespace(key, nameof(key));
            dic.Add(key, AttributeValueFactory.CreateBinary(value));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="AttributeName"/> to use as the key of the element to add.</param>
        /// <param name="values">A sequence of <see cref="Stream"/> to use as the value of the element to add.</param>
        public static void AddBinarySequence(this IDictionary<AttributeName, AttributeValue> dic, string key, IEnumerable<Stream> values)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            Validator.ThrowIfNullOrWhitespace(key, nameof(key));
            Validator.ThrowIfNull(values, nameof(values));
            dic.Add(key, AttributeValueFactory.CreateBinarySequence(values));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="AttributeName"/> to use as the key of the element to add.</param>
        /// <param name="value">The <see cref="bool"/> to use as the value of the element to add.</param>
        public static void AddBoolean(this IDictionary<AttributeName, AttributeValue> dic, string key, bool value)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            Validator.ThrowIfNullOrWhitespace(key, nameof(key));
            dic.Add(key, AttributeValueFactory.CreateBoolean(value));
        }

        /// <summary>
        /// Adds an element with the provided key to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="AttributeName"/> to use as the key of the element to add.</param>
        public static void AddNull(this IDictionary<AttributeName, AttributeValue> dic, string key)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            Validator.ThrowIfNullOrWhitespace(key, nameof(key));
            dic.Add(key, AttributeValueFactory.CreateNull());
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="AttributeName"/> to use as the key of the element to add.</param>
        /// <param name="values">A sequence of <see cref="byte"/> to use as the value of the element to add.</param>
        public static void AddNumberSequence(this IDictionary<AttributeName, AttributeValue> dic, string key, IEnumerable<byte> values)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            Validator.ThrowIfNullOrWhitespace(key, nameof(key));
            Validator.ThrowIfNull(values, nameof(values));
            dic.Add(key, AttributeValueFactory.CreateNumberSequence(values));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="AttributeName"/> to use as the key of the element to add.</param>
        /// <param name="values">A sequence of <see cref="sbyte"/> to use as the value of the element to add.</param>
        public static void AddNumberSequence(this IDictionary<AttributeName, AttributeValue> dic, string key, IEnumerable<sbyte> values)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            Validator.ThrowIfNullOrWhitespace(key, nameof(key));
            Validator.ThrowIfNull(values, nameof(values));
            dic.Add(key, AttributeValueFactory.CreateNumberSequence(values));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="AttributeName"/> to use as the key of the element to add.</param>
        /// <param name="values">A sequence of <see cref="short"/> to use as the value of the element to add.</param>
        public static void AddNumberSequence(this IDictionary<AttributeName, AttributeValue> dic, string key, IEnumerable<short> values)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            Validator.ThrowIfNullOrWhitespace(key, nameof(key));
            Validator.ThrowIfNull(values, nameof(values));
            dic.Add(key, AttributeValueFactory.CreateNumberSequence(values));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="AttributeName"/> to use as the key of the element to add.</param>
        /// <param name="values">A sequence of <see cref="ushort"/> to use as the value of the element to add.</param>
        public static void AddNumberSequence(this IDictionary<AttributeName, AttributeValue> dic, string key, IEnumerable<ushort> values)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            Validator.ThrowIfNullOrWhitespace(key, nameof(key));
            Validator.ThrowIfNull(values, nameof(values));
            dic.Add(key, AttributeValueFactory.CreateNumberSequence(values));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="AttributeName"/> to use as the key of the element to add.</param>
        /// <param name="values">A sequence of <see cref="int"/> to use as the value of the element to add.</param>
        public static void AddNumberSequence(this IDictionary<AttributeName, AttributeValue> dic, string key, IEnumerable<int> values)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            Validator.ThrowIfNullOrWhitespace(key, nameof(key));
            Validator.ThrowIfNull(values, nameof(values));
            dic.Add(key, AttributeValueFactory.CreateNumberSequence(values));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="AttributeName"/> to use as the key of the element to add.</param>
        /// <param name="values">A sequence of <see cref="uint"/> to use as the value of the element to add.</param>
        public static void AddNumberSequence(this IDictionary<AttributeName, AttributeValue> dic, string key, IEnumerable<uint> values)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            Validator.ThrowIfNullOrWhitespace(key, nameof(key));
            Validator.ThrowIfNull(values, nameof(values));
            dic.Add(key, AttributeValueFactory.CreateNumberSequence(values));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="AttributeName"/> to use as the key of the element to add.</param>
        /// <param name="values">A sequence of <see cref="long"/> to use as the value of the element to add.</param>
        public static void AddNumberSequence(this IDictionary<AttributeName, AttributeValue> dic, string key, IEnumerable<long> values)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            Validator.ThrowIfNullOrWhitespace(key, nameof(key));
            Validator.ThrowIfNull(values, nameof(values));
            dic.Add(key, AttributeValueFactory.CreateNumberSequence(values));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="AttributeName"/> to use as the key of the element to add.</param>
        /// <param name="values">A sequence of <see cref="ulong"/> to use as the value of the element to add.</param>
        public static void AddNumberSequence(this IDictionary<AttributeName, AttributeValue> dic, string key, IEnumerable<ulong> values)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            Validator.ThrowIfNullOrWhitespace(key, nameof(key));
            Validator.ThrowIfNull(values, nameof(values));
            dic.Add(key, AttributeValueFactory.CreateNumberSequence(values));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="AttributeName"/> to use as the key of the element to add.</param>
        /// <param name="values">A sequence of <see cref="float"/> to use as the value of the element to add.</param>
        public static void AddNumberSequence(this IDictionary<AttributeName, AttributeValue> dic, string key, IEnumerable<float> values)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            Validator.ThrowIfNullOrWhitespace(key, nameof(key));
            Validator.ThrowIfNull(values, nameof(values));
            dic.Add(key, AttributeValueFactory.CreateNumberSequence(values));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="AttributeName"/> to use as the key of the element to add.</param>
        /// <param name="values">A sequence of <see cref="decimal"/> to use as the value of the element to add.</param>
        public static void AddNumberSequence(this IDictionary<AttributeName, AttributeValue> dic, string key, IEnumerable<decimal> values)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            Validator.ThrowIfNullOrWhitespace(key, nameof(key));
            Validator.ThrowIfNull(values, nameof(values));
            dic.Add(key, AttributeValueFactory.CreateNumberSequence(values));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="AttributeName"/> to use as the key of the element to add.</param>
        /// <param name="values">A sequence of <see cref="double"/> to use as the value of the element to add.</param>
        public static void AddNumberSequence(this IDictionary<AttributeName, AttributeValue> dic, string key, IEnumerable<double> values)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            Validator.ThrowIfNullOrWhitespace(key, nameof(key));
            Validator.ThrowIfNull(values, nameof(values));
            dic.Add(key, AttributeValueFactory.CreateNumberSequence(values));
        }

        /// <summary>
        /// Adds an element with the provided key and value to the dictionary.
        /// </summary>
        /// <param name="dic">The dictionary to extend.</param>
        /// <param name="key">The <see cref="AttributeName"/> to use as the key of the element to add.</param>
        /// <param name="value">The <see cref="Dictionary{TKey,TValue}"/> to use as the value of the element to add.</param>
        public static void AddMap(this IDictionary<AttributeName, AttributeValue> dic, string key, Dictionary<string, AttributeValue> value)
        {
            Validator.ThrowIfNull(dic, nameof(dic));
            Validator.ThrowIfNullOrWhitespace(key, nameof(key));
            Validator.ThrowIfNull(value, nameof(value));
            dic.Add(key, AttributeValueFactory.CreateMap(value));
        }
    }
}