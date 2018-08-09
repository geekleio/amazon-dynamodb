using Cuemon.Threading;
using WBPA.Amazon.DynamoDb.Indexes;

namespace WBPA.Amazon.DynamoDb
{
    /// <summary>
    /// Specifies options that is related to querying table, local secondary index or global secondary index operations.
    /// </summary>
    /// <seealso cref="AsyncOptions" />
    public class QueryOptions : ResponseOptions
    {
        private int? _limit;
        /// <summary>
        /// The minimum number of table items allowed to return.
        /// </summary>
        public const int MinimumLimit = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryOptions"/> class.
        /// </summary>
        /// <remarks>
        /// The following table shows the initial property values for an instance of <see cref="QueryOptions"/>.
        /// <list type="table">
        ///     <listheader>
        ///         <term>Property</term>
        ///         <description>Initial Value</description>
        ///     </listheader>
        ///     <item>
        ///         <term><see cref="Limit"/></term>
        ///         <description><c>null</c></description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="ExclusiveStartKey"/></term>
        ///         <description><c>null</c></description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="ScanIndexForward"/></term>
        ///         <description><c>true</c></description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="IndexName"/></term>
        ///         <description><c>null</c></description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="FilterExpression"/></term>
        ///         <description><c>null</c></description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="SelectAttributes"/></term>
        ///         <description><see cref="SelectItemAttributes.All"/></description>
        ///     </item>
        /// </list>
        /// </remarks>
        public QueryOptions()
        {
            ExclusiveStartKey = null;
            ScanIndexForward = true;
            IndexName = null;
            Limit = null;
            FilterExpression = null;
            SelectAttributes = SelectItemAttributes.All;
        }

        /// <summary>
        /// Gets or sets the limit of the query.
        /// </summary>
        /// <value>The limit of the query.</value>
        public int? Limit
        {
            get => _limit;
            set
            {
                if (value < MinimumLimit) { value = MinimumLimit; }
                _limit = value;
            }
        }

        /// <summary>
        /// Gets or sets the primary key of the first item that this operation will evaluate.
        /// </summary>
        /// <value>The primary key of the first item that this operation will evaluate.</value>
        public PrimaryKey ExclusiveStartKey { get; set; }

        /// <summary>
        /// Gets or sets a value that defines the order for index traversal.
        /// </summary>
        /// <value><c>true</c> if the traversal should be performed in ascending order; otherwise, <c>false</c>, for the traversal to be performed in descending order.</value>
        public bool ScanIndexForward { get; set; }

        /// <summary>
        /// Gets or sets the name of an index to query.
        /// </summary>
        /// <value>The name of an index to query.</value>
        public string IndexName { get; set; }

        /// <summary>
        /// Gets or sets the filter expression that contains conditions that DynamoDB applies after the Query operation, but before the data is returned to you. 
        /// </summary>
        /// <value>The filter expression that contains conditions that DynamoDB applies after the Query operation, but before the data is returned to you.</value>
        public string FilterExpression { get; set; }

        /// <summary>
        /// Gets or sets the attributes to be returned in the result.
        /// </summary>
        /// <value>The select attributes to be returned in the result.</value>
        public SelectItemAttributes SelectAttributes { get; set; }
    }
}