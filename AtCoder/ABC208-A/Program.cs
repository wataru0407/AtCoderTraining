using System;
using System.Linq;

namespace ABC208_A
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            // 入力値に対するチェックを行い、不正であれば終了する
            if (!IsValid(input, 2))
            {
                return;
            }

            var split = input.Split(" ");
            var count = int.Parse(split[0]);
            var sum = int.Parse(split[1]);

            // 入力値の大小関係に対するチェックを行い、不正であれば終了する
            if (!IsValidNumber(1, 100, count) || !IsValidNumber(1, 1000, sum))
            {
                return;
            }

            // 全て6の場合でも合計値に満たない場合、もしくは全て1の場合でも合計を超えてしまう場合はNo
            if (count * 6 < sum || count > sum)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine("Yes");
            }
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
