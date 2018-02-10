namespace WBPA.Amazon.DynamoDb
{
    /// <summary>
    /// Specifies options that is related to list tables operations.
    /// </summary>
    /// <seealso cref="AsyncOptions" />
    public class ListTablesOptions : AsyncOptions
    {
        private string _exclusiveStartTableName;
        private int _limit;
        /// <summary>
        /// The minimum number of table names allowed to return.
        /// </summary>
        public const int MinimumLimit = 1;

        /// <summary>
        /// The maximum number of table names allowed to return.
        /// </summary>
        public const int MaximumLimit = 100;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListTablesOptions"/> class.
        /// </summary>
        /// <remarks>
        /// The following table shows the initial property values for an instance of <see cref="ListTablesOptions"/>.
        /// <list type="table">
        ///     <listheader>
        ///         <term>Property</term>
        ///         <description>Initial Value</description>
        ///     </listheader>
        ///     <item>
        ///         <term><see cref="ExclusiveStartTableName"/></term>
        ///         <description><c>null</c></description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="Limit"/></term>
        ///         <description><c>100</c></description>
        ///     </item>
        /// </list>
        /// </remarks>
        public ListTablesOptions()
        {
            Limit = MaximumLimit;
        }

        /// <summary>
        /// Gets or sets the first table name that this operation will evaluate.
        /// </summary>
        /// <value>The first table name that this operation will evaluate.</value>
        public string ExclusiveStartTableName
        {
            get => _exclusiveStartTableName;
            set
            {
                DynamoValidator.ThrowIfTableNameIsNotValid(value, nameof(value));
                _exclusiveStartTableName = value;
            }
        }

        /// <summary>
        /// Gets or sets the maximum number of table names to return.
        /// </summary>
        /// <value>The maximum number of table names to return.</value>
        public int Limit
        {
            get => _limit;
            set
            {
                if (value < MinimumLimit) { value = MinimumLimit; }
                if (value > MaximumLimit) { value = MaximumLimit; }
                _limit = value;
            }
        }
    }
}