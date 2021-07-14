using System;
using System.Linq;

namespace ABC209_A
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()?.Split(" ")
                .Where(x => int.TryParse(x, out var y))
                .Select(x => int.Parse(x)).ToArray();

            if(input.Length != 2)
            {
                Console.WriteLine("標準入力の値が不正です。");
                return;
            }

            var minNumber = input[0];
            var maxNumber = input[1];

            bool isValid = InputCondition.IsValidNumber(0, 100, minNumber) && InputCondition.IsValidNumber(0, 100, maxNumber);

            if (!isValid)
            {
                Console.WriteLine("制約を満たしていません。");
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
