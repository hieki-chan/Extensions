using UnityEngine;

namespace UnityE.Extensions
{
    public static class ColorExtensions
    {
        /// <summary>
        /// Converts <see cref="Color"/> to Html format
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static string ColorToHtml(this Color color)
        {
            return "#" + ColorUtility.ToHtmlStringRGB(color);
        }
    }
}
