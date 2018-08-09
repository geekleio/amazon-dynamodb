using System.Collections.Generic;
using Cuemon.Threading;

namespace WBPA.Amazon.DynamoDb
{
    /// <summary>
    /// Specifies options that is related to a creating or replacing an old item with a new item.
    /// </summary>
    /// <seealso cref="AsyncOptions" />
    public class ItemOptions : AsyncOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemOptions"/> class.
        /// </summary>
        /// <remarks>
        /// The following table shows the initial property values for an instance of <see cref="ItemOptions"/>.
        /// <list type="table">
        ///     <listheader>
        ///         <term>Property</term>
        ///         <description>Initial Value</description>
        ///     </listheader>
        ///     <item>
        ///         <term><see cref="Expression"/></term>
        ///         <description>A new instance of <see cref="DynamoDb.Expression"/>.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="ConditionExpression"/></term>
        ///         <description><c>null</c></description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="ExpressionMapping"/></term>
        ///         <description>An empty dictionary of <see cref="Dictionary{String,String}"/>.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="ResponseAttributes"/></term>
        ///         <description><see cref="TableItemResponseAttributes.None"/></description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="ResponseCapacity"/></term>
        ///         <description><see cref="ConsumedCapacityResponse.None"/></description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="ResponseMetrics"/></term>
        ///         <description><see cref="TableItemResponseMetrics.None"/></description>
        ///     </item>
        /// </list>
        /// </remarks>
        public ItemOptions()
        {
            ResponseAttributes = TableItemResponseAttributes.None;
            ResponseMetrics = TableItemResponseMetrics.None;
            ResponseCapacity = ConsumedCapacityResponse.None;
            Expression = new Expression();
            ExpressionMapping = new Dictionary<string, string>();
            ConditionExpression = null;
        }

        /// <summary>
        /// Gets or sets instructions for retreiving attributes as they appeared before they were updated.
        /// </summary>
        /// <value>The instructions for retreiving attributes as they appeared before they were updated.</value>
        public TableItemResponseAttributes ResponseAttributes { get; set; }

        /// <summary>
        /// Gets or sets instructions for whether item collection metrics are returned.
        /// </summary>
        /// <value>The instructions for whether item collection metrics are returned.</value>
        public TableItemResponseMetrics ResponseMetrics { get; set; }

        /// <summary>
        /// Gets or sets the level of detail about provisioned throughput consumption that is returned in the response.
        /// </summary>
        /// <value>The level of detail about provisioned throughput consumption that is returned in the response.</value>
        public ConsumedCapacityResponse ResponseCapacity { get; set; }

        /// <summary>
        /// Gets or sets the condition that must be satisfied in order for a conditional operation to succeed.
        /// </summary>
        /// <value>The condition that must be satisfied in order for a conditional operation to succeed.</value>
        public string ConditionExpression { get; set; }

        /// <summary>
        /// Gets or sets the substitution tokens for attribute names in an expression.
        /// </summary>
        /// <value>The substitution tokens for attribute names in an expression.</value>
        public Dictionary<string, string> ExpressionMapping { get; }

        /// <summary>
        /// Gets or sets the values that can be substituted in an expression.
        /// </summary>
        /// <value>The values that can be substituted in an expression.</value>
        public Expression Expression { get; }
    }
}