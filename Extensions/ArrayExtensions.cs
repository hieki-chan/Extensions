using System;

namespace UnityE.Extensions
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// Add a new item to the end of the array.
        /// </summary>
        /// <param name="item">new item to add</param>
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

        /// <summary>
        /// Remove an item at given index.
        /// </summary>
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

        /// <summary>
        /// Swap an element of the array with another element.
        /// </summary>
        /// <returns></returns>
        public static T[] Swap<T>(this T[] source, int index1, int index2)
        {
            if (index1 > source.Length - 1 || index2 > source.Length - 1 || index1 < 0 || index2 < 0)
            {
                throw new IndexOutOfRangeException("Swaping Array: Index is out of range");
            }
            var copy = new T[source.Length];
            Array.Copy(source, copy, source.Length);

            T val = copy[index1];
            copy[index1] = copy[index2];
            copy[index2] = val;

            return copy;
        }
    }
}
