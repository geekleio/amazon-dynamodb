using System;
using Cuemon;
using Cuemon.Collections.Generic;

namespace WBPA.Amazon.DynamoDb.Indexes
{
    /// <summary>
    /// Represents a collection of <see cref="SecondaryIndex"/> objects that is validated according to the rules by AWS.
    /// </summary>
    /// <typeparam name="T">The type of the <see cref="SecondaryIndex"/>.</typeparam>
    /// <seealso cref="ConditionalCollection{T}" />
    public class SecondaryIndexCollection<T> : ConditionalCollection<T> where T : SecondaryIndex
    {
        private const int MaximumCollectionSize = 5;

        /// <summary>
        /// Adds an item to the <see cref="SecondaryIndexCollection{T}"/>.
        /// </summary>
        /// <param name="index">The <see cref="SecondaryIndex"/> to add to the <see cref="SecondaryIndexCollection{T}"/>.</param>
        public override void Add(T index)
        {
            Add(index, () =>
            {
                if (Count >= MaximumCollectionSize) { throw new ArgumentException("Unable to add index; cannot exceed a maximum of {0} indexes.".FormatWith(MaximumCollectionSize)); }
            });
        }

        /// <summary>
        /// Determines whether the <see cref="SecondaryIndexCollection{T}" /> contains a specific value.
        /// </summary>
        /// <param name="index">The <see cref="SecondaryIndex"/> to locate in the <see cref="SecondaryIndexCollection{T}" />.</param>
        /// <returns><c>true</c> if <paramref name="index" /> is found in the <see cref="SecondaryIndexCollection{T}" />; otherwise, <c>false</c>.</returns>
        public override bool Contains(T index)
        {
            return Contains(index, DynamicEqualityComparer.Create<SecondaryIndex>(ix => ix.IndexName.GetHashCode(), (i1, i2) => i1.IndexName.GetHashCode() == i2.IndexName.GetHashCode()));
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="SecondaryIndexCollection{T}" />.
        /// </summary>
        /// <param name="index">The object to remove from the <see cref="SecondaryIndexCollection{T}" />.</param>
        /// <returns><c>true</c> if <paramref name="index" /> was successfully removed from the <see cref="SecondaryIndexCollection{T}" />; otherwise, <c>false</c>.</returns>
        public override bool Remove(T index)
        {
            return Remove(index, ix => ix.IndexName.Equals(index.IndexName, StringComparison.OrdinalIgnoreCase));
        }
    }
}