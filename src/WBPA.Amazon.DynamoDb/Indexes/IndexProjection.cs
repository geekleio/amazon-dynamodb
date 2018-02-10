using System;
using System.Linq;
using Amazon.DynamoDBv2.Model;
using Cuemon;
using WBPA.Amazon.DynamoDb.Attributes;

namespace WBPA.Amazon.DynamoDb.Indexes
{
    /// <summary>
    /// Represents attributes that are copied (projected) from the table into the index.
    /// </summary>
    public class IndexProjection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndexProjection"/> class.
        /// </summary>
        /// <param name="setup">The <see cref="IndexProjectionOptions" /> which need to be configured.</param>
        public IndexProjection(Action<IndexProjectionOptions> setup = null)
        {
            var options = setup.ConfigureOptions();
            ProjectionType = options.ProjectionType;
            NonKeyAttributes = options.NonKeyAttributes;
        }

        /// <summary>
        /// Gets the type of the projection.
        /// </summary>
        /// <value>The type of the projection.</value>
        public IndexProjectionType ProjectionType { get; }

        /// <summary>
        /// Gets the the non-key attribute names which will be projected into the index.
        /// </summary>
        /// <value>The the non-key attribute names which will be projected into the index.</value>
        public NonKeyAttributeCollection NonKeyAttributes { get; }

        internal Projection ToProjection()
        {
            return new Projection()
            {
                ProjectionType = ProjectionType.ToProjectionType(),
                NonKeyAttributes = NonKeyAttributes.ToList()
            };
        }
    }
}