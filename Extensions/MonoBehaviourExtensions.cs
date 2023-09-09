using UnityEngine;

namespace UnityE.Extensions
{
    public static class MonoBehaviourExtensions
    {
        /// <summary>
        /// Activates/Deactivates the MonoBehaviour
        /// </summary>
        /// <param name="monoBehaviour"></param>
        /// <param name="value"></param>
        public static void SetActive(this MonoBehaviour monoBehaviour, bool value)
        {
            monoBehaviour.gameObject.SetActive(value);
        }
    }
}
