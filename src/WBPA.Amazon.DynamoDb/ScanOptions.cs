using WBPA.Amazon.DynamoDb.Indexes;

namespace WBPA.Amazon.DynamoDb
{
    /// <summary>
    /// Specifies options that is related to scanning every item in a table or a secondary index operations.
    /// </summary>
    /// <seealso cref="ResponseOptions" />
    public class ScanOptions : ResponseOptions
    {
        private int? _limit;
        private int? _segment;
        private int? _totalSegments;

        /// <summary>
        /// The minimum number of table names allowed to return.
        /// </summary>
        public const int MinimumLimit = 1;

        /// <summary>
        /// The minimum value allowed for <see cref="Segment"/>.
        /// </summary>
        public const int MinimumSegment = 0;

        /// <summary>
        /// The maximum value allowed for <see cref="Segment"/>.
        /// </summary>
        public const int MaximumSegment = 999999;

        /// <summary>
        /// The minimum value allowed for <see cref="TotalSegments"/>.
        /// </summary>
        public const int MinimumTotalSegment = MinimumSegment + 1;

        /// <summary>
        /// The maximum value allowed for <see cref="TotalSegments"/>.
        /// </summary>
        public const int MaximumTotalSegment = MaximumSegment + 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScanOptions"/> class.
        /// </summary>
        /// <remarks>
        /// The following table shows the initial property values for an instance of <see cref="ScanOptions"/>.
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
        ///         <term><see cref="Segment"/></term>
        ///         <description><c>null</c></description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="TotalSegments"/></term>
        ///         <description><c>null</c></description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="ExclusiveStartKey"/></term>
        ///         <description><c>null</c></description>
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
        ///     <item>
        ///         <term><see cref="Expression"/></term>
        ///         <description>A new instance of <see cref="DynamoDb.Expression"/>.</description>
        ///     </item>
        /// </list>
        /// </remarks>
        public ScanOptions()
        {
            Limit = null;
            Segment = null;
            TotalSegments = null;
            ExclusiveStartKey = null;
            IndexName = null;
            Expression = new Expression();
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
        /// Gets or sets the information for a parallel Scan request, that identifies an individual segment to be scanned by an application worker.
        /// </summary>
        /// <value>The information for a parallel Scan request, that identifies an individual segment to be scanned by an application worker.</value>
        /// <remarks>If you provide <see cref="Segment"/>, you must also provide <see cref="TotalSegments"/>.</remarks>
        public int? Segment
        {
            get => _segment;
            set
            {
                if (value < MinimumSegment) { value = MinimumSegment; }
                if (value > MaximumSegment) { value = MaximumSegment; }
                _segment = value;
            }
        }

        /// <summary>
        /// Gets or sets the information for a parallel Scan request, that represents the total number of segments into which the Scan operation will be divided.
        /// </summary>
        /// <value>The information for a parallel Scan request, that represents the total number of segments into which the Scan operation will be divided.</value>
        /// <remarks>If you provide <see cref="TotalSegments"/>, you must also provide <see cref="Segment"/>.</remarks>
        public int? TotalSegments
        {
            get => _totalSegments;
            set
            {
                if (value < MinimumTotalSegment) { value = MinimumTotalSegment; }
                if (value > MaximumTotalSegment) { value = MaximumTotalSegment; }
                _totalSegments = value;
            }
        }

        /// <summary>
        /// Gets the primary key of the first item that this operation will evaluate.
        /// </summary>
        /// <value>The primary key of the first item that this operation will evaluate.</value>
        public PrimaryKey ExclusiveStartKey { get; }

        /// <summary>
        /// Gets or sets the name of a secondary index to scan.
        /// </summary>
        /// <value>The name of a secondary index to scan.</value>
        public string IndexName { get; set; }

        /// <summary>
        /// Gets or sets the filter expression that contains conditions that DynamoDB applies after the Scan operation, but before the data is returned to you. 
        /// </summary>
        /// <value>The filter expression that contains conditions that DynamoDB applies after the Scan operation, but before the data is returned to you.</value>
        public string FilterExpression { get; set; }

        /// <summary>
        /// Gets or sets the attributes to be returned in the result.
        /// </summary>
        /// <value>The select attributes to be returned in the result.</value>
        public SelectItemAttributes SelectAttributes { get; set; }

        /// <summary>
        /// Gets or sets the values that can be substituted in an expression.
        /// </summary>
        /// <value>The values that can be substituted in an expression.</value>
        public Expression Expression { get; set; }
    }
}