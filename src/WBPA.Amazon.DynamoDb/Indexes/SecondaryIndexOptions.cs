namespace WBPA.Amazon.DynamoDb.Indexes
{
    /// <summary>
    /// Specifies options that is related to <see cref="SecondaryIndex"/> operations.
    /// </summary>
    /// <seealso cref="AsyncOptions" />
    public class SecondaryIndexOptions : AsyncOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecondaryIndexOptions"/> class.
        /// </summary>
        /// <remarks>
        /// The following table shows the initial property values for an instance of <see cref="SecondaryIndexOptions"/>.
        /// <list type="table">
        ///     <listheader>
        ///         <term>Property</term>
        ///         <description>Initial Value</description>
        ///     </listheader>
        ///     <item>
        ///         <term><see cref="IndexProjection"/></term>
        ///         <description>A new instance of <see cref="IndexProjection"/>.</description>
        ///     </item>
        /// </list>
        /// </remarks>
        public SecondaryIndexOptions()
        {
            Projection = new IndexProjection();
        }

        /// <summary>
        /// Gets or sets the projection from the table into the index.
        /// </summary>
        /// <value>The projection from the table into the index.</value>
        public IndexProjection Projection { get; set; }
    }
}