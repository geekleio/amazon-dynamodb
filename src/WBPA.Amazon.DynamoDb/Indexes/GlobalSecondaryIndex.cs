using System;
using Amazon.DynamoDBv2.Model;
using Cuemon;
using WBPA.Amazon.Attributes;

namespace WBPA.Amazon.DynamoDb.Indexes
{
    /// <summary>
    /// Represents a secondary global index for a table. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="SecondaryIndex" />
    public sealed class GlobalSecondaryIndex : SecondaryIndex
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalSecondaryIndex"/> class.
        /// </summary>
        /// <param name="indexName">The name of the secondary global index.</param>
        /// <param name="partitionKey">The partition key of a table or index.</param>
        /// <param name="setup">The <see cref="GlobalSecondaryIndexOptions" /> which need to be configured.</param>
        public GlobalSecondaryIndex(string indexName, PartitionKey partitionKey, Action<GlobalSecondaryIndexOptions> setup = null) : base(indexName, partitionKey)
        {
            DynamoValidator.ThrowIfIndexNameIsNotValid(indexName);
            var options = setup.ConfigureOptions();
            SortKey = options.SortKey;
            Projection = options.Projection;
            Throughput = options.Throughput;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalSecondaryIndex"/> class.
        /// </summary>
        /// <param name="indexName">The name of the secondary global index.</param>
        /// <param name="partitionKeyName">The name of the partition key of the table.</param>
        /// <param name="setup">The <see cref="GlobalSecondaryIndexOptions" /> which need to be configured.</param>
        public GlobalSecondaryIndex(string indexName, string partitionKeyName, Action<GlobalSecondaryIndexOptions> setup = null) : this(indexName, partitionKeyName, AttributeType.String, setup)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalSecondaryIndex"/> class.
        /// </summary>
        /// <param name="indexName">The name of the secondary global index.</param>
        /// <param name="partitionKeyName">The name of the partition key of the table.</param>
        /// <param name="partitionKeyType">The data type of the partition key of the table. Default is <see cref="AttributeType.String"/>.</param>
        /// <param name="setup">The <see cref="GlobalSecondaryIndexOptions" /> which need to be configured.</param>
        public GlobalSecondaryIndex(string indexName, string partitionKeyName, AttributeType partitionKeyType, Action<GlobalSecondaryIndexOptions> setup = null) : this(indexName, new PartitionKey(partitionKeyName, partitionKeyType), setup)
        {
        }

        /// <summary>
        /// Gets or sets the throughput for the global secondary index.
        /// </summary>
        /// <value>The throughput for the global secondary index.</value>
        public ProvisionedThroughput Throughput { get; set; }
    }
}