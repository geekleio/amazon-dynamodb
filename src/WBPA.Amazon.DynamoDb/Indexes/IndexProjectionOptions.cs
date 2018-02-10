using WBPA.Amazon.DynamoDb.Attributes;

namespace WBPA.Amazon.DynamoDb.Indexes
{
    /// <summary>
    /// Specifies options that is related to <see cref="IndexProjection"/> operations. This class cannot be inherited.
    /// </summary>
    public sealed class IndexProjectionOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndexProjectionOptions"/> class.
        /// </summary>
        /// <remarks>
        /// The following table shows the initial property values for an instance of <see cref="GlobalSecondaryIndexOptions"/>.
        /// <list type="table">
        ///     <listheader>
        ///         <term>Property</term>
        ///         <description>Initial Value</description>
        ///     </listheader>
        ///     <item>
        ///         <term><see cref="ProjectionType"/></term>
        ///         <description><see cref="IndexProjectionType.All"/>.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="NonKeyAttributes"/></term>
        ///         <description>An empty collection of <see cref="NonKeyAttributeCollection"/>.</description>
        ///     </item>
        /// </list>
        /// </remarks>
        public IndexProjectionOptions()
        {
            ProjectionType = IndexProjectionType.All;
            NonKeyAttributes = new NonKeyAttributeCollection();
        }

        /// <summary>
        /// Gets or sets the type of the projection.
        /// </summary>
        /// <value>The type of the projection.</value>
        public IndexProjectionType ProjectionType { get; set; }

        /// <summary>
        /// Gets the the non-key attribute names which will be projected into the index.
        /// </summary>
        /// <value>The the non-key attribute names which will be projected into the index.</value>
        public NonKeyAttributeCollection NonKeyAttributes { get; }
    }
}