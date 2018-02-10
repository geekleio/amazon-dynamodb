using System;
using System.Collections.Generic;
using Amazon.DynamoDBv2.Model;
using Cuemon;

namespace WBPA.Amazon.DynamoDb.Indexes
{
    /// <summary>
    /// Represents the primary key of a table item.
    /// </summary>
    public class PrimaryKey
    {
        private readonly Dictionary<string, AttributeValue> _attributeValues;

        /// <summary>
        /// Initializes a new instance of the <see cref="PrimaryKey"/> class.
        /// </summary>
        /// <param name="setup">The <see cref="Dictionary{String,AttributeValue}" /> which need to be configured.</param>
        /// <exception cref="ArgumentException">
        /// You must specify a partition key and optionally a sort key.
        /// - or -
        /// You can only specify a partition key and a sort key.
        /// </exception>
        public PrimaryKey(Action<Dictionary<string, AttributeValue>> setup)
        {
            var options = setup.ConfigureOptions();
            if (options.Count == 0) { throw new ArgumentException("You must specify a partition key and optionally a sort key."); }
            if (options.Count > 2) { throw new ArgumentException("You can only specify a partition key and a sort key.");}
            _attributeValues = options;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PrimaryKey"/> class.
        /// </summary>
        /// <param name="partitionKey">The partition key.</param>
        /// <param name="partitionKeyValue">The partition key value.</param>
        /// <param name="sortKey">The sort key.</param>
        /// <param name="sortKeyValue">The sort key value.</param>
        public PrimaryKey(string partitionKey, AttributeValue partitionKeyValue, string sortKey = null, AttributeValue sortKeyValue = null)
        {
            Validator.ThrowIfNullOrWhitespace(partitionKey, nameof(partitionKey));
            Validator.ThrowIfNull(partitionKeyValue, nameof(partitionKeyValue));
            _attributeValues = new Dictionary<string, AttributeValue>
            {
                { partitionKey, partitionKeyValue }
            };
            if (!sortKey.IsNullOrWhiteSpace() && sortKeyValue != null) { _attributeValues.Add(sortKey, sortKeyValue); }
        }

        /// <summary>
        /// Gets a value indicating whether this is a composite primary key.
        /// </summary>
        /// <value><c>true</c> if this is a composite primary key; otherwise, <c>false</c>.</value>
        public bool IsComposite => _attributeValues.Count == 2;

        internal Dictionary<string, AttributeValue> ToAttributeValues()
        {
            return _attributeValues;
        }
    }
}