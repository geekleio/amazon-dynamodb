using Amazon.DynamoDBv2.Model;

namespace WBPA.Amazon.DynamoDb.Indexes
{
    /// <summary>
    /// Specifies options that is related to <see cref="GlobalSecondaryIndex"/> operations. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="SecondaryIndexOptions" />
    public sealed class GlobalSecondaryIndexOptions : SecondaryIndexOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalSecondaryIndexOptions"/> class.
        /// </summary>
        /// <remarks>
        /// The following table shows the initial property values for an instance of <see cref="GlobalSecondaryIndexOptions"/>.
        /// <list type="table">
        ///     <listheader>
        ///         <term>Property</term>
        ///         <description>Initial Value</description>
        ///     </listheader>
        ///     <item>
        ///         <term><see cref="SortKey"/></term>
        ///         <description><c>null</c>.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="Throughput"/></term>
        ///         <description>A new instance of <see cref="ProvisionedThroughput"/>.</description>
        ///     </item>
        /// </list>
        /// </remarks>
        public GlobalSecondaryIndexOptions()
        {
            SortKey = null;
            Throughput = new ProvisionedThroughput(ThroughputOptions.DefaultReadCapacityUnits, ThroughputOptions.DefaultWriteCapacityUnits);
        }

        /// <summary>
        /// Gets or sets the sort key of the global secondary index.
        /// </summary>
        /// <value>The sort key of the global secondary index.</value>
        public SortKey SortKey { get; set; }

       /// <summary>
        /// Gets or sets the throughput for the global secondary index.
        /// </summary>
        /// <value>The throughput for the global secondary index.</value>
        public ProvisionedThroughput Throughput { get; set; }
    }
}