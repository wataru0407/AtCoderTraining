using System;
using System.Linq;

namespace ABC207_A
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            // 入力値に対するチェックを行い、不正であれば終了する
            if (!IsValid(input, 3))
            {
                return;
            }

            var numbers = input.Split(" ").Select(x => int.Parse(x));

            // 入力値の大小関係に対するチェックを行い、不正であれば終了する
            foreach (var number in numbers)
            {
                if (!IsValidNumber(1, 100, number))
                {
                    return;
                }
            }

            // 大きい数値から順に2つを足したものが和も最大となる
            var result = numbers.OrderByDescending(x => x).Take(2).Sum();

            Console.WriteLine(result);
        }

        private static bool IsValid(string input, int length = 1)
        {
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("標準入力が空です。");
                return false;
            }

            var split = input.Split(" ");

            if (split.Length != length)
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
