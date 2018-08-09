using System.Collections.Generic;
using Cuemon.Threading;

namespace WBPA.Amazon.DynamoDb
{
    /// <summary>
    /// Specifies options that is related to a retrieving a set of attributes for an item, table or index.
    /// </summary>
    /// <seealso cref="AsyncOptions" />
    public class ResponseOptions : AsyncOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseOptions"/> class.
        /// </summary>
        /// <remarks>
        /// The following table shows the initial property values for an instance of <see cref="ResponseOptions"/>.
        /// <list type="table">
        ///     <listheader>
        ///         <term>Property</term>
        ///         <description>Initial Value</description>
        ///     </listheader>
        ///     <item>
        ///         <term><see cref="ResponseCapacity"/></term>
        ///         <description><see cref="ConsumedCapacityResponse.None"/></description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="ConsistentRead"/></term>
        ///         <description><c>false</c></description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="ExpressionMapping"/></term>
        ///         <description>An empty dictionary of <see cref="Dictionary{String,String}"/>.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="ProjectionExpression"/></term>
        ///         <description><c>null</c></description>
        ///     </item>
        /// </list>
        /// </remarks>
        public ResponseOptions()
        {
            ResponseCapacity = ConsumedCapacityResponse.None;
            ExpressionMapping = new Dictionary<string, string>();
            ConsistentRead = false;
            ProjectionExpression = null;
        }

        /// <summary>
        /// Gets or sets a value that determines the read consistency model.
        /// </summary>
        /// <value><c>true</c> if the operation uses strongly consistent reads; otherwise, <c>false</c>, for the operation to use eventually consistent reads.</value>
        public bool ConsistentRead { get; set; }

        /// <summary>
        /// Gets or sets the projection expression that identifies one or more attributes to retrieve from the table or index.
        /// </summary>
        /// <value>The projection expression that identifies one or more attributes to retrieve from the table or index.</value>
        public string ProjectionExpression { get; set; }

        /// <summary>
        /// Gets or sets the level of detail about provisioned throughput consumption that is returned in the response.
        /// </summary>
        /// <value>The level of detail about provisioned throughput consumption that is returned in the response.</value>
        public ConsumedCapacityResponse ResponseCapacity { get; set; }

        /// <summary>
        /// Gets or sets the substitution tokens for attribute names in an expression.
        /// </summary>
        /// <value>The substitution tokens for attribute names in an expression.</value>
        public Dictionary<string, string> ExpressionMapping { get; }
    }
}