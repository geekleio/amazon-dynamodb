using System;
using Cuemon;
using WBPA.Amazon.Attributes;

namespace WBPA.Amazon.DynamoDb.Indexes
{
    /// <summary>
    /// Represents a secondary local index for a table.
    /// </summary>
    /// <seealso cref="Index" />
    public class SecondaryIndex : Index
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecondaryIndex"/> class.
        /// </summary>
        /// <param name="indexName">The name of the secondary local index.</param>
        /// <param name="sortKey">The sort key of the table.</param>
        /// <param name="setup">The <see cref="SecondaryIndexOptions" /> which need to be configured.</param>
        public SecondaryIndex(string indexName, SortKey sortKey, Action<SecondaryIndexOptions> setup = null) : base()
        {
            DynamoValidator.ThrowIfIndexNameIsNotValid(indexName);
            var options = setup.ConfigureOptions();
            SortKey = sortKey;
            Projection = options.Projection;
            IndexName = indexName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecondaryIndex"/> class.
        /// </summary>
        /// <param name="indexName">The name of the secondary local index.</param>
        /// <param name="sortKeyName">The name of the sort key of the table.</param>
        /// <param name="setup">The <see cref="SecondaryIndexOptions" /> which need to be configured.</param>
        public SecondaryIndex(string indexName, string sortKeyName, Action<SecondaryIndexOptions> setup = null) : this(indexName, sortKeyName, AttributeType.String, setup)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecondaryIndex"/> class.
        /// </summary>
        /// <param name="indexName">The name of the secondary local index.</param>
        /// <param name="sortKeyName">The name of the sort key of the table.</param>
        /// <param name="sortKeyType">The data type of the sort key of the table. Default is <see cref="AttributeType.String"/>.</param>
        /// <param name="setup">The <see cref="SecondaryIndexOptions" /> which need to be configured.</param>
        public SecondaryIndex(string indexName, string sortKeyName, AttributeType sortKeyType, Action<SecondaryIndexOptions> setup = null) : this(indexName, new SortKey(sortKeyName, sortKeyType), setup)
        {
        }

        internal SecondaryIndex(string indexName, PartitionKey partitionKey) : base(partitionKey)
        {
            IndexName = indexName;
        }

        /// <summary>
        /// Gets or sets the name of the secondary local index.
        /// </summary>
        /// <value>The name of the secondary local index.</value>
        public string IndexName { get; set; }

        /// <summary>
        /// Gets or sets the projection from the table into the index.
        /// </summary>
        /// <value>The projection from the table into the index.</value>
        public IndexProjection Projection { get; set; }
    }
}