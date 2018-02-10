namespace WBPA.Amazon.DynamoDb
{
    /// <summary>
    /// Represents the default provisioned throughput settings for a table or index.
    /// </summary>
    public static class ThroughputOptions
    {
        /// <summary>
        /// The default maximum number of strongly consistent read capacity units consumed per second. Default is 5.
        /// </summary>
        public static int DefaultReadCapacityUnits = 5;


        /// <summary>
        /// The default maximum number of write capacity units consumed per second. Default is 5.
        /// </summary>
        public static int DefaultWriteCapacityUnits = 5;
    }
}