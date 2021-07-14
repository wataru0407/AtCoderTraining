using System;
using System.Linq;

namespace ABC209_B
{
    class Program
    {
        static void Main(string[] args)
        {

            // 1行目の標準入力を受け付ける
            var input1 = Console.ReadLine();

            // 1行目の標準入力に対する例外処理
            if (string.IsNullOrEmpty(input1))
            {
                Console.WriteLine("標準入力が空です。");
                return;
            }

            var inputs1 = input1.Split(" ");

            if (inputs1.Length != 2)
            {
                Console.WriteLine("標準入力の値の個数が不正です。");
                return;
            }

            if (!inputs1.All(x => int.TryParse(x, out var y)))
            {
                Console.WriteLine("標準入力が整数ではありません。");
                return;
            }

            // 商品の個数X
            var quantity = int.Parse(inputs1[0]);
            // 所持金X円
            var amount = int.Parse(inputs1[1]);

            bool isValid1 = InputCondition.IsValidNumber(1, 100, quantity) && InputCondition.IsValidNumber(1, 10000, amount);

            if (!isValid1)
            {
                Console.WriteLine("標準入力が制約を満たしていません。");
                return;
            }

            // 2行目の標準入力を受け付ける
            var input2 = Console.ReadLine();

            // 2行目の標準入力に対する例外処理
            if (string.IsNullOrEmpty(input2))
            {
                Console.WriteLine("標準入力が空です。");
                return;
            }

            var inputs2 = input2.Split(" ");

            if (!inputs2.All(x => int.TryParse(x, out var y)))
            {
                Console.WriteLine("標準入力が整数ではありません。");
                return;
            }

            var regularPrice = inputs2.Select(x => int.Parse(x)).ToList();

            bool isValid2 = regularPrice.All(x => InputCondition.IsValidNumber(1, 100, x));

            if (!isValid2)
            {
                Console.WriteLine("標準入力が制約を満たしていません。");
                return;
            }

            // 1円引きの商品の個数は[(売られている商品/2)の小数点以下を切り捨てた値]なのでその分を差し引く
            var price = regularPrice.Sum() - quantity / 2;
            var answer = price > amount ? "No" : "Yes";
            Console.WriteLine(answer);

        }
    }

    /// <summary>
    /// 標準入力の制約を確認するためのクラスです。
    /// </summary>
    public class InputCondition
    {
        /// <summary>
        /// 整数が制約を満たしているか確認します。
        /// </summary>
        /// <param name="minValue">最小値</param>
        /// <param name="minValue">最大値</param>
        /// <param name="value">確認対象の値</param>
        /// <returns></returns>
        public static bool IsValidNumber(int minValue, int MaxValue, int value)
        {
            return minValue <= value && value <= MaxValue;
        }
    }
}
