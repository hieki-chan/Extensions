using System;
using System.Collections.Generic;
using System.Linq;
using SystemRandom = System.Random;

namespace UnityE.Extensions
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Add an item.
        /// </summary>
        public static IEnumerable<T> Add<T>(this IEnumerable<T> enumerable, T value)
        {
            foreach (var item in enumerable)
                yield return item;

            yield return value;
            /*Linq
             * return enumerable.Concat(new T[] { value });*/
        }

        /// <summary>
        /// Remove an item by given index.
        /// </summary>
        public static IEnumerable<T> Remove<T>(this IEnumerable<T> enumerable, int index)
        {
            int current = 0;
            foreach (var item in enumerable)
            {
                if (current != index)
                    yield return item;

                current++;
            }
            /*Linq
             * enumerable.Where((item, i) => i != index);
             */
        }

        /// <summary>
        /// Remove an item based on given item.
        /// </summary>
        public static IEnumerable<T> Remove<T>(this IEnumerable<T> enumerable, T value)
        {
            foreach (var item in enumerable)
            {
                if (!item.Equals(value))
                    yield return item;
            }
        }

        /// <summary>
        /// Insert an item.
        /// </summary>
        public static IEnumerable<T> Insert<T>(this IEnumerable<T> enumerable, T value, int index)
        {
            int current = 0;
            foreach (var item in enumerable)
            {
                if (current == index)
                    yield return value;
                yield return item;
                current++;
            }
        }

        /// <summary>
        /// Replace an item by another item.
        /// </summary>
        public static IEnumerable<T> Replace<T>(this IEnumerable<T> enumerable, T value, int index)
        {
            int current = 0;
            foreach (var item in enumerable)
            {
                if (current == index)
                    yield return value;
                else
                    yield return item;
                current++;
            }
        }

        /// <summary>
        /// loop through.
        /// </summary>
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T, int> action)
        {
            int current = 0;
            foreach (var item in enumerable)
            {
                action?.Invoke(item, current);
                current++;
            }
        }

        /// <summary>
        /// Shuffle the <see cref="IEnumerable{T}"/> in place.
        /// </summary>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> enumerable)
        {
            SystemRandom random = new SystemRandom();
            var buffer = enumerable.ToArray();
            int count = buffer.Length;

            for (int i = 0; i < count; i++)
            {
                int j = random.Next(0, count);
                yield return buffer[j];

                buffer[j] = buffer[i];
            }
        }
    }
}