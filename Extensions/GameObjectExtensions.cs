using System;
using System.Linq;
using UnityEngine;

namespace UnityE.Extensions
{
    public static class GameObjectExtensions
    {
        public static T GetComponentInChildrenExcludeParent<T>(this GameObject obj, bool includeInactive = false) where T : Component
        {
            var components = obj.GetComponentsInChildren<T>(includeInactive);

            return components.FirstOrDefault(childComponent =>
                childComponent.transform != obj.transform);
        }
        public static void ForeachChilds(this Transform transform, Action<Transform> callback)
        {
            int childCount = transform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                Transform child = transform.GetChild(i);
                callback?.Invoke(child);
            }
        }
    }
}
