using System.Collections.Generic;
using Amazon.DynamoDBv2.Model;
using WBPA.Amazon.DynamoDb.Indexes;

namespace WBPA.Amazon.DynamoDb
{
    /// <summary>
    /// Specifies options that is related to modifying the provisioned throughput settings, global secondary indexes, or DynamoDB Streams settings for a given table.
    /// </summary>
    /// <seealso cref="TableOptions" />.
    public class UpdateTableOptions : TableOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateTableOptions"/> class.
        /// </summary>
        /// <remarks>
        /// The following table shows the initial property values for an instance of <see cref="UpdateTableOptions"/>.
        /// <list type="table">
        ///     <listheader>
        ///         <term>Property</term>
        ///         <description>Initial Value</description>
        ///     </listheader>
        ///     <item>
        ///         <term><see cref="GlobalSecondaryIndexNames"/></term>
        ///         <description>An empty collection of <see cref="IndexNameCollection"/>.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="GlobalSecondaryIndexProvisions"/></term>
        ///         <description>An empty collection of <see cref="IndexProvisionCollection"/>.</description>
        ///     </item>
        /// </list>
        /// </remarks>
        public UpdateTableOptions()
        {
            GlobalSecondaryIndexProvisions = new IndexProvisionCollection();
            GlobalSecondaryIndexNames = new IndexNameCollection();
            Throughput = null;
        }

        /// <summary>
        /// Gets the new provisioned throughput settings for the specified table or index.
        /// </summary>
        /// <value>The new provisioned throughput settings for the specified table or index.</value>
        public IndexProvisionCollection GlobalSecondaryIndexProvisions { get; }

        /// <summary>
        /// Gets the global secondary index names to remove from the table.
        /// </summary>
        /// <value>The global secondary index names to remove from the table.</value>
        public IndexNameCollection GlobalSecondaryIndexNames { get; }

        internal List<GlobalSecondaryIndexUpdate> ToGlobalSecondaryIndexUpdates()
        {
            var definitions = new List<GlobalSecondaryIndexUpdate>();
            AppendCreate(definitions);
            AppendUpdate(definitions);
            AppendDelete(definitions);
            return definitions;
        }

        private void AppendDelete(List<GlobalSecondaryIndexUpdate> definitions)
        {
            foreach (var indexName in GlobalSecondaryIndexNames)
            {
                definitions.Add(new GlobalSecondaryIndexUpdate()
                {
                    Delete = new DeleteGlobalSecondaryIndexAction()
                    {
                        IndexName = indexName
                    }
                });
            }
        }

        private void AppendCreate(List<GlobalSecondaryIndexUpdate> definitions)
        {
            foreach (var gsi in GlobalSecondaryIndexes)
            {
                definitions.Add(new GlobalSecondaryIndexUpdate()
                {
                    Create = new CreateGlobalSecondaryIndexAction()
                    {
                        Projection = gsi.Projection.ToProjection(),
                        ProvisionedThroughput = gsi.Throughput,
                        KeySchema = gsi.ToKeySchema(),
                        IndexName = gsi.IndexName
                    }
                });
            }
        }

        private void AppendUpdate(List<GlobalSecondaryIndexUpdate> definitions)
        {
            foreach (var throughput in GlobalSecondaryIndexProvisions)
            {
                definitions.Add(new GlobalSecondaryIndexUpdate()
                {
                    Update = new UpdateGlobalSecondaryIndexAction()
                    {
                        ProvisionedThroughput = throughput.Throughput,
                        IndexName = throughput.IndexName
                    }
                });
            }
        }
    }
}