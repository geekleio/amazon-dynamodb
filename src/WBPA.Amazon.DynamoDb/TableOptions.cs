using Amazon.DynamoDBv2.Model;
using Cuemon.Threading;
using WBPA.Amazon.DynamoDb.Indexes;
using GlobalSecondaryIndex = WBPA.Amazon.DynamoDb.Indexes.GlobalSecondaryIndex;

namespace WBPA.Amazon.DynamoDb
{
    /// <summary>
    /// Specifies options that is related to adding a new table to your account.
    /// </summary>
    /// <seealso cref="AsyncOptions"/>.
    public class TableOptions : AsyncOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TableOptions"/> class.
        /// </summary>
        /// <remarks>
        /// The following table shows the initial property values for an instance of <see cref="TableOptions"/>.
        /// <list type="table">
        ///     <listheader>
        ///         <term>Property</term>
        ///         <description>Initial Value</description>
        ///     </listheader>
        ///     <item>
        ///         <term><see cref="GlobalSecondaryIndexes"/></term>
        ///         <description>An empty collection of <see cref="SecondaryIndexCollection{GlobalSecondaryIndex}"/>.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="StreamSpecification"/></term>
        ///         <description><c>null</c>.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="Throughput"/></term>
        ///         <description>A new instance of <see cref="ProvisionedThroughput"/>.</description>
        ///     </item>
        /// </list>
        /// </remarks>
        public TableOptions()
        {
            GlobalSecondaryIndexes = new SecondaryIndexCollection<GlobalSecondaryIndex>();
            Throughput = new ProvisionedThroughput(ThroughputOptions.DefaultReadCapacityUnits, ThroughputOptions.DefaultWriteCapacityUnits);
            StreamSpecification = null;
        }

        /// <summary>
        /// Gets the global secondary indexes (the maximum is five) to be created on the table.
        /// </summary>
        /// <value>The global secondary indexes (the maximum is five) to be created on the table.</value>
        public SecondaryIndexCollection<GlobalSecondaryIndex> GlobalSecondaryIndexes { get; }

        /// <summary>
        /// Gets the settings for DynamoDB Streams on the table.
        /// </summary>
        /// <value>The settings for DynamoDB Streams on the table.</value>
        public StreamSpecification StreamSpecification { get; }

        /// <summary>
        /// Gets or sets the provisioned throughput settings for a specified table or index.
        /// </summary>
        /// <value>The provisioned throughput settings for a specified table or index.</value>
        public ProvisionedThroughput Throughput { get; set; }
    }
}