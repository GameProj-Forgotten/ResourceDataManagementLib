using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ResourceDataManagementLib.Utils
{
    internal static class DataMutiBitSaveFactors
    {
        internal static int MultiBitSaveFactor = 3;


        internal static Tuple<float, float> GetTwoChannelMultiBit(in float targetValue)
        {
            float tempBuffer = (float)((int)(targetValue * Math.Pow(10, MultiBitSaveFactor * 2)) / Math.Pow(10, MultiBitSaveFactor));

            Tuple<float, float> values = new Tuple<float, float>((float)((int)(targetValue * Math.Pow(10, MultiBitSaveFactor)) / Math.Pow(10, MultiBitSaveFactor)),
                                                                 (tempBuffer - (int)tempBuffer));

            return values;
        }

        internal static float GetTwoChannelRestoredValue(in Tuple<float, float> values)
        {
            float reValue = values.Item1 + (values.Item2 / (float)Math.Pow(10, MultiBitSaveFactor));

            return reValue;
        }
    }
}