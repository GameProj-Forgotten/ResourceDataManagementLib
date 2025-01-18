using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

using ResourceDataManagementLib.SerializableType;


namespace ResourceDataManagementLib.MapGeneration.MapGenInputDataSpec
{
    public struct RegionSelectionInputDataSpec
    {
        public struct SingleRegionData
        {
            public string RegionName;
            public Guid RegionID;

            public Color RegionBlendColor;

            public SerializableVector3 IdealSpawnPos;
            public SerializableVector3 DirectionWeight;


            internal static string DefaultSingleRegionName
            {
                get
                {
                    return "SingleRegionData_";
                }
            }

            internal static Color DefaultRegionBlendColor
            {
                get
                {
                    return Color.grey;
                }
            }

            internal static SerializableVector3 DefaultIdealSpawnPos
            {
                get
                {
                    return SerializableVector3.zero;
                }
            }
            internal static SerializableVector3 DefaultDirectionWeight
            {
                get
                {
                    return SerializableVector3.one;
                }
            }
        }


        public Color BaseColor;

        public List<SingleRegionData> SingleRegionDatas;


        internal static Color DefaultBaseColor
        {
            get
            {
                return Color.white;
            }
        }
        internal static int MaxRegionCount
        {
            get
            {
                return AbstractInputDataSpec.MaxAreaCount;
            }
        }
    }

    public static class RegionSelectionInputDataSpecExtension
    {
        public static void Init(ref this RegionSelectionInputDataSpec inputData)
        {
            inputData.BaseColor = RegionSelectionInputDataSpec.DefaultBaseColor;

            inputData.SingleRegionDatas = new List<RegionSelectionInputDataSpec.SingleRegionData>();
        }

        public static bool BIsValid(in this RegionSelectionInputDataSpec inputData)
        {
            if (inputData.SingleRegionDatas.Count <= 0)
            {
                return false;
            }
            if (inputData.SingleRegionDatas.Count > RegionSelectionInputDataSpec.MaxRegionCount)
            {
                return false;
            }

            if (inputData.BaseColor == Color.clear)
            {
                return false;
            }

            if (inputData.SingleRegionDatas.Any(singleRegionData => !singleRegionData.BIsValid()))
            {
                return false;
            }

            return true;
        }
    }

    internal static class SingleRegionDataExtension
    {
        internal static void Init(ref this RegionSelectionInputDataSpec.SingleRegionData singleRegionData)
        {
            singleRegionData.RegionName = RegionSelectionInputDataSpec.SingleRegionData.DefaultSingleRegionName + UnityEngine.Random.Range(0, int.MaxValue);
            singleRegionData.RegionID = Guid.NewGuid();

            singleRegionData.RegionBlendColor = RegionSelectionInputDataSpec.SingleRegionData.DefaultRegionBlendColor;

            singleRegionData.IdealSpawnPos = RegionSelectionInputDataSpec.SingleRegionData.DefaultIdealSpawnPos;
            singleRegionData.DirectionWeight = RegionSelectionInputDataSpec.SingleRegionData.DefaultDirectionWeight;
        }

        internal static bool BIsValid(in this RegionSelectionInputDataSpec.SingleRegionData singleRegionData)
        {
            if (string.IsNullOrEmpty(singleRegionData.RegionName))
            {
                return false;
            }
            if (singleRegionData.RegionID == Guid.Empty)
            {
                return false;
            }

            if (singleRegionData.RegionBlendColor == Color.clear)
            {
                return false;
            }

            if (singleRegionData.IdealSpawnPos.X < 0.0f || singleRegionData.IdealSpawnPos.Y < 0.0f || singleRegionData.IdealSpawnPos.Z < 0.0f ||
                singleRegionData.IdealSpawnPos.X > 1.0f || singleRegionData.IdealSpawnPos.Y > 1.0f || singleRegionData.IdealSpawnPos.Z > 1.0f)
            {
                return false;
            }
            if (singleRegionData.DirectionWeight.X < 0.0f || singleRegionData.DirectionWeight.Y < 0.0f || singleRegionData.DirectionWeight.Z < 0.0f ||
                singleRegionData.DirectionWeight.X > 1.0f || singleRegionData.DirectionWeight.Y > 1.0f || singleRegionData.DirectionWeight.Z > 1.0f)
            {
                return false;
            }

            return true;
        }
    }
}