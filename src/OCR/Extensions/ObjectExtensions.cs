namespace OCR.Extensions
{
    using System;
    public static class ObjectExtensions
    {
        public static V With<T,V>(this T me, Func<T, V> f) {
            return f(me);
        }
    }
}