using System;

namespace Lesson17
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = new string[]
            {
                "The",      // 0                   ^9
                "quick",    // 1                   ^8
                "brown",    // 2                   ^7
                "fox",      // 3                   ^6
                "jumped",   // 4                   ^5
                "over",     // 5                   ^4
                "the",      // 6                   ^3
                "lazy",     // 7                   ^2
                "dog"       // 8                   ^1
            };
            ArrayHelper.Push(ref words, "hello");
            Show(words);
            ArrayHelper.Pop(ref words);
            Show(words);
            ArrayHelper.UnShift(ref words, "Hello");
            Show(words);
            ArrayHelper.Shift(ref words);
            Show(words);
            var arr = ArrayHelper.Slice(words, 2, -3);
            Show(arr);
        }
        static void Show<T>(T[] arr)
        {
            foreach (var item in arr)
            {
                System.Console.WriteLine($"Item : {item}");
            }
            System.Console.WriteLine();
        }
        static class ArrayHelper
        {
            public static T Pop<T>(ref T[] arr)
            {
                if (arr.Length == 0) return default;
                T res = arr[^1];
                T[] resArr = arr[..^1];
                arr = resArr;
                return res;
            }
            public static int Push<T>(ref T[] arr, T item)
            {
                if (arr.Length == 0) return 0;
                Array.Resize<T>(ref arr, arr.Length + 1);
                arr[^1] = item;
                return arr.Length;
            }
            public static T Shift<T>(ref T[] arr)
            {
                if (arr.Length == 0) return default;
                T res = arr[0];
                T[] resArr = arr[1..];
                arr = resArr;
                return res;
            }
            public static int UnShift<T>(ref T[] arr, T item)
            {
                if (arr.Length == 0) return 0;
                T[] resArr = new T[arr.Length + 1];
                Array.ConstrainedCopy(arr, 0, resArr, 1, arr.Length);
                resArr[0] = item;
                arr = resArr;
                return arr.Length;
            }
            public static T[] Slice<T>(T[] arr, int beginIndex, int endIndex = 0)
            {
                if (beginIndex > arr.Length) return new T[0];
                T[] resArr = arr[(beginIndex < 0 ? ^-beginIndex..^0 : endIndex < 0 ? beginIndex..^-endIndex : endIndex > 0 ? beginIndex..endIndex : beginIndex..)];
                return resArr;
            }
        }
    }
}
