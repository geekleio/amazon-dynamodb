using System;
using Cuemon;
using Cuemon.Collections.Generic;

namespace WBPA.Amazon.DynamoDb.Indexes
{
    /// <summary>
    /// Represents a collection of string values that is validated according to the index naming rules by AWS. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="ConditionalCollection{T}" />
    public sealed class IndexNameCollection : ConditionalCollection<string>
    {
        private const int MaximumCollectionSize = 5;

        /// <summary>
        /// Adds the specified name to this collection.
        /// </summary>
        /// <param name="indexName">The name of the message attribute.</param>
        public override void Add(string indexName)
        {
            Add(indexName, () => 
            {
                DynamoValidator.ThrowIfIndexNameIsNotValid(indexName, nameof(indexName));
                if (Contains(indexName)) { throw new ArgumentException("IndexName has already been added.", nameof(indexName)); }
                if (Count >= MaximumCollectionSize) { throw new ArgumentException("Unable to add index name; cannot exceed a maximum of {0} index names.".FormatWith(MaximumCollectionSize)); }
            });
        }

        /// <summary>
        /// Determines whether this collection contains the specified <paramref name="indexName"/>.
        /// </summary>
        /// <param name="indexName">The name of the message attribute.</param>
        /// <returns><c>true</c> if the specified <paramref name="indexName"/> is contained within this collection; otherwise, <c>false</c>.</returns>
        public override bool Contains(string indexName)
        {
            return Contains(indexName, StringComparer.Ordinal);
        }

        /// <summary>
        /// Removes the specified <paramref name="indexName"/> from this collection.
        /// </summary>
        /// <param name="indexName">The name of the message attribute.</param>
        /// <returns><c>true</c> if the <paramref name="indexName"/> was removed, <c>false</c> otherwise.</returns>
        public override bool Remove(string indexName)
        {
            return Remove(indexName, s => s == indexName, StringComparer.Ordinal);
        }
    }
}