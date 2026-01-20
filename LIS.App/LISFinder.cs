using System;
using System.Collections.Generic;
using System.Linq;

namespace LIS.App
{
    public static class LISFinder
    {
        public static string Find(string input)
        {
           
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            var numbers = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

          
            if (numbers.Length == 0)
                return string.Empty;

            if (numbers.Length == 1)
                return numbers[0].ToString();

            int n = numbers.Length;
            var dp = new int[n];
            var prev = new int[n];

            Array.Fill(dp, 1);
            Array.Fill(prev, -1);

            int maxLength = 1;
            int endIndex = 0;

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (numbers[j] < numbers[i] && dp[j] + 1 > dp[i])
                    {
                        dp[i] = dp[j] + 1;
                        prev[i] = j;
                    }
                }

                // earliest sequence preserved
                if (dp[i] > maxLength)
                {
                    maxLength = dp[i];
                    endIndex = i;
                }
            }

            var lis = new List<int>();
            while (endIndex != -1)
            {
                lis.Add(numbers[endIndex]);
                endIndex = prev[endIndex];
            }

            lis.Reverse();
            return string.Join(" ", lis);
        }
    }
}
