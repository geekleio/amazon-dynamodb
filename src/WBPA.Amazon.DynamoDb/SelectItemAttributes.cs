namespace WBPA.Amazon.DynamoDb
{
    /// <summary>
    /// Specifies the attributes to be returned in the result.
    /// </summary>
    public enum SelectItemAttributes
    {
        /// <summary>
        /// Returns all of the item attributes from the specified table or index. If you query a local secondary index, then for each matching item in the index DynamoDB will fetch the entire item from the parent table.
        /// </summary>
        All = 0,
        /// <summary>
        /// Allowed only when querying an index. Retrieves all attributes that have been projected into the index.
        /// </summary>
        AllProjected = 1,
        /// <summary>
        /// Returns the number of matching items, rather than the matching items themselves.
        /// </summary>
        Count = 2,
        /// <summary>
        /// Returns only the attributes listed in AttributesToGet. This return value is equivalent to specifying AttributesToGet without specifying any value for Select.
        /// </summary>
        Specific = 3
    }
}