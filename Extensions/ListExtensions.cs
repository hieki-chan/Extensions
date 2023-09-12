using System.Collections.Generic;
using UnityEngine;

namespace UnityE.Extensions
{
    public static class ListExtensions
    {
        /// <summary>
        /// Swap an element of the list with another element.
        /// </summary>
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

        /// <summary>
        /// Move element at given index to the end of the list.
        /// </summary>
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

    }
}
