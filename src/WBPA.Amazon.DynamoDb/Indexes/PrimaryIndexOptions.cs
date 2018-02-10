namespace WBPA.Amazon.DynamoDb.Indexes
{
    /// <summary>
    /// Specifies options that is related to <see cref="PrimaryIndex"/> operations. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="AsyncOptions" />
    public sealed class PrimaryIndexOptions : AsyncOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrimaryIndexOptions"/> class.
        /// </summary>
        /// <remarks>
        /// The following table shows the initial property values for an instance of <see cref="PrimaryIndexOptions"/>.
        /// <list type="table">
        ///     <listheader>
        ///         <term>Property</term>
        ///         <description>Initial Value</description>
        ///     </listheader>
        ///     <item>
        ///         <term><see cref="SortKey"/></term>
        ///         <description><c>null</c>.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="LocalSecondaryIndexes"/></term>
        ///         <description>An empty collection of <see cref="SecondaryIndexCollection{T}"/>.</description>
        ///     </item>
        /// </list>
        /// </remarks>
        public PrimaryIndexOptions()
        {
            SortKey = null;
            LocalSecondaryIndexes = new SecondaryIndexCollection<SecondaryIndex>();
        }

        /// <summary>
        /// Gets or sets the sort key of the table.
        /// </summary>
        /// <value>The sort key of the table.</value>
        public SortKey SortKey { get; set; }

        /// <summary>
        /// Gets the local secondary indexes of the table.
        /// </summary>
        /// <value>The local secondary indexes of the table.</value>
        public SecondaryIndexCollection<SecondaryIndex> LocalSecondaryIndexes { get; }
    }
}