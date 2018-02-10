using System;
using Cuemon;

namespace WBPA.Amazon.DynamoDb
{
    internal static class DynamoValidator
    {
        internal static readonly string ValidTableNameCharacters = string.Concat(StringUtility.AlphanumericCharactersCaseSensitive, "_.-");
        internal static readonly string ValidIndexNameCharacters = ValidTableNameCharacters;

        internal static void ThrowIfArnIsNotValid(string arn)
        {
            Validator.ThrowIfNullOrWhitespace(arn, nameof(arn));
            Validator.ThrowIfLowerThan(arn.Length, 1, nameof(arn), "The name of the ARN cannot be less than 1 characters.");
            Validator.ThrowIfGreaterThan(arn.Length, 1283, nameof(arn), "The name of the ARN cannot exceed a length of 1283 characters.");
        }

        internal static void ThrowIfTableNameIsNotValid(string tableName, string paramName = null)
        {
            Validator.ThrowIfNullOrWhitespace(tableName, paramName ?? nameof(tableName));
            Validator.ThrowIfLowerThan(tableName.Length, 3, paramName ?? nameof(tableName), "The name of the table cannot be less than 3 characters.");
            Validator.ThrowIfGreaterThan(tableName.Length, 255, paramName ?? nameof(tableName), "The name of the table cannot exceed a length of 255 characters.");
            if (IsNotValid(ValidTableNameCharacters, tableName)) { throw new ArgumentException("One or more characters in the name are invalid; only alphanumeric characters, underscore (_), hyphen (-), and period (.) are allowed.", paramName ?? nameof(tableName)); }
        }

        internal static void ThrowIfIndexNameIsNotValid(string indexName, string paramName = null)
        {
            Validator.ThrowIfNullOrWhitespace(indexName, paramName ?? nameof(indexName));
            Validator.ThrowIfLowerThan(indexName.Length, 3, paramName ?? nameof(indexName), "The name of the index cannot be less than 3 characters.");
            Validator.ThrowIfGreaterThan(indexName.Length, 255, paramName ?? nameof(indexName), "The name of the index cannot exceed a length of 255 characters.");
            if (IsNotValid(ValidIndexNameCharacters, indexName)) { throw new ArgumentException("One or more characters in the name are invalid; only alphanumeric characters, underscore (_), hyphen (-), and period (.) are allowed.", paramName ?? nameof(indexName)); }
        }

        internal static void ThrowIfAttributeNameIsNotValid(string keyName, string paramName = null)
        {
            Validator.ThrowIfNullOrWhitespace(keyName, paramName ?? nameof(keyName));
            Validator.ThrowIfLowerThan(keyName.Length, 1, paramName ?? nameof(keyName), "The name of the key cannot be less than 1 character.");
            Validator.ThrowIfGreaterThan(keyName.Length, 255, paramName ?? nameof(keyName), "The name of the key cannot exceed a length of 255 characters.");
        }

        internal static void ThrowIfAttributeNameHasInvalidCharacters(string name)
        {
            if (IsNotValid(StringUtility.AlphanumericCharactersCaseSensitive, name)) { throw new ArgumentException("One or more characters in the name are invalid; only alphanumeric characters are allowed.", nameof(name)); }
        }

        public static bool IsNotValid(string validChars, string chars)
        {
            return StringUtility.ParseDistinctDifference(validChars, chars, out _);
        }
    }
}