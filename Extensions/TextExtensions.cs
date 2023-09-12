using System;
using UnityEngine;

namespace UnityE.Extensions
{
    public static class TextExtensions
    {
        /// <summary>
        /// Copy text to clipboard
        /// </summary>
        public static void CopyToClipboard(this string text)
        {
            TextEditor textEditor = new TextEditor();
            textEditor.text = text;
            textEditor.SelectAll();
            textEditor.Copy();
        }

        /// <summary>
        /// Return hours: minutes: seconds format from second, Ex: 14:03:25 (my birthday)
        /// </summary>
        public static string ToHMSFormat(this float value)
        {
            if (value < 0)
                return "00:00:00";
            TimeSpan time = TimeSpan.FromSeconds(value);
            string h = time.Hours < 10 ? "0" : "";
            string m = time.Minutes < 10 ? "0" : "";
            string s = time.Seconds < 10 ? "0" : "";
            return h + time.Hours + ":" + m + time.Minutes + ":" + s + time.Seconds;
        }
    }
}
