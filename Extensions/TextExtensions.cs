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
        /// Return minutes and seconds format, Ex: 14:03 (my birthday)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetMinsAndSecs(this float value)
        {
            if (value < 0)
                return "00:00";
            TimeSpan time = TimeSpan.FromSeconds(value);
            string z1 = time.Minutes < 10 ? "0" : "";
            string z2 = time.Seconds < 10 ? "0" : "";
            return z1 + time.Minutes + ":" + z2 + time.Seconds;
        }
    }
}
