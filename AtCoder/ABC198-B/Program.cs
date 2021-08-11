using System;
using System.Linq;

namespace ABC198_B
{
    class Program
    {
        static void Main(string[] args)
        {
            // 読み込み
            var input = Console.ReadLine();

            // 入力値に対するチェックを行い、不正であれば終了する
            if (!IsValid(input, 1))
            {
                return;
            }

            var n = int.Parse(input);

            // 入力値の大小関係に対するチェックを行い、不正であれば終了する
            if (!IsValidNumber(0, (int)Math.Pow(10, 9), n))
            {
                return;
            }

            // 0をつけたものを順に調査する。標準入力の長さと同じだけ加えたものまで調査する。
            // 0をつけたものと回分にしたものが一致するものがあるかどうか判定する
            var isReverse = Enumerable.Range(0, input.Length)
                .Select(x => Enumerable.Repeat('0', x).Concat(input))
                .Any(x => x.SequenceEqual(x.Reverse()));

            var result = isReverse ? "Yes" : "No";

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

            if (!split.All(x => int.TryParse(x, out var y)))
            {
                Console.WriteLine("標準入力が整数ではありません。");
                return false;
            }

            return true;
        }

        private static bool IsValidNumber(int minValue, int MaxValue, int value)
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
