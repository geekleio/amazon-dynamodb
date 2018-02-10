using System.Collections.Generic;
using Amazon.DynamoDBv2.Model;
using Cuemon;
using WBPA.Amazon.Attributes;

namespace WBPA.Amazon.DynamoDb.Indexes
{
    /// <summary>
    /// Provides a base class for working with key-schema on AWS DynamoDB. This is an abstract class.
    /// </summary>
    public abstract class Index
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Index"/> class.
        /// </summary>
        internal Index()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Index"/> class.
        /// </summary>
        /// <param name="partitionKey">The partition key of a table or index.</param>
        protected Index(PartitionKey partitionKey)
        {
            Validator.ThrowIfNull(partitionKey, nameof(partitionKey));
            PartitionKey = partitionKey;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Index" /> class.
        /// </summary>
        /// <param name="partitionKeyName">The name of the partition key of a table or index.</param>
        /// <param name="partitionKeyType">The data type of the partition key of a table or index. Default value is <see cref="AttributeType.String"/>.</param>
        protected Index(string partitionKeyName, AttributeType partitionKeyType = AttributeType.String) : this(new PartitionKey(partitionKeyName, partitionKeyType))
        {
        }

        /// <summary>
        /// Gets or sets the partition key of a table or index.
        /// </summary>
        /// <value>The partition key of a table or index.</value>
        public PartitionKey PartitionKey { get; set; }

        /// <summary>
        /// Gets or sets the sort key of a table or index.
        /// </summary>
        /// <value>The sort key of a table or index.</value>
        public SortKey SortKey { get; set; }

        internal virtual List<AttributeDefinition> ToAttributeDefinitions()
        {
            var definitions = new List<AttributeDefinition>();
            definitions.Add(PartitionKey.ToAttributeDefinition());
            if (SortKey != null) { definitions.Add(SortKey.ToAttributeDefinition()); }
            return definitions;
        }

        internal List<KeySchemaElement> ToKeySchema()
        {
            var schema = new List<KeySchemaElement>();
            schema.Add(PartitionKey.ToKeySchemaElement());
            if (SortKey != null) { schema.Add(SortKey.ToKeySchemaElement()); }
            return schema;
        }
    }
}