using System;

namespace ABC196_B
{
    class Program
    {
        static void Main(string[] args)
        {
            // 読み込みを行う
            var input = Console.ReadLine();

            // 入力値に対するチェックを行い、不正であれば終了する
            if (!IsValid(input))
            {
                return;
            }

            var index = input.IndexOf(".");

            // .(小数点)がある場合、その前までを切り出す
            var result = index == -1 ? input : input.Substring(0, index);

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

            if (split.Length != 1)
            {
                Console.WriteLine("標準入力の値の個数が不正です。");
                return false;
            }

            return true;
        }
    }
}
