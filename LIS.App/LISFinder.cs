using System;
using System.Collections.Generic;
using System.Linq;

namespace LIS.App
{
    public static class LISFinder
    {
        public static string Find(string input)
        {
            var numbers = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = numbers.Length;
            var dp = new int[n];
            var prev = new int[n];

            Array.Fill(dp, 1);
            Array.Fill(prev, -1);

            int maxLength = 1;
            int endIndex = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (numbers[j] < numbers[i] && dp[j] + 1 > dp[i])
                    {
                        dp[i] = dp[j] + 1;
                        prev[i] = j;
                    }
                }

                if (dp[i] > maxLength)
                {
                    maxLength = dp[i];
                    endIndex = i;
                }
            }

            var result = new List<int>();
            while (endIndex != -1)
            {
                result.Add(numbers[endIndex]);
                endIndex = prev[endIndex];
            }

            result.Reverse();
            return string.Join(" ", result);
        }
    }
}
