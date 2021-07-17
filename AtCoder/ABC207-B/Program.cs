using System;
using System.Linq;

namespace ABC207_B
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = Console.ReadLine();

            // 入力値に対するチェックを行い、不正であれば終了する
            if (!IsValid(input, 4))
            {
                return;
            }

            var numbers = input.Split(" ").Select(x => int.Parse(x));

            // 入力値の大小関係に対するチェックを行い、不正であれば終了する
            foreach (var number in numbers)
            {
                if (!IsValidNumber(1, (int)Math.Pow(10, 5), number))
                {
                    return;
                }
            }

            var numberA = numbers.ElementAt(0);
            var numberB = numbers.ElementAt(1);
            var numberC = numbers.ElementAt(2);
            var numberD = numbers.ElementAt(3);

            // 操作回数をnとすると A + B * n =< C * n * D を満たすnの最小値が答えとなる
            // A =< (C * D - B) * n で A >= 1 かつ n >= 0 より (C * D - B) > 0 
            var denominator = numberC * numberD - numberB;

            // (C * D - B) <= 0 の場合は答えになるnが存在しない
            if (denominator <= 0)
            {
                Console.WriteLine(-1);
                return;
            }

            // n >= A / (C * D - B) を満たすnの最小値を求める
            var result = (int)(Math.Ceiling((double)numberA / denominator));
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
