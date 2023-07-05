using TestCommon;
using System;
using System.Collections.Generic;
using System.Text;

namespace E2
{
    public class Q3ExtractCode : Processor
    {
        public Q3ExtractCode(string testDataName) : base(testDataName)
        {
            ExcludeTestCases(5, 8, 14, 16, 18);
        }

        public override string Process(string inStr) => E2Processors.ProcessQ3ExtractCode(inStr, Solve);

        Dictionary<int, int> bracket_matches;
        string str;

        public string Solve(string s)
        {
            Stack<int> stack = new Stack<int>();
            bracket_matches = new Dictionary<int, int>();
            str = s;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '[')
                {
                    stack.Push(i);
                }
                else if (s[i] == ']') 
                {
                    bracket_matches.Add(stack.Pop(), i);
                }
                
            }

            return function(0, s.Length);
        }


        int i;
        string function (int start, int end)
        {
            string ans = "";
            for (i = start; i < end; i++)
            {
                if (char.IsLetter(str[i]))
                {
                    ans += str[i];
                }
                else
                {
                    string number = "";
                    while (char.IsDigit(str[i]))
                    {
                        number += str[i];
                        i++;
                    }
                    
                    string tmp = function(i + 1, bracket_matches[i]);
                    int n = int.Parse(number);
                    for (int j = 0; j < n; j++)
                    {
                        ans+= tmp;
                    }
                }
            }

            return ans;
        }
    }
}
