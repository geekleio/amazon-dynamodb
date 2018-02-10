namespace WBPA.Amazon.DynamoDb.Indexes
{
    /// <summary>
    /// Specifies attributes that are copied (projected) from the table into the index.
    /// </summary>
    public enum IndexProjectionType
    {
        /// <summary>
        /// All of the table attributes are projected into the index.
        /// </summary>
        All,
        /// <summary>
        /// Only the specified table attributes are projected into the index. The list of projected attributes are in NonKeyAttributes.
        /// </summary>
        Include,
        /// <summary>
        /// Only the index and primary keys are projected into the index.
        /// </summary>
        KeysOnly
    }
}