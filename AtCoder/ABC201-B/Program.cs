using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC201_B
{
    class Program
    {
        static void Main(string[] args)
        {
            // 読み込み
            var input = Console.ReadLine();

            // 入力値に対するチェックを行い、不正であれば終了する
            if (!IsValidNumber(input))
            {
                return;
            }

            var n = int.Parse(input);

            // N個分のデータを読み込む
            var mountainDic = Enumerable.Range(1, n)
                .Select(x => { 
                    var input3 = Console.ReadLine();
                    var st = input3.Split(" ");
                    return new { name = st[0], height = int.Parse(st[1])};
                })
                .ToDictionary(x => x.name, x => x.height);

            // 高い順に並び替えて2番目を取得する
            var result = mountainDic.OrderByDescending(x => x.Value).ElementAt(1);

            Console.WriteLine(result.Key);
        }

        private static bool IsValidNumber(string input)
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

            var n = int.Parse(input);

            if (!(2 <= n && n <= 1000))
            {
                Console.WriteLine("標準入力が制約の大小関係を満たしていません。");
                return false;
            }

            return true;
        }
    }
}
