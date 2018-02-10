using Amazon.DynamoDBv2;
using WBPA.Amazon.Attributes;
using WBPA.Amazon.DynamoDb.Indexes;

namespace WBPA.Amazon.DynamoDb
{
    /// <summary>
    /// Extension methods for the DynamoDB related enum value types.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Converts the specified <paramref name="value"/> to its equivalent <see cref="ReturnConsumedCapacity"/>.
        /// </summary>
        /// <param name="value">The enum value type to convert.</param>
        /// <returns>An instance of <see cref="ReturnConsumedCapacity"/>.</returns>
        public static ReturnConsumedCapacity ToReturnConsumedCapacity(this ConsumedCapacityResponse value)
        {
            switch (value)
            {
                case ConsumedCapacityResponse.Indexes:
                    return ReturnConsumedCapacity.INDEXES;
                case ConsumedCapacityResponse.Total:
                    return ReturnConsumedCapacity.TOTAL;
                default:
                    return ReturnConsumedCapacity.NONE;
            }
        }

        /// <summary>
        /// Converts the specified <paramref name="value"/> to its equivalent <see cref="ProjectionType"/>.
        /// </summary>
        /// <param name="value">The enum value type to convert.</param>
        /// <returns>An instance of <see cref="ProjectionType"/>.</returns>
        public static ProjectionType ToProjectionType(this IndexProjectionType value)
        {
            switch (value)
            {
                case IndexProjectionType.Include:
                    return ProjectionType.INCLUDE;
                case IndexProjectionType.KeysOnly:
                    return ProjectionType.KEYS_ONLY;
                default:
                    return ProjectionType.ALL;
            }
        }

        /// <summary>
        /// Converts the specified <paramref name="value"/> to its equivalent <see cref="ReturnItemCollectionMetrics"/>.
        /// </summary>
        /// <param name="value">The enum value type to convert.</param>
        /// <returns>An instance of <see cref="ReturnItemCollectionMetrics"/>.</returns>
        public static ReturnItemCollectionMetrics ToReturnItemCollectionMetrics(this TableItemResponseMetrics value)
        {
            switch (value)
            {
                case TableItemResponseMetrics.Size:
                    return ReturnItemCollectionMetrics.SIZE;
            }
            return ReturnItemCollectionMetrics.NONE;
        }

        /// <summary>
        /// Converts the specified <paramref name="value"/> and <paramref name="operation"/> to its equivalent <see cref="Select"/>.
        /// </summary>
        /// <param name="value">The enum value type to convert.</param>
        /// <param name="operation">The enum value type to convert.</param>
        /// <returns>An instance of <see cref="ReturnValue"/>.</returns>
        public static ReturnValue ToReturnValue(this TableItemResponseAttributes value, TableItemOperation operation)
        {
            switch (operation)
            {
                case TableItemOperation.Create:
                case TableItemOperation.Delete:
                    if (value == TableItemResponseAttributes.AllOld) { return ToReturnValue(value); }
                    break;
                case TableItemOperation.Update:
                    return ToReturnValue(value);
            }
            return ReturnValue.NONE;
        }

        /// <summary>
        /// Converts the specified <paramref name="value"/> to its equivalent <see cref="ReturnValue"/>.
        /// </summary>
        /// <param name="value">The enum value type to convert.</param>
        /// <returns>An instance of <see cref="ReturnValue"/>.</returns>
        private static ReturnValue ToReturnValue(TableItemResponseAttributes value)
        {
            switch (value)
            {
                case TableItemResponseAttributes.AllOld:
                    return ReturnValue.ALL_OLD;
                case TableItemResponseAttributes.AllNew:
                    return ReturnValue.ALL_NEW;
                case TableItemResponseAttributes.UpdatedNew:
                    return ReturnValue.UPDATED_NEW;
                case TableItemResponseAttributes.UpdatedOld:
                    return ReturnValue.UPDATED_OLD;
            }
            return ReturnValue.NONE;
        }

        /// <summary>
        /// Converts the specified <paramref name="value"/> to its equivalent <see cref="ScalarAttributeType"/>.
        /// </summary>
        /// <param name="value">The enum value type to convert.</param>
        /// <returns>An instance of <see cref="ScalarAttributeType"/>.</returns>
        public static ScalarAttributeType ToScalarAttributeType(this AttributeType value)
        {
            switch (value)
            {
                case AttributeType.Binary:
                    return ScalarAttributeType.B;
                case AttributeType.Number:
                    return ScalarAttributeType.N;
                default:
                    return ScalarAttributeType.S;
            }
        }

        /// <summary>
        /// Converts the specified <paramref name="value"/> to its equivalent <see cref="Select"/>.
        /// </summary>
        /// <param name="value">The enum value type to convert.</param>
        /// <returns>An instance of <see cref="Select"/>.</returns>
        public static Select ToSelect(this SelectItemAttributes value)
        {
            switch (value)
            {
                case SelectItemAttributes.AllProjected:
                    return Select.ALL_PROJECTED_ATTRIBUTES;
                case SelectItemAttributes.Count:
                    return Select.COUNT;
                case SelectItemAttributes.Specific:
                    return Select.SPECIFIC_ATTRIBUTES;
                default:
                    return Select.ALL_ATTRIBUTES;
            }
        }
    }
}