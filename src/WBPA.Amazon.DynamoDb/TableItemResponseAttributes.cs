namespace WBPA.Amazon.DynamoDb
{
    /// <summary>
    /// Specifies ways for an item to include attributes in a response.
    /// </summary>
    public enum TableItemResponseAttributes
    {
        /// <summary>
        /// No attributes is returned for the item with the operation.
        /// </summary>
        None = 0,
        /// <summary>
        /// Returns the entire set of attributes for the item as it appeared before the operation.
        /// </summary>
        AllOld = 1,
        /// <summary>
        /// Returns the entire set of attributes for the item as it appeared after the operation.
        /// </summary>
        AllNew = 2,
        /// <summary>
        /// Returns only the updated attributes for the item, as they appeared before the operation.
        /// </summary>
        UpdatedOld = 3,
        /// <summary>
        /// Returns only the affected attributes for the item, as they appeared after the operation.
        /// </summary>
        UpdatedNew = 4
    }
}