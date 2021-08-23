using System;
using System.Linq;

namespace ABC196_A
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1行目の読み込み
            var input1 = Console.ReadLine();

            // 入力値に対するチェックを行い、不正であれば終了する
            if (!IsValid(input1))
            {
                return;
            }

            // 2行目の読み込み
            var input2 = Console.ReadLine();

            // 入力値に対するチェックを行い、不正であれば終了する
            if (!IsValid(input2))
            {
                return;
            }

            // x-yの最大値はb-dで計算できる
            var result = int.Parse(input1.Split(" ")[1]) - int.Parse(input2.Split(" ")[0]);

            Console.WriteLine(result);
        }

        private static bool IsValid(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("標準入力が空です。");
                return false;
            }

            var split = input.Split(" ");

            if (split.Length != 2)
            {
                Console.WriteLine("標準入力の値の個数が不正です。");
                return false;
            }

            if (!split.All(x => int.TryParse(x, out var y)))
            {
                Console.WriteLine("標準入力が整数ではありません。");
                return false;
            }

            var numbers = split.Select(x => int.Parse(x)).ToArray();

            if (!numbers.All(x => -100 <= numbers[0] && numbers[0] <= numbers[1] && numbers[1] <= 100))
            {
                Console.WriteLine("標準入力が制約の大小関係を満たしていません。");
                return false;
            }

            return true;
        }

    }
}
