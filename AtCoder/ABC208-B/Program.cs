using System;
using System.Linq;

namespace ABC208_B
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

            var price = int.Parse(input);

            // 入力値の大小関係に対するチェックを行い、不正であれば終了する
            if (!IsValidNumber(1, (int)Math.Pow(10, 7), price))
            {
                return;
            }

            var max = 10;
            var sumCount = 0;
            var amount = price;

            for (int i = 0; i < max; i++)
            {
                // 10!円硬貨から順に最大何枚支払うことができるかを計算する
                var index = max - i;
                var coinAmount = Factorial(index);

                // 最大何枚支払うことができるかを計算する
                var coinCount = amount / coinAmount;

                // コインの枚数に加算する
                sumCount += coinCount;

                // 残りの金額を計算する
                amount -= coinAmount * coinCount;

                // 残りの金額が0になればそれ以降は計算する必要がないためループを抜ける
                if (amount == 0)
                {
                    break;
                }
            }

            Console.WriteLine(sumCount);

        }

        private static int Factorial(int number) => number == 0 ? 1 : number * Factorial(number - 1);

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
