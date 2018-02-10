using System;
using Cuemon;
using Cuemon.Collections.Generic;

namespace WBPA.Amazon.DynamoDb.Attributes
{
    /// <summary>
    /// Represents a collection of string values that is used to project table attributes to a secondary index and is validated according to the rules by AWS. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="ConditionalCollection{T}" />
    public sealed class NonKeyAttributeCollection : ConditionalCollection<string>
    {
        private const int MaximumCollectionSize = 20;

        /// <summary>
        /// Adds the specified name to this collection.
        /// </summary>
        /// <param name="name">The name of the attribute.</param>
        public override void Add(string name)
        {
            Add(name, () => 
            {
                DynamoValidator.ThrowIfAttributeNameIsNotValid(name, nameof(name));
                if (Contains(name)) { throw new ArgumentException("Name has already been added.", nameof(name)); }
                if (Count >= MaximumCollectionSize) { throw new ArgumentException("Unable to add attribute; cannot exceed a maximum of {0} attributes.".FormatWith(MaximumCollectionSize)); }
            });
        }

        /// <summary>
        /// Determines whether this collection contains the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the attribute.</param>
        /// <returns><c>true</c> if the specified <paramref name="name"/> is contained within this collection; otherwise, <c>false</c>.</returns>
        public override bool Contains(string name)
        {
            return Contains(name, StringComparer.Ordinal);
        }

        /// <summary>
        /// Removes the specified <paramref name="name"/> from this collection.
        /// </summary>
        /// <param name="name">The name of the attribute.</param>
        /// <returns><c>true</c> if the <paramref name="name"/> was removed, <c>false</c> otherwise.</returns>
        public override bool Remove(string name)
        {
            return Remove(name, s => s == name, StringComparer.Ordinal);
        }
    }
}