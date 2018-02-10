using System;
using Cuemon;

namespace WBPA.Amazon.DynamoDb
{
    /// <summary>
    /// Represents an attribute name that is validated according to the rules by AWS.
    /// </summary>
    public class AttributeName
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeName"/> class.
        /// </summary>
        /// <param name="name">The name of the attribute.</param>
        /// <exception cref="ArgumentException">
        /// <paramref name="name"/> must have a length of at least two characters, where the first character must be a colon (:).
        /// - or -
        /// <paramref name="name"/> must begin with a colon (:).
        /// </exception>
        public AttributeName(string name)
        {
            Validator.ThrowIfNullOrWhitespace(name, nameof(name));
            if (name.Length <= 1) { throw new ArgumentException("Value must have a length of at least two characters, where the first character must be a colon (:)."); }
            if (!name.StartsWith(":")) { throw new ArgumentException("Value must begin with a colon (:).", nameof(name)); }
            DynamoValidator.ThrowIfAttributeNameHasInvalidCharacters(name.Substring(1));
            Value = name;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="String"/> to <see cref="AttributeName"/>.
        /// </summary>
        /// <param name="name">The name of the attribute.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator AttributeName(string name)
        {
            return new AttributeName(name);
        }

        /// <summary>
        /// Gets the attribute name.
        /// </summary>
        /// <value>The attribute name.</value>
        public string Value { get; }
    }
}