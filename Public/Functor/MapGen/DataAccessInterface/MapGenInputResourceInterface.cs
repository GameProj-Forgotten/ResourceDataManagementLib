using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

using ResourceDataManagementLib.MapGeneration.DataBuffer;
using ResourceDataManagementLib.MapGeneration.MapGenInputDataSpec;


namespace ResourceDataManagementLib.MapGeneration.DataAccessInterface
{
    public static class MapGenInputResourceInterface
    {
#if FOR_EDITOR
        public static bool BGetIsAbstractInputDataLoaded()
        {
            return MapGenInputResourceBuffer.Instance.BIsAbstractInputDataLoaded;
        }
        public static bool BGetIsBasicMapGenInputDataLoaded()
        {
            return MapGenInputResourceBuffer.Instance.BIsBasicMapGenInputDataLoaded;
        }
        public static bool BGetIsRegionSelectionInputDataLoaded()
        {
            return MapGenInputResourceBuffer.Instance.BIsRegionSelectionInputDataLoaded;
        }
#endif

        public static class AbstractInputDataInterface
        {
            #region Getter
            public static Vector3Int GetSingleChunkSize()
            {
                CheckAbstractInputDataLoaded();

                return MapGenInputResourceBuffer.Instance.AbstractInputDataInstance.SingleChunkSize;
            }
            public static Vector3Int GetMapSize()
            {
                CheckAbstractInputDataLoaded();

                return MapGenInputResourceBuffer.Instance.AbstractInputDataInstance.MapSize;
            }
            public static Vector2Int GetSingleRoomSize()
            {
                CheckAbstractInputDataLoaded();

                return MapGenInputResourceBuffer.Instance.AbstractInputDataInstance.SingleRoomSize;
            }
            public static Dictionary<Guid, string> GetAreaNameTable()
            {
                CheckAbstractInputDataLoaded();

                return MapGenInputResourceBuffer.Instance.AbstractInputDataInstance.AreaNameTable;
            }
            #endregion

#if FOR_EDITOR
            #region Setter
            public static void SetSingleChunkSize(in Vector3Int singleChunkSize)
            {
                CheckAbstractInputDataLoaded();

                var abstractInputDataSpec = MapGenInputResourceBuffer.Instance.AbstractInputDataInstance;
                abstractInputDataSpec.SingleChunkSize = singleChunkSize;

                MapGenInputResourceBuffer.Instance.AbstractInputDataInstance = abstractInputDataSpec;
            }
            public static void SetMapSize(in Vector3Int mapSize)
            {
                CheckAbstractInputDataLoaded();

                var abstractInputDataSpec = MapGenInputResourceBuffer.Instance.AbstractInputDataInstance;
                abstractInputDataSpec.MapSize = mapSize;

                MapGenInputResourceBuffer.Instance.AbstractInputDataInstance = abstractInputDataSpec;
            }
            public static void SetSingleRoomSize(in Vector2Int singleRoomSize)
            {
                CheckAbstractInputDataLoaded();

                var abstractInputDataSpec = MapGenInputResourceBuffer.Instance.AbstractInputDataInstance;
                abstractInputDataSpec.SingleRoomSize = singleRoomSize;

                MapGenInputResourceBuffer.Instance.AbstractInputDataInstance = abstractInputDataSpec;
            }

            public static void SetAreaNameTable(in Dictionary<Guid, string> areaNameTable)
            {
                CheckAbstractInputDataLoaded();

                var abstractInputDataSpec = MapGenInputResourceBuffer.Instance.AbstractInputDataInstance;
                abstractInputDataSpec.AreaNameTable = areaNameTable;

                MapGenInputResourceBuffer.Instance.AbstractInputDataInstance = abstractInputDataSpec;
            }
            public static void AddAreaName(in Guid areaID, in string areaName)
            {
                CheckAbstractInputDataLoaded();

                var abstractInputDataSpec = MapGenInputResourceBuffer.Instance.AbstractInputDataInstance;
                abstractInputDataSpec.AreaNameTable.Add(areaID, areaName);

                MapGenInputResourceBuffer.Instance.AbstractInputDataInstance = abstractInputDataSpec;
            }
            public static void RemoveAreaName(in Guid areaID)
            {
                CheckAbstractInputDataLoaded();

                var abstractInputDataSpec = MapGenInputResourceBuffer.Instance.AbstractInputDataInstance;
                abstractInputDataSpec.AreaNameTable.Remove(areaID);

                MapGenInputResourceBuffer.Instance.AbstractInputDataInstance = abstractInputDataSpec;
            }
            public static void ClearAreaNameTable()
            {
                CheckAbstractInputDataLoaded();

                var abstractInputDataSpec = MapGenInputResourceBuffer.Instance.AbstractInputDataInstance;
                abstractInputDataSpec.AreaNameTable.Clear();

                MapGenInputResourceBuffer.Instance.AbstractInputDataInstance = abstractInputDataSpec;
            }
            #endregion
#endif

            #region Common Utils
            private static void CheckAbstractInputDataLoaded()
            {
                if (!MapGenInputResourceBuffer.Instance.BIsAbstractInputDataLoaded)
                {
                    throw new InvalidOperationException("AbstractInputDataSpec is not loaded yet.");
                }
            }
            #endregion
        }
        public static class BasicMapGenInputDataInterface
        {
            #region Getter
            public static float GetMaxTryCountRatio()
            {
                CheckBasicMapGenInputDataLoaded();

                return MapGenInputResourceBuffer.Instance.BasicMapGenInputDataInstance.MaxTryCountRatio;
            }
            public static Tuple<int, int> GetBrushSize()
            {
                CheckBasicMapGenInputDataLoaded();

                return MapGenInputResourceBuffer.Instance.BasicMapGenInputDataInstance.BrushSize;
            }
            public static float GetMainWayFillPercent()
            {
                CheckBasicMapGenInputDataLoaded();

                return MapGenInputResourceBuffer.Instance.BasicMapGenInputDataInstance.MainWayFillPercent;
            }
            public static float GetSubWayFillPercent()
            {
                CheckBasicMapGenInputDataLoaded();

                return MapGenInputResourceBuffer.Instance.BasicMapGenInputDataInstance.SubWayFillPercent;
            }
            public static float GetPenetratingWayCountRate()
            {
                CheckBasicMapGenInputDataLoaded();

                return MapGenInputResourceBuffer.Instance.BasicMapGenInputDataInstance.PenetratingWayCountRate;
            }
            public static float GetPenetratingWayFillPercent()
            {
                CheckBasicMapGenInputDataLoaded();

                return MapGenInputResourceBuffer.Instance.BasicMapGenInputDataInstance.PenetratingWayFillPercent;
            }
            #endregion

#if FOR_EDITOR
            #region Setter
            public static void SetMaxTryCountRatio(in float maxTryCountRatio)
            {
                CheckBasicMapGenInputDataLoaded();

                var basicMapGenInputDataSpec = MapGenInputResourceBuffer.Instance.BasicMapGenInputDataInstance;
                basicMapGenInputDataSpec.MaxTryCountRatio = maxTryCountRatio;

                MapGenInputResourceBuffer.Instance.BasicMapGenInputDataInstance = basicMapGenInputDataSpec;
            }
            public static void SetBrushSize(in Tuple<int, int> brushSize)
            {
                CheckBasicMapGenInputDataLoaded();

                var basicMapGenInputDataSpec = MapGenInputResourceBuffer.Instance.BasicMapGenInputDataInstance;
                basicMapGenInputDataSpec.BrushSize = brushSize;

                MapGenInputResourceBuffer.Instance.BasicMapGenInputDataInstance = basicMapGenInputDataSpec;
            }
            public static void SetMainWayFillPercent(in float mainWayFillPercent)
            {
                CheckBasicMapGenInputDataLoaded();

                var basicMapGenInputDataSpec = MapGenInputResourceBuffer.Instance.BasicMapGenInputDataInstance;
                basicMapGenInputDataSpec.MainWayFillPercent = mainWayFillPercent;

                MapGenInputResourceBuffer.Instance.BasicMapGenInputDataInstance = basicMapGenInputDataSpec;
            }
            public static void SetSubWayFillPercent(in float subWayFillPercent)
            {
                CheckBasicMapGenInputDataLoaded();

                var basicMapGenInputDataSpec = MapGenInputResourceBuffer.Instance.BasicMapGenInputDataInstance;
                basicMapGenInputDataSpec.SubWayFillPercent = subWayFillPercent;

                MapGenInputResourceBuffer.Instance.BasicMapGenInputDataInstance = basicMapGenInputDataSpec;
            }
            public static void SetPenetratingWayCountRate(in float penetratingWayCountRate)
            {
                CheckBasicMapGenInputDataLoaded();

                var basicMapGenInputDataSpec = MapGenInputResourceBuffer.Instance.BasicMapGenInputDataInstance;
                basicMapGenInputDataSpec.PenetratingWayCountRate = penetratingWayCountRate;

                MapGenInputResourceBuffer.Instance.BasicMapGenInputDataInstance = basicMapGenInputDataSpec;
            }
            public static void SetPenetratingWayFillPercent(in float penetratingWayFillPercent)
            {
                CheckBasicMapGenInputDataLoaded();

                var basicMapGenInputDataSpec = MapGenInputResourceBuffer.Instance.BasicMapGenInputDataInstance;
                basicMapGenInputDataSpec.PenetratingWayFillPercent = penetratingWayFillPercent;

                MapGenInputResourceBuffer.Instance.BasicMapGenInputDataInstance = basicMapGenInputDataSpec;
            }
            #endregion
#endif

            #region Common Utils
            private static void CheckBasicMapGenInputDataLoaded()
            {
                if (!MapGenInputResourceBuffer.Instance.BIsBasicMapGenInputDataLoaded)
                {
                    throw new InvalidOperationException("BasicMapGenInputDataSpec is not loaded yet.");
                }
            }
            #endregion
        }
        public static class RegionSelectionInputDataInterface
        {
            #region Getter
            public static Color GetBaseColor()
            {
                CheckRegionSelectionInputDataLoaded();

                return MapGenInputResourceBuffer.Instance.RegionSelectionInputDataInstance.BaseColor;
            }
            public static List<RegionSelectionInputDataSpec.SingleRegionData> GetSingleRegionDatas()
            {
                CheckRegionSelectionInputDataLoaded();

                return MapGenInputResourceBuffer.Instance.RegionSelectionInputDataInstance.SingleRegionDatas;
            }
            #endregion

#if FOR_EDITOR
            #region Setter
            public static void SetBaseColor(in Color baseColor)
            {
                CheckRegionSelectionInputDataLoaded();

                var regionSelectionInputDataSpec = MapGenInputResourceBuffer.Instance.RegionSelectionInputDataInstance;
                regionSelectionInputDataSpec.BaseColor = baseColor;

                MapGenInputResourceBuffer.Instance.RegionSelectionInputDataInstance = regionSelectionInputDataSpec;
            }

            public static void SetSingleRegionDatas(in List<RegionSelectionInputDataSpec.SingleRegionData> singleRegionDatas)
            {
                CheckRegionSelectionInputDataLoaded();

                var regionSelectionInputDataSpec = MapGenInputResourceBuffer.Instance.RegionSelectionInputDataInstance;
                regionSelectionInputDataSpec.SingleRegionDatas = singleRegionDatas;

                MapGenInputResourceBuffer.Instance.RegionSelectionInputDataInstance = regionSelectionInputDataSpec;
            }
            public static RegionSelectionInputDataSpec.SingleRegionData AddSingleRegionData()
            {
                CheckRegionSelectionInputDataLoaded();

                var regionSelectionInputDataSpec = MapGenInputResourceBuffer.Instance.RegionSelectionInputDataInstance;

                var singleRegionData = new RegionSelectionInputDataSpec.SingleRegionData();
                singleRegionData.Init();

                regionSelectionInputDataSpec.SingleRegionDatas.Add(singleRegionData);
                MapGenInputResourceBuffer.Instance.RegionSelectionInputDataInstance = regionSelectionInputDataSpec;

                return singleRegionData;
            }
            public static void RemoveSingleRegionData(in int targetIndex)
            {
                CheckRegionSelectionInputDataLoaded();

                var regionSelectionInputDataSpec = MapGenInputResourceBuffer.Instance.RegionSelectionInputDataInstance;
                regionSelectionInputDataSpec.SingleRegionDatas.RemoveAt(targetIndex);

                MapGenInputResourceBuffer.Instance.RegionSelectionInputDataInstance = regionSelectionInputDataSpec;
            }
            public static void ClearSingleRegionDatas()
            {
                CheckRegionSelectionInputDataLoaded();

                var regionSelectionInputDataSpec = MapGenInputResourceBuffer.Instance.RegionSelectionInputDataInstance;
                regionSelectionInputDataSpec.SingleRegionDatas.Clear();

                MapGenInputResourceBuffer.Instance.RegionSelectionInputDataInstance = regionSelectionInputDataSpec;
            }
            #endregion
#endif

            #region Common Utils
            private static void CheckRegionSelectionInputDataLoaded()
            {
                if (!MapGenInputResourceBuffer.Instance.BIsRegionSelectionInputDataLoaded)
                {
                    throw new InvalidOperationException("RegionSelectionInputDataSpec is not loaded yet.");
                }
            }
            #endregion
        }
        public static class MiddleLayersInputDataInterface
        {
            #region Getter
            public static int GetCurLayerMiddleLayerDepth()
            {
                CheckMiddleLayersInputDataLoaded();

                return MapGenInputResourceBuffer.Instance.MiddleLayersInputDataInstance.CurLayerMiddleLayerDepth;
            }
            public static Color GetColorStepForCurLayer()
            {
                CheckMiddleLayersInputDataLoaded();

                return MapGenInputResourceBuffer.Instance.MiddleLayersInputDataInstance.ColorStepForCurLayer;
            }
            #endregion

#if FOR_EDITOR
            #region Setter
            public static void SetCurLayerMiddleLayerDepth(in int curLayerMiddleLayerDepth)
            {
                CheckMiddleLayersInputDataLoaded();

                var middleLayersInputDataSpec = MapGenInputResourceBuffer.Instance.MiddleLayersInputDataInstance;
                middleLayersInputDataSpec.CurLayerMiddleLayerDepth = curLayerMiddleLayerDepth;

                MapGenInputResourceBuffer.Instance.MiddleLayersInputDataInstance = middleLayersInputDataSpec;
            }
            public static void SetColorStepForCurLayer(in Color colorStepForCurLayer)
            {
                CheckMiddleLayersInputDataLoaded();

                var middleLayersInputDataSpec = MapGenInputResourceBuffer.Instance.MiddleLayersInputDataInstance;
                middleLayersInputDataSpec.ColorStepForCurLayer = colorStepForCurLayer;

                MapGenInputResourceBuffer.Instance.MiddleLayersInputDataInstance = middleLayersInputDataSpec;
            }
            #endregion
#endif

            #region Common Utils
            private static void CheckMiddleLayersInputDataLoaded()
            {
                if (!MapGenInputResourceBuffer.Instance.BIsMiddleLayersInputDataLoaded)
                {
                    throw new InvalidOperationException("MiddleLayersInputDataSpec is not loaded yet.");
                }
            }
            #endregion
        }
    }
}