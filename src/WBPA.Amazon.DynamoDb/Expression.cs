using System;
using System.Collections.Generic;
using System.Linq;
using Amazon.DynamoDBv2.Model;
using Cuemon;

namespace WBPA.Amazon.DynamoDb
{
    /// <summary>
    /// Represents one or more expression attribute values.
    /// </summary>
    public class Expression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Expression"/> class.
        /// </summary>
        /// <param name="setup">The <see cref="Dictionary{AttributeName,AttributeValue}" /> which need to be configured.</param>
        public Expression(Action<Dictionary<AttributeName, AttributeValue>> setup = null)
        {
            Attributes = setup.ConfigureOptions();
        }

        /// <summary>
        /// Gets the attributes of this instance.
        /// </summary>
        /// <value>The attributes to store with the item.</value>
        public Dictionary<AttributeName, AttributeValue> Attributes { get; }

        internal Dictionary<string, AttributeValue> ToAttributeValues()
        {
            return Attributes.ToDictionary(ks =>  ks.Key.Value, vs => vs.Value);
        }
    }
}