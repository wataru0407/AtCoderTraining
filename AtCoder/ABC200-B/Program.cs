using System;
using System.Linq;
using System.Text;

namespace ABC200_B
{
    class Program
    {
        static void Main(string[] args)
        {
            // 読み込み
            var input = Console.ReadLine();

            // 入力値に対するチェックを行い、不正であれば終了する
            if (!IsValid(input, 2))
            {
                return;
            }

            var numbers = input.Split(" ").Select(x => long.Parse(x));
            long n = numbers.ElementAt(0);
            long k = numbers.ElementAt(1);

            // 入力値の大小関係に対するチェックを行い、不正であれば終了する
            if (!IsValidNumber(1, 100000, n) || !IsValidNumber(1, 20, k))
            {
                return;
            }

            long result = Enumerable.Range(1, (int)k)
                .Aggregate(n, (a, b) => 
                {
                    return a % 200 == 0 ? a / 200 : a * 1000 + 200;
                });

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

            if (!split.All(x => long.TryParse(x, out var y)))
            {
                Console.WriteLine("標準入力が整数ではありません。");
                return false;
            }

            return true;
        }

        private static bool IsValidNumber(long minValue, long MaxValue, long value)
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
