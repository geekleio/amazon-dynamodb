using System;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;
using Cuemon;
using WBPA.Amazon.DynamoDb.Indexes;
using WBPA.Amazon.Runtime;
using GlobalSecondaryIndex = Amazon.DynamoDBv2.Model.GlobalSecondaryIndex;

namespace WBPA.Amazon.DynamoDb
{
    /// <summary>
    /// Provides ways for managing tables on AWS DynamoDB. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="AmazonDynamoDbManager" />
    public sealed class TableManager : AmazonDynamoDbManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TableManager"/> class.
        /// </summary>
        /// <param name="endpoint">The <see cref="RegionEndpoint" /> from where to manage DynamoDB related operations.</param>
        /// <param name="credentials">The credentials used to authenticate with AWS.</param>
        /// <param name="setup">The <see cref="ManagerOptions" /> which need to be configured.</param>
        public TableManager(RegionEndpoint endpoint, AWSCredentials credentials, Action<ManagerOptions> setup = null) : base(credentials, () => endpoint, setup)
        {
            Validator.ThrowIfNull(endpoint, nameof(endpoint));
        }

        /// <summary>
        /// Create a new <paramref name="table"/> on your AWS account as an asynchronous operation.
        /// </summary>
        /// <param name="table">The name of the table to create.</param>
        /// <param name="index">The attributes that make up the primary key for a table or an index.</param>
        /// <param name="setup">The <see cref="TableOptions" /> which need to be configured.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<CreateTableResponse> CreateAsync(string table, PrimaryIndex index, Action<TableOptions> setup = null)
        {
            DynamoValidator.ThrowIfTableNameIsNotValid(table);
            Validator.ThrowIfNull(index, nameof(index));
            var options = setup.ConfigureOptions();
            var ctr = new CreateTableRequest()
            {
                TableName = table,
                AttributeDefinitions = index.ToAttributeDefinitions().Concat(options.GlobalSecondaryIndexes.SelectMany(gsi => gsi.ToAttributeDefinitions())).ToList(),
                GlobalSecondaryIndexes = options.GlobalSecondaryIndexes.Select(ti => new GlobalSecondaryIndex
                {
                    IndexName = ti.IndexName,
                    KeySchema = ti.ToKeySchema(),
                    ProvisionedThroughput = ti.Throughput,
                    Projection = ti.Projection.ToProjection()    
                }).ToList(),
                KeySchema = index.ToKeySchema(),
                LocalSecondaryIndexes = index.LocalSecondaryIndexes.Select(ti => new LocalSecondaryIndex
                {
                    IndexName = ti.IndexName,
                    KeySchema = ti.ToKeySchema(),
                    Projection = ti.Projection.ToProjection()
                }).ToList(),
                ProvisionedThroughput = options.Throughput,
                StreamSpecification = options.StreamSpecification
            };
            return await Client.CreateTableAsync(ctr, options.CancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes a <paramref name="table"/> and all of its items as an asynchronous operation.
        /// </summary>
        /// <param name="table">The name of the table to delete.</param>
        /// <param name="setup">The <see cref="AsyncOptions" /> which need to be configured.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<DeleteTableResponse> DeleteAsync(string table, Action<AsyncOptions> setup = null)
        {
            DynamoValidator.ThrowIfTableNameIsNotValid(table);
            var options = setup.ConfigureOptions();
            var dtr = new DeleteTableRequest()
            {
                TableName = table
            };
            return await Client.DeleteTableAsync(dtr, options.CancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns information about the <paramref name="table"/>, including the current status of the <paramref name="table"/>, when it was created, the primary key schema, and any indexes on the <paramref name="table"/> as an asynchronous operation.
        /// </summary>
        /// <param name="table">The name of the table to describe.</param>
        /// <param name="setup">The <see cref="AsyncOptions" /> which need to be configured.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<DescribeTableResponse> DescribeAsync(string table, Action<AsyncOptions> setup = null)
        {
            DynamoValidator.ThrowIfTableNameIsNotValid(table);
            var options = setup.ConfigureOptions();
            var dtr = new DescribeTableRequest()
            {
                TableName = table
            };
            return await Client.DescribeTableAsync(dtr, options.CancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gives a description of the TTL status on the specified <paramref name="table"/> as an asynchronous operation.
        /// </summary>
        /// <param name="table">The name of the table to be described.</param>
        /// <param name="setup">The <see cref="AsyncOptions" /> which need to be configured.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<DescribeTimeToLiveResponse> DescribeTimeToLiveAsync(string table, Action<AsyncOptions> setup = null)
        {
            DynamoValidator.ThrowIfTableNameIsNotValid(table);
            var options = setup.ConfigureOptions();
            var dttlr = new DescribeTimeToLiveRequest()
            {
                TableName = table
            };
            return await Client.DescribeTimeToLiveAsync(dttlr, options.CancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns an array of table names associated with the current account and endpoint as an asynchronous operation.
        /// </summary>
        /// <param name="setup">The <see cref="ListTablesOptions" /> which need to be configured.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<ListTablesResponse> ListAsync(Action<ListTablesOptions> setup = null)
        {
            var options = setup.ConfigureOptions();
            var ltr = new ListTablesRequest()
            {
                ExclusiveStartTableName = options.ExclusiveStartTableName,
                Limit = options.Limit
            };
            return await Client.ListTablesAsync(ltr, options.CancellationToken).ConfigureAwait(false);
        }



        /// <summary>
        /// Modifies the provisioned throughput settings, global secondary indexes, or DynamoDB Streams settings for a given <paramref name="table"/> as an asynchronous operation.
        /// </summary>
        /// <param name="table">The name of the table to be updated.</param>
        /// <param name="setup">The <see cref="UpdateTableOptions" /> which need to be configured.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<UpdateTableResponse> UpdateAsync(string table, Action<UpdateTableOptions> setup = null)
        {
            DynamoValidator.ThrowIfTableNameIsNotValid(table);
            var options = setup.ConfigureOptions();
            var utr = new UpdateTableRequest()
            {
                TableName = table,
                ProvisionedThroughput = options.Throughput,
                AttributeDefinitions = options.GlobalSecondaryIndexes.SelectMany(gsi => gsi.ToAttributeDefinitions()).ToList(),
                StreamSpecification = options.StreamSpecification,
                GlobalSecondaryIndexUpdates = options.ToGlobalSecondaryIndexUpdates()
            };
            return await Client.UpdateTableAsync(utr, options.CancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Update the TTL for the specified <paramref name="table"/> as an asynchronous operation.
        /// </summary>
        /// <param name="table">The name of the table to be configured.</param>
        /// <param name="setup">The <see cref="TimeToLiveOptions" /> which need to be configured.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<UpdateTimeToLiveResponse> UpdateTimeToLiveAsync(string table, Action<TimeToLiveOptions> setup = null)
        {
            DynamoValidator.ThrowIfTableNameIsNotValid(table);
            var options = setup.ConfigureOptions();
            var uttlr = new UpdateTimeToLiveRequest()
            {
                TableName = table,
                TimeToLiveSpecification = options.Specification
            };
            return await Client.UpdateTimeToLiveAsync(uttlr, options.CancellationToken).ConfigureAwait(false);
        }
    }
}