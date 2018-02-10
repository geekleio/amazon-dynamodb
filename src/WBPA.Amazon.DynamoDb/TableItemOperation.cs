namespace WBPA.Amazon.DynamoDb
{
    /// <summary>
    /// Specifies the operation to perform in relation to an item in a table.
    /// </summary>
    public enum TableItemOperation
    {
        /// <summary>
        /// Denotes a create operation.
        /// </summary>
        Create,
        /// <summary>
        /// Denotes a read operation.
        /// </summary>
        Read,
        /// <summary>
        /// Denotes an update operation.
        /// </summary>
        Update,
        /// <summary>
        /// Denotes a delete operation.
        /// </summary>
        Delete
    }
}