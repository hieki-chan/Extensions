using UnityEngine;

namespace UnityE.Extensions
{
    public static class ScriptableObjectExtensions
    {
        /// <summary>
        /// Create a new copy
        /// </summary>
        /// <typeparam name="T">ScripableObject type</typeparam>
        /// <param name="scriptableObject">the SO to be copied</param>
        /// <returns>New Copy</returns>
        public static T Clone<T>(this T scriptableObject) where T : ScriptableObject
        {
            if (scriptableObject == null)
            {
                return (T)ScriptableObject.CreateInstance(typeof(T));
            }

            T instance = Object.Instantiate(scriptableObject);
            instance.name = scriptableObject.name;
            return instance;
        }
    }
}
