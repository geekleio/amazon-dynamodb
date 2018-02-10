using Amazon.DynamoDBv2.Model;

namespace WBPA.Amazon.DynamoDb
{
    /// <summary>
    /// Specifies options that is related to enabling or disabling TTL for a given table.
    /// </summary>
    /// <seealso cref="AsyncOptions" />
    public class TimeToLiveOptions : AsyncOptions
    {
        /// <summary>
        /// The suggested and default attribute name, epoch_expires, for the <see cref="Specification"/>.
        /// </summary>
        public const string SuggestedAttributeName = "epoch_expires";

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeToLiveOptions"/> class.
        /// </summary>
        /// <remarks>
        /// The following table shows the initial property values for an instance of <see cref="TimeToLiveOptions"/>.
        /// <list type="table">
        ///     <listheader>
        ///         <term>Property</term>
        ///         <description>Initial Value</description>
        ///     </listheader>
        ///     <item>
        ///         <term><see cref="Specification"/></term>
        ///         <description>A new instance of <see cref="TimeToLiveSpecification"/> initialized with <see cref="TimeToLiveSpecification.Enabled"/> set to <c>true</c> and <see cref="TimeToLiveSpecification.AttributeName"/> set to <c>epoch_expires</c>.</description>
        ///     </item>
        /// </list>
        /// </remarks>
        public TimeToLiveOptions()
        {
            Specification = new TimeToLiveSpecification()
            {
                AttributeName = SuggestedAttributeName,
                Enabled = true
            };
        }

        /// <summary>
        /// Gets or sets the settings used to enable or disable Time to Live for the specified table.
        /// </summary>
        /// <value>The settings used to enable or disable Time to Live for the specified table.</value>
        public TimeToLiveSpecification Specification { get; set; }
    }
}