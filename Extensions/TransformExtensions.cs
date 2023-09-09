using System;
using UnityEngine;

namespace UnityE.Extensions
{
    public static class TransformExtensions
    {
        /// <summary>
        /// Loop through all child of this <see cref="Transform"/>.
        /// </summary>
        /// <param name="transform">The parent Transform.</param>
        /// <param name="callback">The callback function to be executed for each child Transform.</param>
        public static void ForeachChilds(this Transform transform, Action<Transform> callback)
        {
            int childCount = transform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                Transform child = transform.GetChild(i);
                callback?.Invoke(child);
            }
        }

        /// <summary>
        /// Get an array of child components of type T from the given parent.
        /// </summary>
        /// <typeparam name="T">The type of component to retrieve.</typeparam>
        /// <param name="parent">The parent Transform.</param>
        /// <returns>An array of child components of type T.</returns>
        public static T[] GetChilds<T>(this Transform parent) where T : Component
        {
            int count = parent.childCount;
            T[] result = new T[0];
            for (int i = 0; i < count; i++)
            {
                var t = parent.GetChild(i).GetComponent<T>();
                if (t)
                    result = result.Append(t);
            }
            return result;
        }

        /// <summary>
        /// Get all children of this <see cref="Transform"/>
        /// </summary>
        /// <param name="parent">The parent Transform.</param>
        /// <returns>An array of child Transforms.</returns>
        public static Transform[] GetChilds(this Transform parent)
        {
            int count = parent.childCount;
            Transform[] result = new Transform[0];
            for (int i = 0; i < count; i++)
            {
                result = result.Append(parent.GetChild(i));
            }
            return result;
        }

        /// <summary>
        /// Rotate to target in X and Z axis.
        /// </summary>
        /// <param name="transform">transform to be rotated</param>
        /// <param name="targetPosition">target position</param>
        /// <param name="speed">rotatation speed, this will be multiplied by <see cref="Time.deltaTime"/></param>
        public static void LookAtTarget(this Transform transform, Vector3 targetPosition, float speed = 5.0f)
        {
            Vector3 direction = (targetPosition - transform.position).ToFlat();
            //Look rotation will be zero;
            if (direction == Vector3.zero)
                return;
            Quaternion lookRotation = Quaternion.LookRotation(direction.normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);
        }
    }
}
