using Amazon.DynamoDBv2.Model;
using Cuemon;

namespace WBPA.Amazon.DynamoDb.Indexes
{
    /// <summary>
    /// Represents the provisioned throughput settings for a global secondary index.
    /// </summary>
    public class IndexProvision
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndexProvision"/> class.
        /// </summary>
        /// <param name="indexName">The name of the global secondary index.</param>
        /// <param name="throughput">The provisioned throughput if the global secondary index.</param>
        public IndexProvision(string indexName, ProvisionedThroughput throughput)
        {
            DynamoValidator.ThrowIfIndexNameIsNotValid(indexName);
            Validator.ThrowIfNull(throughput, nameof(throughput));
            IndexName = indexName;
            Throughput = throughput;
        }

        /// <summary>
        /// Gets the name of the global secondary index.
        /// </summary>
        /// <value>The name of the global secondary index.</value>
        public string IndexName { get; }

        /// <summary>
        /// Gets the provisioned throughput if the global secondary index.
        /// </summary>
        /// <value>The provisioned throughput if the global secondary index.</value>
        public ProvisionedThroughput Throughput { get; }
    }
}