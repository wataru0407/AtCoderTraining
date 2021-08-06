using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC199_B
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1行目の読み込み
            var input1 = Console.ReadLine();

            // 入力値に対するチェックを行い、不正であれば終了する
            if (!IsValid(input1, 1))
            {
                return;
            }

            var n = int.Parse(input1);

            // 入力値の大小関係に対するチェックを行い、不正であれば終了する
            if (!IsValidNumber(1, 100, n))
            {
                return;
            }

            // 2行目の読み込み
            var input2 = Console.ReadLine();

            // 入力値に対するチェックを行い、不正であれば終了する
            if (!IsValid(input2, n))
            {
                return;
            }

            // 3行目の読み込み
            var input3 = Console.ReadLine();

            // 入力値に対するチェックを行い、不正であれば終了する
            if (!IsValid(input3, n))
            {
                return;
            }

            var an = input2.Split(" ").Select(x => int.Parse(x));
            var bn = input3.Split(" ").Select(x => int.Parse(x));

            // 2、3行目の入力値の大小関係に対するチェックを行い、不正であれば終了する
            if (!IsValidNumber(1, 1000, an, bn))
            {
                return;
            }

            // 整数xの条件は(数列Aの最大値 <= x <= 数列Bの最小値)と言い換えられるため、以下の処理で計算する
            var result = Enumerable.Range(1, 1000)
                .Count(x => an.Max() <= x && x <= bn.Min());

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

        private static bool IsValidNumber(int minValue, int MaxValue, IEnumerable<int> an, IEnumerable<int> bn)
        {
            bool isValid = an
                .Zip(bn, (a, b) => new {a, b})
                .All(x => minValue <= x.a && x.a <= x.b && x.b <= MaxValue);

            if (!isValid)
            {
                Console.WriteLine("標準入力が制約の大小関係を満たしていません。");
                return false;

            }
            return true;
        }
    }
}
