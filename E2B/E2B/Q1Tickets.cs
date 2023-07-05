using TestCommon;
using System;
using System.Collections.Generic;

namespace E2
{
    public class Q1Tickets : Processor
    {
        public Q1Tickets(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) => E2Processors.ProcessQ1Tickets(inStr, Solve);

        public string[] Solve(long n, Tuple<string, string>[] tickets)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            Dictionary<string, string> dic_reverse = new Dictionary<string, string>();
            for (int i = 0; i < tickets.Length; i++)
            {
                if (!dic.ContainsKey(tickets[i].Item1))
                {
                    dic.Add(tickets[i].Item1, null);
                    dic_reverse.Add(tickets[i].Item1, null);
                }

                if (!dic.ContainsKey(tickets[i].Item2))
                {
                    dic.Add(tickets[i].Item2, null);
                    dic_reverse.Add(tickets[i].Item2, null);
                }
            }

            foreach (var item in tickets)
            {
                dic[item.Item1] = item.Item2;
                dic_reverse[item.Item2] = item.Item1;
            }

            string start = "";
            foreach (var item in dic_reverse.Keys)
            {
                if (dic_reverse[item] == null)
                {
                    start = item;
                    break;
                }
            }

            List<string> list = new List<string>();
            list.Add(start);
            while (dic[start] != null)
            {
                list.Add(dic[start]);
                start = dic[start];
            }

            return list.ToArray();
        }
    }
}
