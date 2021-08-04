using System;

namespace ABC200_A
{
    class Program
    {
        static void Main(string[] args)
        {
            // 読み込み
            var input = Console.ReadLine();

            // 入力値に対するチェックを行い、不正であれば終了する
            if (!IsValid(input, 1, 3000))
            {
                return;
            }

            int value = int.Parse(input);
            int result = (value / 100) + (value % 100 == 0 ? 0 : 1);

            Console.WriteLine(result);
        }

        private static bool IsValid(string input, int minValue, int MaxValue)
        {
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("標準入力が空です。");
                return false;
            }

            if (!int.TryParse(input, out var y))
            {
                Console.WriteLine("標準入力が整数ではありません。");
                return false;
            }

            var value = int.Parse(input);

            if (!(minValue <= value && value <= MaxValue))
            {
                Console.WriteLine("標準入力が制約の大小関係を満たしていません。");
                return false;

            }

            return true;
        }
    }
}
