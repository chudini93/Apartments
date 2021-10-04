using System;
using System.Collections.Generic;
using System.Globalization;
using Stretto.ConsoleApp.Dictionaries;
using Stretto.ConsoleApp.Exceptions;

namespace Stretto.ConsoleApp.Extensions
{
    public static class StringExtensions
    {
        public static string ToStateName(this string value, bool throwException = true)
        {
            string state = StatesDictionary.GetStateByNameOrAbbreviation(value);
            if (string.IsNullOrWhiteSpace(state))
            {
                if (throwException)
                    throw new InvalidStateException($"Value: {value} is invalid state");
            }

            return state;
        }

        /// <summary>
        /// Parses <see cref="value"/> to <see cref="DateTime"/> in supported formats.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string value)
        {
            var supportedFormats = new[] { "ddd MMM dd hh:mm:ss zzz yyyy" };

            try
            {
                value = value.ReplaceTimezoneNameToTimezoneOffset();
                DateTime output = DateTime.ParseExact(value, supportedFormats, null, DateTimeStyles.None);
                return output;
            }
            catch (Exception)
            {
                throw new InvalidCastException($"Could not cast {value} to DateTime.");
            }
        }

        /// <summary>
        /// Replaces timezone name with timezone offset for ex. EDT => -04:00.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ReplaceTimezoneNameToTimezoneOffset(this string value)
        {
            string output = value;

            foreach (KeyValuePair<string, string> tzPair in TimezonesDictionary.TimezoneOffsets)
            {
                if (value.Contains(tzPair.Key))
                    output = value.Replace(tzPair.Key, tzPair.Value);
            }

            return output;
        }
    }
}
