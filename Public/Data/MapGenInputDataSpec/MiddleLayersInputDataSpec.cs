using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;


namespace ResourceDataManagementLib.MapGeneration.MapGenInputDataSpec
{
    public struct MiddleLayersInputDataSpec
    {
        public int CurLayerMiddleLayerDepth;

        public Color ColorStepForCurLayer;


        internal static int DefaultCurLayerMiddleLayerDepth
        {
            get
            {
                return 2;
            }
        }
        internal static Color DefaultColorStepForCurLayer
        {
            get
            {
                return new Color(0.1f, 0.1f, 0.1f, 0.0f);
            }
        }
    }

    public static class MiddleLayersInputDataSpecExtension
    {
        public static void Init(ref this MiddleLayersInputDataSpec inputData)
        {
            inputData.CurLayerMiddleLayerDepth = MiddleLayersInputDataSpec.DefaultCurLayerMiddleLayerDepth;

            inputData.ColorStepForCurLayer = MiddleLayersInputDataSpec.DefaultColorStepForCurLayer;
        }

        public static bool BIsValid(in this MiddleLayersInputDataSpec inputData)
        {
            if(inputData.CurLayerMiddleLayerDepth <= 0)
            {
                return false;
            }

            if (inputData.ColorStepForCurLayer.a > 0.0f)
            {
                return false;
            }

            return true;
        }
    }
}