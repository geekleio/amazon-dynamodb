namespace WBPA.Amazon.DynamoDb
{
    /// <summary>
    /// Specifies ways for an item to include metrics in a response.
    /// </summary>
    public enum TableItemResponseMetrics
    {
        /// <summary>
        /// No metrics is returned for the item with the operation.
        /// </summary>
        None = 0,
        /// <summary>
        /// Includes statistics about item collections, if any, that were modified during the operation.
        /// </summary>
        Size = 1
    }
}