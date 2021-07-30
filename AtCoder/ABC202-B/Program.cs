using System;
using System.Collections.Generic;
using System.Linq;
namespace ABC202_B
{
    class Program
    {
        static void Main(string[] args)
        {
            // 読み込み
            var input = Console.ReadLine();

            // 入力値に対するチェックを行い、不正であれば終了する
            if (!IsValid(input))
            {
                return;
            }

            // 入力値の文字数に対するチェックを行い、不正であれば終了する
            if (!IsValidNumber(1, Math.Pow(10, 5), Math.Abs(input.Length)))
            {
                return;
            }

            var rotateDic = new Dictionary<string, string>() {
                { "0", "0" },
                { "1", "1" },
                { "6", "9" },
                { "8", "8" },
                { "9", "6" }
            };

            // 標準入力されたものを1文字ずつ取り出したリストを逆順にしたあと変換する
            var rotateList = Enumerable.Range(0, input.Length)
                .Select(i => input[i].ToString())
                .Reverse()
                .Select(x => rotateDic[x]);

            var result = string.Join("", rotateList);

            Console.WriteLine(result);
        }

        private static bool IsValid(string input, int? length = null)
        {
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("標準入力が空です。");
                return false;
            }

            var split = input.Split(" ");

            if (length.HasValue && split.Length != length)
            {
                Console.WriteLine("標準入力の値の個数が不正です。");
                return false;
            }

            return true;
        }

        private static bool IsValidNumber(double minValue, double MaxValue, int value)
        {
            if (!(minValue <= value && value <= MaxValue))
            {
                Console.WriteLine("標準入力が制約の大小関係を満たしていません。");
                return false;

            }
            return true;
        }
    }
}
