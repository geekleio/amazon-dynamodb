using System;
using System.Collections.Generic;
using Amazon.DynamoDBv2.Model;
using Cuemon;

namespace WBPA.Amazon.DynamoDb
{
    /// <summary>
    /// Represents a map of attribute name/value pairs, one for each attribute.
    /// </summary>
    public class TableItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TableItem"/> class.
        /// </summary>
        /// <param name="setup">The <see cref="Dictionary{String,AttributeValue}" /> which need to be configured.</param>
        public TableItem(Action<Dictionary<string, AttributeValue>> setup = null)
        {
            Attributes = setup.ConfigureOptions();
        }

        /// <summary>
        /// Gets the attributes of this instance.
        /// </summary>
        /// <value>The attributes to store with the item.</value>
        public Dictionary<string, AttributeValue> Attributes { get; }
    }
}