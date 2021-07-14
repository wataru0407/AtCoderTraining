using System;
using System.Linq;

namespace ABC209_B
{
    class Program
    {
        static void Main(string[] args)
        {
            var input1 = Console.ReadLine()?.Split(" ")
                .Where(x => int.TryParse(x, out var y))
                .Select(x => int.Parse(x)).ToArray();
            var input2 = Console.ReadLine()?.Split(" ")
                .Where(x => int.TryParse(x, out var y))
                .Select(x => int.Parse(x)).ToArray();

            if (input1.Length != 2)
            {
                Console.WriteLine("標準入力の値が不正です。");
                return;
            }

            var quantity = input1[0]; // 商品の個数X
            var amount = input1[1]; // 所持金X円

            bool isValid = InputCondition.IsValidNumber(1, 100, quantity)
                && InputCondition.IsValidNumber(1, 10000, amount)
                && input2.All(x => InputCondition.IsValidNumber(1, 100, x));

            if (!isValid)
            {
                Console.WriteLine("制約を満たしていません。");
                return;
            }

            // 1円引きの商品の個数は[(売られている商品/2)の小数点以下を切り捨てた値]なのでその分を差し引く
            var price = input2.Sum() - quantity / 2;
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
