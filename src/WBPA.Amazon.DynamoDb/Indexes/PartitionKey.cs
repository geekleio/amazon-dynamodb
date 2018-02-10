using Amazon.DynamoDBv2;
using WBPA.Amazon.Attributes;

namespace WBPA.Amazon.DynamoDb.Indexes
{
    /// <summary>
    /// Represents a partition key of a table or index. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="Key" />
    public sealed class PartitionKey : Key
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PartitionKey"/> class.
        /// </summary>
        /// <param name="keyName">The name of the key of a table or index.</param>
        /// <param name="keyType">The data type of the key of a table or index.</param>
        public PartitionKey(string keyName, AttributeType keyType = AttributeType.String) : base(keyName, keyType)
        {
        }

        internal override KeyType Role => KeyType.HASH;
    }
}