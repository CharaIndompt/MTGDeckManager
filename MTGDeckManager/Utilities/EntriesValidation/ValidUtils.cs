using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckManager.Utilities.EntriesValidation
{
    public static class ValidUtils
    {
        /// <summary>
        /// Check if a string is valid for description (minimum length)
        /// </summary>
        public static bool CheckEntryDescription(string value, int minLength)
        {
            return !string.IsNullOrEmpty(value) && value.Length >= minLength;
        }

        /// <summary>
        /// Check if a number is positive
        /// </summary>
        public static bool CheckIfPositiveNumber(int value)
        {
            return value > 0;
        }

        /// <summary>
        /// Check if a double is positive
        /// </summary>
        public static bool CheckIfPositiveNumber(double value)
        {
            return value >= 0;
        }

        /// <summary>
        /// Check if value is in range
        /// </summary>
        public static bool IsInRange(double value, double min)
        {
            return value >= min;
        }

        /// <summary>
        /// Check file format extension
        /// </summary>
        public static bool CheckFileFormat(string fileName, string[] allowedFormats)
        {
            if (string.IsNullOrEmpty(fileName))
                return false;

            string extension = System.IO.Path.GetExtension(fileName).ToLower().TrimStart('.');
            return allowedFormats.Any(f => f.ToLower() == extension);
        }
    }
}
