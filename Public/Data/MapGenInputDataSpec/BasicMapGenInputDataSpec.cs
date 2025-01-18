using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;


namespace ResourceDataManagementLib.MapGeneration.MapGenInputDataSpec
{
    [Flags] public enum MapActiveType : byte
    {
        BIsNodeActive               = 0b0000_0001,

        BIsNodeIsGateToBack         = 0b0000_0010,

        BIsNodeIsTopEdge            = 0b0000_0100,
        BIsNodeIsBottomEdge         = 0b0000_1000,
        BIsNodeIsLeftEdge           = 0b0001_0000,
        BIsNodeIsRightEdge          = 0b0010_0000,

        BIsNodeIsGateBottomEdge     = 0b0100_0000
    }

    public struct BasicMapGenInputDataSpec
    {
        public float MaxTryCountRatio;

        public Tuple<int, int> BrushSize;

        public float MainWayFillPercent, SubWayFillPercent;
        public float PenetratingWayCountRate;
        public float PenetratingWayFillPercent;


        internal static float DefaultMaxTryCountRatio
        {
            get
            {
                return 0.001f;
            }
        }

        internal static Tuple<int, int> DefaultBrushSize
        {
            get
            {
                return new Tuple<int, int>(1, 3);
            }
        }

        internal static float DefaultMainWayFillPercent
        {
            get
            {
                return 0.15f;
            }
        }
        internal static float DefaultSubWayFillPercent
        {
            get
            {
                return 0.25f;
            }
        }
        internal static float DefaultPenetratingWayCountRate
        {
            get
            {
                return 0.001f;
            }
        }
        internal static float DefaultPenetratingWayFillPercent
        {
            get
            {
                return 0.2f;
            }

        }
    }

    public static class BasicMapGenInputDataSpecExtension
    {
        public static void Init(ref this BasicMapGenInputDataSpec inputData)
        {
            inputData.MaxTryCountRatio = BasicMapGenInputDataSpec.DefaultMaxTryCountRatio;

            inputData.BrushSize = BasicMapGenInputDataSpec.DefaultBrushSize;

            inputData.MainWayFillPercent = BasicMapGenInputDataSpec.DefaultMainWayFillPercent;
            inputData.SubWayFillPercent = BasicMapGenInputDataSpec.DefaultSubWayFillPercent;
            inputData.PenetratingWayCountRate = BasicMapGenInputDataSpec.DefaultPenetratingWayCountRate;
            inputData.PenetratingWayFillPercent = BasicMapGenInputDataSpec.DefaultPenetratingWayFillPercent;
        }

        public static bool BIsValid(in this BasicMapGenInputDataSpec inputData)
        {
            if (inputData.MaxTryCountRatio <= 0.0f)
            {
                return false;
            }

            if (inputData.BrushSize.Item1 <= 0 || inputData.BrushSize.Item2 <= 0 || inputData.BrushSize.Item1 > inputData.BrushSize.Item2)
            {
                return false;
            }

            if (inputData.MainWayFillPercent <= 0.0f || inputData.MainWayFillPercent >= 1.0f)
            {
                return false;
            }
            if (inputData.SubWayFillPercent <= 0.0f || inputData.SubWayFillPercent >= 1.0f)
            {
                return false;
            }
            if (inputData.PenetratingWayCountRate <= 0.0f || inputData.PenetratingWayCountRate >= 1.0f)
            {
                return false;
            }
            if (inputData.PenetratingWayFillPercent <= 0.0f || inputData.PenetratingWayFillPercent >= 1.0f)
            {
                return false;
            }

            return true;
        }
    }
}