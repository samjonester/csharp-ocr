namespace OCR.Extensions {
    using System.Collections.Generic;
    using System;

    public static class StringExtensions {
        public static IEnumerable<string> Lines(this string str)
        {
            return new List<string>(
                    str.Split(new string[] { Environment.NewLine }, StringSplitOptions.None)
                );
        }
        public static IEnumerable<string> Partition(this string str, Int32 size) {
            for (int i = 0; i < str.Length; i += size)
                yield return str.Substring(i, size);
        }
    }
}