using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC209_A
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("標準入力が空です。");
                return;
            }

            var inputs = input.Split(" ");

            if (inputs.Length != 2)
            {
                Console.WriteLine("標準入力の値の個数が不正です。");
                return;
            }

            if (!inputs.All(x => int.TryParse(x, out var y)))
            {
                Console.WriteLine("標準入力が整数ではありません。");
                return;
            }

            var minNumber = int.Parse(inputs[0]);
            var maxNumber = int.Parse(inputs[1]);

            bool isValid = InputCondition.IsValidNumber(1, 100, minNumber) && InputCondition.IsValidNumber(1, 100, maxNumber);

            if (!isValid)
            {
                Console.WriteLine("標準入力が制約を満たしていません。");
                return;
            }

            var result = (minNumber > maxNumber) ? 0 : maxNumber - minNumber + 1;
            Console.WriteLine(result);

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
