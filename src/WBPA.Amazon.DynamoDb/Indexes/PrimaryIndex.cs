using System;
using System.Collections.Generic;
using Amazon.DynamoDBv2.Model;
using Cuemon;
using WBPA.Amazon.Attributes;

namespace WBPA.Amazon.DynamoDb.Indexes
{
    /// <summary>
    /// Represents the primary key for a table. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="Index" />
    public sealed class PrimaryIndex : Index
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrimaryIndex"/> class.
        /// </summary>
        /// <param name="partitionKey">The partition key of the table.</param>
        /// <param name="setup">The <see cref="PrimaryIndexOptions" /> which need to be configured.</param>
        public PrimaryIndex(PartitionKey partitionKey, Action<PrimaryIndexOptions> setup = null) : base(partitionKey)
        {
            var options = setup.ConfigureOptions();
            SortKey = options.SortKey;
            LocalSecondaryIndexes = options.LocalSecondaryIndexes;
            foreach (var lsi in LocalSecondaryIndexes) { lsi.PartitionKey = partitionKey; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PrimaryIndex"/> class.
        /// </summary>
        /// <param name="partitionKeyName">The name of the partition key of the table.</param>
        /// <param name="setup">The <see cref="PrimaryIndexOptions" /> which need to be configured.</param>
        public PrimaryIndex(string partitionKeyName, Action<PrimaryIndexOptions> setup = null) : this(partitionKeyName, AttributeType.String, setup)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PrimaryIndex"/> class.
        /// </summary>
        /// <param name="partitionKeyName">The name of the partition key of the table.</param>
        /// <param name="partitionKeyType">The data type of the partition key of the table. Default is <see cref="AttributeType.String"/>.</param>
        /// <param name="setup">The <see cref="PrimaryIndexOptions" /> which need to be configured.</param>
        public PrimaryIndex(string partitionKeyName, AttributeType partitionKeyType, Action<PrimaryIndexOptions> setup = null) : this(new PartitionKey(partitionKeyName, partitionKeyType), setup)
        {
        }

        /// <summary>
        /// Gets the local secondary indexes of the table.
        /// </summary>
        /// <value>The local secondary indexes of the table.</value>
        public SecondaryIndexCollection<SecondaryIndex> LocalSecondaryIndexes { get; }

        internal override List<AttributeDefinition> ToAttributeDefinitions()
        {
            var definitions = base.ToAttributeDefinitions();
            foreach (var lsi in LocalSecondaryIndexes) { definitions.Add(lsi.SortKey.ToAttributeDefinition()); }
            return definitions;
        }
    }
}