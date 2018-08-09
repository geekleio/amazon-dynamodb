using System;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;
using Cuemon;
using Cuemon.Threading;
using WBPA.Amazon.Runtime;

namespace WBPA.Amazon.DynamoDb
{
    /// <summary>
    /// Provides a base-class for AWS DynamoDB implementations.
    /// </summary>
    /// <seealso cref="Manager{AmazonDynamoDBClient, AmazonDynamoDBConfig}" />
    public abstract class AmazonDynamoDbManager : Manager<AmazonDynamoDBClient, AmazonDynamoDBConfig>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AmazonDynamoDbManager"/> class.
        /// </summary>
        /// <param name="credentials">The credentials used to authenticate with AWS.</param>
        /// <param name="regionEndpointParser">The function delegate that will resolve a <see cref="RegionEndpoint" />.</param>
        /// <param name="setup">The <see cref="ManagerOptions" /> which need to be configured.</param>
        protected AmazonDynamoDbManager(AWSCredentials credentials, Func<RegionEndpoint> regionEndpointParser, Action<ManagerOptions> setup = null) : base(credentials, regionEndpointParser, setup)
        {
        }

        /// <summary>
        /// Returns the current provisioned-capacity limits for your AWS account in a region, both for the region as a whole and for any one DynamoDB table that you create there.
        /// </summary>
        /// <param name="setup">The <see cref="AsyncOptions" /> which need to be configured.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public Task<DescribeLimitsResponse> DescribeLimitsAsync(Action<AsyncOptions> setup = null)
        {
            var options = setup.ConfigureOptions();
            var dlr = new DescribeLimitsRequest();
            return Client.DescribeLimitsAsync(dlr, options.CancellationToken);
        }
    }
}