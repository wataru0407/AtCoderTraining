using System;
using System.Linq;

namespace ABC204_B
{
    class Program
    {
        static void Main(string[] args)
        {
            //1行目の読み込み
            var input1 = Console.ReadLine();

            // 入力値に対するチェックを行い、不正であれば終了する
            if (!IsValid(input1, 1))
            {
                return;
            }

            var number = int.Parse(input1);

            // 入力値の大小関係に対するチェックを行い、不正であれば終了する
            if (!IsValidNumber(1, 1000, number))
            {
                return;
            }

            //2行目の読み込み
            var input2 = Console.ReadLine();

            // 入力値に対するチェックを行い、不正であれば終了する
            if (!IsValid(input2, number))
            {
                return;
            }

            var nuts = input2.Split(" ").Select(x => int.Parse(x));

            // 入力値の大小関係に対するチェックを行い、不正であれば終了する
            if (nuts.Any(x => !IsValidNumber(0, 1000, x)))
            {
                return;
            }

            //　収穫する木の実の数を計算する
            var result = nuts.Select(x => x > 10 ? x - 10 : 0).Sum();

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
