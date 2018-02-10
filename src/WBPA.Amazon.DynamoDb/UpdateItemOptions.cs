namespace WBPA.Amazon.DynamoDb
{
    /// <summary>
    /// Specifies options that is related to updating an existing item's attributes, or adding a new item to the table if it does not already exist.
    /// </summary>
    /// <seealso cref="ItemOptions" />
    public class UpdateItemOptions : ItemOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateItemOptions"/> class.
        /// </summary>
        /// <remarks>
        /// The following table shows the initial property values for an instance of <see cref="UpdateItemOptions"/>.
        /// <list type="table">
        ///     <listheader>
        ///         <term>Property</term>
        ///         <description>Initial Value</description>
        ///     </listheader>
        ///     <item>
        ///         <term><see cref="UpdateExpression"/></term>
        ///         <description><c>null</c></description>
        ///     </item>
        /// </list>
        /// </remarks>
        public UpdateItemOptions()
        {
            UpdateExpression = null;
        }

        /// <summary>
        /// Gets or sets the expression that defines one or more attributes to be updated, the action to be performed on them, and new value(s) for them.
        /// </summary>
        /// <value>The expression that defines one or more attributes to be updated, the action to be performed on them, and new value(s) for them.</value>
        public string UpdateExpression { get; set; }
    }
}