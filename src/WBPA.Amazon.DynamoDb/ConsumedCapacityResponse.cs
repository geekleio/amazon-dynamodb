namespace WBPA.Amazon.DynamoDb
{
    /// <summary>
    /// Specifies the level of details about provisioned throughput consumption that is returned in the response.
    /// </summary>
    public enum ConsumedCapacityResponse
    {
        /// <summary>
        /// No ConsumedCapacity details are included in the response.
        /// </summary>
        None = 0,
        /// <summary>
        /// The response includes the aggregate ConsumedCapacity for the operation, together with ConsumedCapacity for each table and secondary index that was accessed.
        /// </summary>
        Indexes = 1,
        /// <summary>
        /// The response includes only the aggregate ConsumedCapacity for the operation.
        /// </summary>
        Total = 2
    }
}