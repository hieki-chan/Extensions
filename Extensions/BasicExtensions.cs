using System;
using System.Linq;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Object = UnityEngine.Object;
using UnityRandom = UnityEngine.Random;

namespace UnityE.Extensions
{
    public static class BasicExtensions
    {
        #region Text
        public static void CopyToClipboard<T>(this T text) where T : TMP_Text
        {
            TextEditor textEditor = new TextEditor();
            textEditor.text = text.text;
            textEditor.SelectAll();
            textEditor.Copy();
        }

        public static void CopyToClipboard(this string text)
        {
            TextEditor textEditor = new TextEditor();
            textEditor.text = text;
            textEditor.SelectAll();
            textEditor.Copy();
        }

        public static string GetMinsAndSecs(this float value)
        {
            if (value < 0)
                return "00:00";
            TimeSpan time = TimeSpan.FromSeconds(value);
            string z1 = time.Minutes < 10 ? "0" : "";
            string z2 = time.Seconds < 10 ? "0" : "";
            return z1 + time.Minutes + ":" + z2 + time.Seconds;
        }

        #endregion

        #region Array
        public static T[] Append<T>(this T[] array, T item)
        {
            if (array == null)
            {
                return new T[] { item };
            }
            T[] result = new T[array.Length + 1];
            array.CopyTo(result, 0);
            result[array.Length] = item;
            return result;
        }

        public static T[] RemoveAt<T>(this T[] source, int index)
        {
            if (source.Length <= 0)
                return source;
            T[] dest = new T[source.Length - 1];
            if (index > 0)
                Array.Copy(source, 0, dest, 0, index);

            if (index < source.Length - 1)
                Array.Copy(source, index + 1, dest, index, source.Length - index - 1);

            return dest;
        }
        public static T[] Swap<T>(this T[] source, int index1, int index2)
        {
            if (index1 > source.Length - 1 || index2 > source.Length - 1 || index1 < 0 || index2 < 0)
            {
                Debug.Log("Swaping Array: Index is out of range");
                return source;
            }
            var copy = new T[source.Length];
            Array.Copy(source, copy, source.Length);

            T val = copy[index1];
            copy[index1] = copy[index2];
            copy[index2] = val;

            return copy;
        }
        #endregion

        #region List
        public static List<T> Swap<T>(this List<T> source, int index1, int index2)
        {
            if (index1 > source.Count - 1 || index2 > source.Count - 1 || index1 < 0 || index2 < 0)
            {
                Debug.Log("Swaping List: Index is out of range");
                return source;
            }
            var copy = new List<T>(source);

            T val = copy[index1];
            copy[index1] = copy[index2];
            copy[index2] = val;

            return copy;
        }
        public static List<T> SetAsLastIndex<T>(this List<T> source, int index)
        {
            if (index > source.Count - 1 || index < 0)
            {
                Debug.Log("Swaping List: Index is out of range");
                return source;
            }
            var copy = new List<T>(source);

            copy.RemoveAt(index);
            copy.Add(source[index]);

            return copy;
        }
        #endregion

        #region Color
        public static string ColorToHtml(this Color color)
        {
            return "#" + ColorUtility.ToHtmlStringRGB(color);
        }
        #endregion




        public static float Math(this float source, float value, OperationOptions option)
        {
            return (option) switch
            {
                OperationOptions.Change => value,
                OperationOptions.Add => source + value,
                OperationOptions.Subtract => source - value,
                OperationOptions.Multiply => source * value,
                OperationOptions.Divide => source / value,
                _ => -1,
            };
        }

    }
}
