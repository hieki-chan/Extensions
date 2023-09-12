using System;
using UnityEngine;

namespace UnityE.Extensions
{
    public static class ConvertExtensions
    {
        /// <summary>
        /// Convert <see cref="int"/> to <see cref="bool"/>
        /// </summary>
        /// <param name="intValue"></param>
        /// <returns>true if int value equals to 1, false if int value equals to 0, 
        /// otherwise throw <see cref="ArgumentException"/></returns>
        public static bool ToBool(this int intValue)
        {
            return intValue == 1 || (intValue == 0 ? false :
                throw new ArgumentException("Convert Int to Bool: Int value must be 0 or 1"));
        }

        /// <summary>
        /// Converts <see cref="string"/> to <see cref="bool"/>
        /// </summary>
        /// <param name="stringValue"></param>
        /// <returns>true if string value is "true", false if string value is "false", 
        /// otherwise throw <see cref="ArgumentException"/></returns>
        public static bool ToBool(this string stringValue)
        {
            return stringValue == "true" || (stringValue == "false" ? false :
                throw new ArgumentException("Convert String to Bool: String value must be \"true\" or \"false\""));
        }

        /// <summary>
        /// Converts <see cref="bool"/> to <see cref="int"/>
        /// </summary>
        /// <param name="boolValue"></param>
        /// <returns><see cref="int"/> value. 1 when true, 0 when false</returns>
        public static int ToInt(this bool boolValue)
        {
            return boolValue ? 1 : 0;
        }

        /// <summary>
        /// Converts <see cref="string"/> to <see cref="int"/>
        /// </summary>
        /// <param name="stringValue"></param>
        /// <returns>int value, 0 if can't convert</returns>
        public static int ToInt(this string stringValue)
        {
            bool result = int.TryParse(stringValue, out int intValue);
            if (result)
                return intValue;
            else
            {
                Debug.Log("Failed to convert string to int, return 0");
                return 0;
            }
        }

        /// <summary>
        /// Converts <see cref="string"/> to <see cref="float"/>
        /// </summary>
        /// <param name="stringValue"></param>
        /// <returns>float value, 0F if can't convert</returns>
        public static float ToFloat(this string stringValue)
        {
            bool result = float.TryParse(stringValue, out float floatValue);
            if (result)
                return floatValue;
            else
            {
                Debug.Log("Failed to convert string to float, return 0F");
                return .0f;
            }
        }
    }
}
