using System;
using System.Linq;

namespace ABC206_A
{
    class Program
    {
        private const decimal tax = 1.08m;
        private const decimal regularPrice = 206m;

        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            // 入力値に対するチェックを行い、不正であれば終了する
            if (!IsValid(input))
            {
                return;
            }

            int price = int.Parse(input);

            // 入力値の大小関係に対するチェックを行い、不正であれば終了する
            if (!IsValidNumber(1, 300, price))
            {
                return;
            }

            decimal taxExcludedPrice = Convert.ToDecimal(price);
            decimal taxIncludedPrice = Math.Floor(taxExcludedPrice * tax);

            if (taxIncludedPrice < regularPrice)
            {
                Console.WriteLine("Yay!");
            }
            else if (taxIncludedPrice == regularPrice)
            {
                Console.WriteLine("so-so");
            }
            else
            {
                Console.WriteLine(":(");
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
