using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q2MaximizingLoot : Processor
    {
        public Q2MaximizingLoot(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);


        public virtual long Solve(long capacity, long[] weights, long[] values)
        {
            long value = 0;
            //cout << "capacity = " << capacity << "\n";
            if (capacity == 0)
            {
                return 0;
            }

            long max_val = -1;
            double density = -1;
            double max_density = -1;
            int max_val_index = -1;
            for (int i = 0; i < values.Length; i++)
            {   
                density = (double)(values[i]) / weights[i];
                if (density > 0 && max_density < density)
                {
                    max_val = values[i];
                    max_val_index = i;
                    max_density = density;
                }
            }
            /*cout << "max_val = " << max_val << "\n";
            cout << "====================================" << '\n'*/;
            if (max_val == -1)
            {
                return 0;
            }
    
            long taken_weight = Math.Min(capacity, weights[max_val_index]);
            value = (long)((double)taken_weight / (weights[max_val_index]) * max_val);
            weights[max_val_index] = -1;
            return value + Solve(capacity - taken_weight, weights, values);
        }


        public override Action<string, string> Verifier { get; set; } =
            TestTools.ApproximateLongVerifier;

    }
}
