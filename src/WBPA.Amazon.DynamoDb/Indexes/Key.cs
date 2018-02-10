using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using WBPA.Amazon.Attributes;

namespace WBPA.Amazon.DynamoDb.Indexes
{
    /// <summary>
    /// Provides a base class for working with partition key and/or sort key on AWS DynamoDB. This is an abstract class.
    /// </summary>
    public abstract class Key
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Key"/> class.
        /// </summary>
        /// <param name="keyName">The name of the key of a table or index.</param>
        /// <param name="keyType">The data type of the key of a table or index.</param>
        protected Key(string keyName, AttributeType keyType)
        {
            DynamoValidator.ThrowIfAttributeNameIsNotValid(keyName);
            Name = keyName;
            Type = keyType;
        }

        /// <summary>
        /// Gets the name of the key of a table or index.
        /// </summary>
        /// <value>The name of the key of a table or index.</value>
        public string Name { get; }

        /// <summary>
        /// Gets the data type of the key of a table or index.
        /// </summary>
        /// <value>The data type of the key of a table or index.</value>
        public AttributeType Type { get; internal set; }

        internal abstract KeyType Role { get; }

        internal KeySchemaElement ToKeySchemaElement()
        {
            return new KeySchemaElement()
            {
                KeyType = Role,
                AttributeName = Name
            };
        }

        internal AttributeDefinition ToAttributeDefinition()
        {
            return new AttributeDefinition()
            {
                AttributeName = Name,
                AttributeType = Type.ToScalarAttributeType()
            };
        }
    }
}