using System;
using System.Linq;
using System.Text;

namespace ABC197_A
{
    class Program
    {
        static void Main(string[] args)
        {
            // 読み込み
            var input = Console.ReadLine();

            // 入力値に対するチェックを行い、不正であれば終了する
            if (!IsValid(input, 1))
            {
                return;
            }

            var result = new StringBuilder();
            result.Append(input[1]);
            result.Append(input[2]);
            result.Append(input[0]);

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

            return true;
        }

    }
}
