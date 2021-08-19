using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ABC197_B
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1行目の読み込みを行う
            var input = Console.ReadLine();

            // 入力値に対するチェックを行い、不正であれば終了する
            if (!IsValid(input, 4))
            {
                return;
            }

            var split = input.Split(" ");

            var h = int.Parse(split[0]);
            var w = int.Parse(split[1]);

            // x, yは配列のindexと合わせるため-1しておく
            var x = int.Parse(split[2]) - 1;
            var y = int.Parse(split[3]) - 1;

            // 入力値の大小関係に対するチェックを行い、不正であれば終了する
            if (!IsValidNumber(1, 100, h) || !IsValidNumber(1, 100, w) || !IsValidNumber(1, h, x + 1) || !IsValidNumber(1, w, y + 1))
            {
                return;
            }


            // 2行目以降の読み込み
            var s = Enumerable.Range(1, h)
                .Select(_ => { return Console.ReadLine(); })
                .ToArray();

            // 文字列の配列の個数、長さと".","#"のみであることのチェックを行い、不正であれば終了する
            if (s.Length != h || !s.All(v => v.Length == w) || !s.All(v => v.All(v => v == '.' || v == '#')))
            {
                Console.WriteLine("障害物の入力が不正です。");
                return;
            }

            // X行目のY列より前に対して、見えるマスの個数を数える
            var beforeY = s[x].Take(y).Reverse().TakeWhile(v => v == '.').Count();

            // X行目のY列より後に対して、見えるマスの個数を数える
            var afterY = s[x].Skip(y + 1).TakeWhile(v => v == '.').Count();


            // Y列目の縦の文字列の配列を作成する
            var row = Enumerable.Range(0, h).Select(v => s[v][y]);

            // Y列目のX行より前に対して、見えるマスの個数を数える
            var beforeX = row.Take(x).Reverse().TakeWhile(v => v == '.').Count();

            // Y列目のX行より後に対して、見えるマスの個数を数える
            var afterX = row.Skip(x + 1).TakeWhile(v => v == '.').Count();

            // 計算した結果とマス(X,Y)自身の1を足し合わせる
            var result = beforeY + afterY + beforeX + afterX + 1;

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
