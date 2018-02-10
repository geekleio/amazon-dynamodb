using System;
using Cuemon;
using Cuemon.Collections.Generic;

namespace WBPA.Amazon.DynamoDb.Indexes
{
    /// <summary>
    /// Represents a collection of <see cref="IndexProvision"/> objects that is validated according to the rules by AWS.
    /// </summary>
    /// <seealso cref="ConditionalCollection{IndexProvision}" />
    public class IndexProvisionCollection : ConditionalCollection<IndexProvision>
    {
        private const int MaximumCollectionSize = 5;

        /// <summary>
        /// Adds the specified provision to this collection.
        /// </summary>
        /// <param name="provision">The <see cref="IndexProvision"/> to add to the <see cref="IndexProvisionCollection"/>.</param>
        public override void Add(IndexProvision provision)
        {
            Add(provision, () =>
            {
                if (Count >= MaximumCollectionSize) { throw new ArgumentException("Unable to add index throughput specification; cannot exceed a maximum of {0} throughput specifications.".FormatWith(MaximumCollectionSize)); }
            });
        }

        /// <summary>
        /// Determines whether the <see cref="IndexProvisionCollection" /> contains a specific value.
        /// </summary>
        /// <param name="provision">The <see cref="IndexProvision"/> to locate in the <see cref="IndexProvisionCollection" />.</param>
        /// <returns><c>true</c> if <paramref name="provision" /> is found in the <see cref="IndexProvisionCollection" />; otherwise, <c>false</c>.</returns>
        public override bool Contains(IndexProvision provision)
        {
            return Contains(provision, DynamicEqualityComparer.Create<IndexProvision>(ix => ix.IndexName.GetHashCode(), (i1, i2) => i1.IndexName.GetHashCode() == i2.IndexName.GetHashCode()));
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="IndexProvisionCollection" />.
        /// </summary>
        /// <param name="provision">The object to remove from the <see cref="IndexProvisionCollection" />.</param>
        /// <returns><c>true</c> if <paramref name="provision" /> was successfully removed from the <see cref="IndexProvisionCollection" />; otherwise, <c>false</c>.</returns>
        public override bool Remove(IndexProvision provision)
        {
            return Remove(provision, ix => ix.IndexName.Equals(provision.IndexName, StringComparison.OrdinalIgnoreCase));
        }
    }
}