using System;
using System.Linq;

namespace ABC206_B
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            // 入力値に対するチェックを行い、不正であれば終了する
            if (!IsValid(input))
            {
                return;
            }

            int amount = int.Parse(input);

            // 入力値の大小関係に対するチェックを行い、不正であれば終了する
            if (!IsValidNumber(1, (int)Math.Pow(10, 9), amount))
            {
                return;
            }

            // ある程度何日後にNを超えるか見積もる
            // i日目の貯金額の合計は i(i+1)/2 であるため i(i+1)/2 >= N とすると
            // 2N <= i(i+1) < (i+1)^2 より sqrt(2N) < i+1 => i > sqrt(2N)-1

            int number = (int)(Math.Sqrt(amount * 2) - 1);
            int sum = number * (number + 1) / 2;
            while (sum < amount)
            {
                number++;
                sum = number * (number + 1) / 2;
            }

            Console.WriteLine(number);
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
