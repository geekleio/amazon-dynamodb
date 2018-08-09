using System;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;
using Cuemon;
using WBPA.Amazon.DynamoDb.Indexes;
using WBPA.Amazon.Runtime;

namespace WBPA.Amazon.DynamoDb
{
    /// <summary>
    /// Provides ways for querying tables on AWS DynamoDB. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="AmazonDynamoDbManager" />
    public sealed class ItemManager : AmazonDynamoDbManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TableManager"/> class.
        /// </summary>
        /// <param name="endpoint">The <see cref="RegionEndpoint" /> from where to manage DynamoDB related operations.</param>
        /// <param name="credentials">The credentials used to authenticate with AWS.</param>
        /// <param name="setup">The <see cref="ManagerOptions" /> which need to be configured.</param>
        public ItemManager(RegionEndpoint endpoint, AWSCredentials credentials, Action<ManagerOptions> setup = null) : base(credentials, () => endpoint, setup)
        {
            Validator.ThrowIfNull(endpoint, nameof(endpoint));
        }

        /// <summary>
        /// Creates a new <paramref name="item"/>, or replaces an old item with a new <paramref name="item"/> as an asynchronous operation.
        /// </summary>
        /// <param name="table">The name of the table to contain the item.</param>
        /// <param name="item">The map of attribute name/value pairs, one for each attribute.</param>
        /// <param name="setup">The <see cref="ItemOptions" /> which need to be configured.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public Task<PutItemResponse> PutAsync(string table, TableItem item, Action<ItemOptions> setup = null)
        {
            DynamoValidator.ThrowIfTableNameIsNotValid(table);
            Validator.ThrowIfNull(item, nameof(item));
            var options = setup.ConfigureOptions();
            var pir = new PutItemRequest()
            {
                TableName = table,
                Item = item.Attributes,
                ConditionExpression = options.ConditionExpression,
                ExpressionAttributeNames = options.ExpressionMapping,
                ExpressionAttributeValues = options.Expression.ToAttributeValues(),
                ReturnConsumedCapacity = options.ResponseCapacity.ToReturnConsumedCapacity(),
                ReturnItemCollectionMetrics = options.ResponseMetrics.ToReturnItemCollectionMetrics(),
                ReturnValues = options.ResponseAttributes.ToReturnValue(TableItemOperation.Create)
            };
            return Client.PutItemAsync(pir, options.CancellationToken);
        }

        /// <summary>
        /// Deletes a single item in a <paramref name="table"/> by primary <paramref name="key"/> as an asynchronous operation.
        /// </summary>
        /// <param name="table">The name of the table from which to delete the item.</param>
        /// <param name="key">The map of attribute names to <see cref="AttributeValue"/> objects, representing the primary key of the item to delete.</param>
        /// <param name="setup">The <see cref="ItemOptions" /> which need to be configured.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public Task<DeleteItemResponse> DeleteAsync(string table, PrimaryKey key, Action<ItemOptions> setup = null)
        {
            DynamoValidator.ThrowIfTableNameIsNotValid(table);
            Validator.ThrowIfNull(key, nameof(key));
            var options = setup.ConfigureOptions();
            var dir = new DeleteItemRequest()
            {
                TableName = table,
                ReturnValues = options.ResponseAttributes.ToReturnValue(TableItemOperation.Delete),
                ReturnItemCollectionMetrics = options.ResponseMetrics.ToReturnItemCollectionMetrics(),
                ConditionExpression = options.ConditionExpression,
                ReturnConsumedCapacity = options.ResponseCapacity.ToReturnConsumedCapacity(),
                ExpressionAttributeValues = options.Expression.ToAttributeValues(),
                ExpressionAttributeNames = options.ExpressionMapping,
                Key = key.ToAttributeValues()
            };
            return Client.DeleteItemAsync(dir, options.CancellationToken);
        }

        /// <summary>
        /// Returns a set of attributes for the item with the given primary <paramref name="key"/> as an asynchronous operation.
        /// </summary>
        /// <param name="table">The name of the table containing the requested item.</param>
        /// <param name="key">The map of attribute names to <see cref="AttributeValue"/> objects, representing the primary key of the item to retrieve.</param>
        /// <param name="setup">The <see cref="ResponseOptions" /> which need to be configured.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public Task<GetItemResponse> GetAsync(string table, PrimaryKey key, Action<ResponseOptions> setup = null)
        {
            DynamoValidator.ThrowIfTableNameIsNotValid(table);
            Validator.ThrowIfNull(key, nameof(key));
            var options = setup.ConfigureOptions();
            var gir = new GetItemRequest()
            {
                TableName = table,
                ReturnConsumedCapacity = options.ResponseCapacity.ToReturnConsumedCapacity(),
                ExpressionAttributeNames = options.ExpressionMapping,
                Key = key.ToAttributeValues(),
                ConsistentRead = options.ConsistentRead,
                ProjectionExpression = options.ProjectionExpression
            };
            return Client.GetItemAsync(gir, options.CancellationToken);
        }

        /// <summary>
        /// Updates an existing item's attributes, or adds a new item to the <paramref name="table"/> if it does not already exist as an asynchronous operation.
        /// </summary>
        /// <param name="table">The name of the table containing the item to update.</param>
        /// <param name="key">The map of attribute names to <see cref="AttributeValue"/> objects, representing the primary key of the item to update.</param>
        /// <param name="setup">The <see cref="UpdateItemOptions" /> which need to be configured.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public Task<UpdateItemResponse> UpdateAsync(string table, PrimaryKey key, Action<UpdateItemOptions> setup = null)
        {
            DynamoValidator.ThrowIfTableNameIsNotValid(table);
            Validator.ThrowIfNull(key, nameof(key));
            var options = setup.ConfigureOptions();
            var uir = new UpdateItemRequest()
            {
                TableName = table,
                ReturnValues = options.ResponseAttributes.ToReturnValue(TableItemOperation.Update),
                ReturnItemCollectionMetrics = options.ResponseMetrics.ToReturnItemCollectionMetrics(),
                ReturnConsumedCapacity =  options.ResponseCapacity.ToReturnConsumedCapacity(),
                ExpressionAttributeNames = options.ExpressionMapping,
                ConditionExpression = options.ConditionExpression,
                ExpressionAttributeValues = options.Expression.ToAttributeValues(),
                Key = key.ToAttributeValues(),
                UpdateExpression = options.UpdateExpression
            };
            return Client.UpdateItemAsync(uir, options.CancellationToken);
        }

        /// <summary>
        /// Finds items based on primary key values as an asynchronous operation.
        /// </summary>
        /// <param name="table">The name of the table containing the requested items.</param>
        /// <param name="keyConditionExpression">The condition that specifies the partition key value(s) for items to be retrieved.</param>
        /// <param name="expression">The values that can be substituted in an expression.</param>
        /// <param name="setup">The <see cref="QueryOptions" /> which need to be configured.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public Task<QueryResponse> QueryAsync(string table, string keyConditionExpression, Expression expression, Action<QueryOptions> setup = null)
        {
            DynamoValidator.ThrowIfTableNameIsNotValid(table);
            Validator.ThrowIfNullOrWhitespace(keyConditionExpression, nameof(keyConditionExpression));
            Validator.ThrowIfNull(expression, nameof(expression));
            var options = setup.ConfigureOptions();
            var qr = new QueryRequest()
            {
                TableName = table,
                ReturnConsumedCapacity = options.ResponseCapacity.ToReturnConsumedCapacity(),
                ExpressionAttributeNames = options.ExpressionMapping,
                ExpressionAttributeValues = expression.ToAttributeValues(),
                Select = options.SelectAttributes.ToSelect(), 
                ProjectionExpression = options.ProjectionExpression,
                ConsistentRead = options.ConsistentRead,
                ExclusiveStartKey = options.ExclusiveStartKey?.ToAttributeValues(),
                FilterExpression = options.FilterExpression,
                IndexName = options.IndexName,
                KeyConditionExpression = keyConditionExpression,
                ScanIndexForward = options.ScanIndexForward
            };
            if (options.Limit.HasValue) { qr.Limit = options.Limit.Value; }
            return Client.QueryAsync(qr, options.CancellationToken);
        }

        /// <summary>
        /// Returns one or more items and item attributes by accessing every item in a <paramref name="table"/> or a secondary index as an asynchronous operation.
        /// </summary>
        /// <param name="table">The name of the table containing the requested items.</param>
        /// <param name="setup">The <see cref="ScanOptions" /> which need to be configured.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public Task<ScanResponse> ScanAsync(string table, Action<ScanOptions> setup = null)
        {
            DynamoValidator.ThrowIfTableNameIsNotValid(table);
            var options = setup.ConfigureOptions();
            var sr = new ScanRequest()
            {
                TableName = table,
                ReturnConsumedCapacity = options.ResponseCapacity.ToReturnConsumedCapacity(),
                ExpressionAttributeNames = options.ExpressionMapping,
                ExpressionAttributeValues = options.Expression.ToAttributeValues(),
                Select = options.SelectAttributes.ToSelect(),
                ProjectionExpression = options.ProjectionExpression,
                ConsistentRead = options.ConsistentRead,
                ExclusiveStartKey = options.ExclusiveStartKey?.ToAttributeValues(),
                FilterExpression = options.FilterExpression,
                IndexName = options.IndexName
            };
            if (options.Limit.HasValue) { sr.Limit = options.Limit.Value; }
            if (options.Segment.HasValue) { sr.Segment = options.Segment.Value; }
            if (options.TotalSegments.HasValue) { sr.TotalSegments = options.TotalSegments.Value; }
            return Client.ScanAsync(sr, options.CancellationToken);
        }
    }
}