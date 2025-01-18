using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using UnityEngine;

using ResourcePathManagementLib;

using ResourceDataManagementLib.DataBuffer;
using ResourceDataManagementLib.MapGeneration.DataBuffer;
using ResourceDataManagementLib.MapGeneration.MapGenInputDataSpec;
using ResourceDataManagementLib.MapGeneration.DataAccessInterface;
using ResourceDataManagementLib.MapGeneration.TileGroupAsset;
using ResourceDataManagementLib.Utils;


namespace ResourceDataManagementLib.MapGeneration.DataSupplyAndSave
{
    public static class MapGenDataSupplier
    {
        public static void SupplyMapGenInputData(in MapGenInputDataType targetInputData)
        {
            string filePath = string.Empty;

            if (targetInputData.HasFlag(MapGenInputDataType.AbstractInputData))
            {
                filePath = MapGenResourcePathInterface.InputResourcePathData.AbstractInputResourceFullPath;
                if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                {
                    MapGenInputResourceBuffer.Instance.AbstractInputDataInstance = JsonUtility.FromJson<AbstractInputDataSpec>(File.ReadAllText(filePath));
                }
                else
                {
                    AbstractInputDataSpec abstractInputData = new AbstractInputDataSpec();
                    abstractInputData.Init();

                    MapGenInputResourceBuffer.Instance.AbstractInputDataInstance = abstractInputData;

                    MapGenDataSaver.SaveMapGenInputData(MapGenInputDataType.AbstractInputData);
                }
            }
            if (targetInputData.HasFlag(MapGenInputDataType.BasicMapGenInputData))
            {
                filePath = MapGenResourcePathInterface.InputResourcePathData.BasicPathGenerationInputResourceFullPath;
                if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                {
                    MapGenInputResourceBuffer.Instance.BasicMapGenInputDataInstance = JsonUtility.FromJson<BasicMapGenInputDataSpec>(File.ReadAllText(filePath));
                }
                else
                {
                    BasicMapGenInputDataSpec basicMapGenInputData = new BasicMapGenInputDataSpec();
                    basicMapGenInputData.Init();

                    MapGenInputResourceBuffer.Instance.BasicMapGenInputDataInstance = basicMapGenInputData;

                    MapGenDataSaver.SaveMapGenInputData(MapGenInputDataType.BasicMapGenInputData);
                }
            }
            if (targetInputData.HasFlag(MapGenInputDataType.RegionSelectionInputData))
            {
                filePath = MapGenResourcePathInterface.InputResourcePathData.RegionSelectionInputResourceFullPath;
                if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                {
                    MapGenInputResourceBuffer.Instance.RegionSelectionInputDataInstance = JsonUtility.FromJson<RegionSelectionInputDataSpec>(File.ReadAllText(filePath));
                }
                else
                {
                    RegionSelectionInputDataSpec regionSelectionInputData = new RegionSelectionInputDataSpec();

                    regionSelectionInputData.Init();

                    MapGenInputResourceBuffer.Instance.RegionSelectionInputDataInstance = regionSelectionInputData;
                    MapGenDataSaver.SaveMapGenInputData(MapGenInputDataType.RegionSelectionInputData);
                }
            }
            if (targetInputData.HasFlag(MapGenInputDataType.MiddleLayersInputData))
            {
                filePath = MapGenResourcePathInterface.InputResourcePathData.MiddleLayerInputResourceFullPath;
                if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                {
                    MapGenInputResourceBuffer.Instance.MiddleLayersInputDataInstance = JsonUtility.FromJson<MiddleLayersInputDataSpec>(File.ReadAllText(filePath));
                }
                else
                {
                    MiddleLayersInputDataSpec middleLayersInputData = new MiddleLayersInputDataSpec();

                    middleLayersInputData.Init();

                    MapGenInputResourceBuffer.Instance.MiddleLayersInputDataInstance = middleLayersInputData;
                    MapGenDataSaver.SaveMapGenInputData(MapGenInputDataType.MiddleLayersInputData);
                }
            }
        }

        public static void SupplyMapGenData(in int targetLayerIndex, in int preLoadedLayerRadius = 1)
        {
            Vector3Int mapSize = MapGenInputResourceInterface.AbstractInputDataInterface.GetMapSize();
            Vector3Int singleChunkSize = MapGenInputResourceInterface.AbstractInputDataInterface.GetSingleChunkSize();
            Vector2Int singleRoomSize = MapGenInputResourceInterface.AbstractInputDataInterface.GetSingleRoomSize();
            Vector2Int realMapSize = new Vector2Int()
            {
                x = mapSize.x * singleChunkSize.x * singleRoomSize.x,
                y = mapSize.z * singleChunkSize.z * singleRoomSize.y
            };
            int layerCount = mapSize.y * singleChunkSize.y;

            List<int> removeLayerIndexes = new List<int>();
            foreach (int layerIndex in MapGenOutputResourceBuffer.Instance.MapActivePlaneTable.Keys)
            {
                if (layerIndex < targetLayerIndex - preLoadedLayerRadius || layerIndex > targetLayerIndex + preLoadedLayerRadius)
                {
                    removeLayerIndexes.Add(layerIndex);
                }
            }
            foreach (int removeLayerIndex in removeLayerIndexes)
            {
                MapGenDataSaver.SaveMapGenData(removeLayerIndex);
            }

            for (int searchLayerIndex = targetLayerIndex - preLoadedLayerRadius; searchLayerIndex <= targetLayerIndex + preLoadedLayerRadius; searchLayerIndex++)
            {
                if (0 <= searchLayerIndex && searchLayerIndex < layerCount)
                {
                    {
                        byte[] fileData = File.ReadAllBytes(MapGenResourcePathInterface.OutputResourcePathData.BasicPathGenerationOutputResourceFullPath + searchLayerIndex.ToString() + ".png");
                        Texture2D texture = new Texture2D(realMapSize.x, realMapSize.y, TextureFormat.RGBA32, false);
                        texture.LoadImage(fileData);
                        texture.Apply();

                        Color[] colors = texture.GetPixels();

                        MapActiveType[,] mapActivePlane = new MapActiveType[realMapSize.y, realMapSize.x];
                        if (!MapGenOutputResourceBuffer.Instance.MapActivePlaneTable.ContainsKey(searchLayerIndex))
                        {
                            MapGenOutputResourceBuffer.Instance.MapActivePlaneTable.Add(searchLayerIndex, mapActivePlane);
                        }
                        else
                        {
                            MapGenOutputResourceBuffer.Instance.MapActivePlaneTable[searchLayerIndex] = mapActivePlane;
                        }

                        Task.Run(() =>
                        {
                            for (int coord_z = 0; coord_z < realMapSize.y; coord_z++)
                            {
                                for (int coord_x = 0; coord_x < realMapSize.x; coord_x++)
                                {
                                    Color curColor = colors[coord_z * realMapSize.x + coord_x];

                                    Tuple<float, float> curLayerValues = new Tuple<float, float>(curColor.r, curColor.g);
                                    MapActiveType curLayerValue = (MapActiveType)(Math.Ceiling(DataMutiBitSaveFactors.GetTwoChannelRestoredValue(curLayerValues) * (float)byte.MaxValue));

                                    mapActivePlane[coord_z, coord_x] = curLayerValue;
                                }
                            }
                        });
                    }
                    {
                        byte[] fileData = File.ReadAllBytes(MapGenResourcePathInterface.OutputResourcePathData.RegionSelectionOutputResourceFullPath + searchLayerIndex.ToString() + ".png");
                        Texture2D texture = new Texture2D(realMapSize.x, realMapSize.y, TextureFormat.RGBA32, false);
                        texture.LoadImage(fileData);
                        texture.Apply();

                        Color[] colors = texture.GetPixels();

                        byte[,] regionSelectionPlane = new byte[realMapSize.y, realMapSize.x];
                        if (!MapGenOutputResourceBuffer.Instance.RegionSelectionPlaneTable.ContainsKey(searchLayerIndex))
                        {
                            MapGenOutputResourceBuffer.Instance.RegionSelectionPlaneTable.Add(searchLayerIndex, regionSelectionPlane);
                        }
                        else
                        {
                            MapGenOutputResourceBuffer.Instance.RegionSelectionPlaneTable[searchLayerIndex] = regionSelectionPlane;
                        }

                        Task.Run(() =>
                        {
                            for (int coord_z = 0; coord_z < realMapSize.y; coord_z++)
                            {
                                for (int coord_x = 0; coord_x < realMapSize.x; coord_x++)
                                {
                                    Color curColor = colors[coord_z * realMapSize.x + coord_x];

                                    Tuple<float, float> curLayerValues = new Tuple<float, float>(curColor.r, curColor.g);
                                    byte curLayerValue = (byte)(Math.Ceiling(DataMutiBitSaveFactors.GetTwoChannelRestoredValue(curLayerValues) * (float)byte.MaxValue));

                                    regionSelectionPlane[coord_z, coord_x] = curLayerValue;
                                }
                            }
                        });
                    }
                    {
                        byte[] fileData = File.ReadAllBytes(MapGenResourcePathInterface.OutputResourcePathData.MiddleLayerOutputResourceFullPath + searchLayerIndex.ToString() + ".png");
                        Texture2D texture = new Texture2D(realMapSize.x, realMapSize.y, TextureFormat.RGBA32, false);
                        texture.LoadImage(fileData);
                        texture.Apply();

                        Color[] colors = texture.GetPixels();

                        byte[,] middleLayerPlane = new byte[realMapSize.y, realMapSize.x];
                        if (!MapGenOutputResourceBuffer.Instance.MiddleLayerPlaneTable.ContainsKey(searchLayerIndex))
                        {
                            MapGenOutputResourceBuffer.Instance.MiddleLayerPlaneTable.Add(searchLayerIndex, middleLayerPlane);
                        }
                        else
                        {
                            MapGenOutputResourceBuffer.Instance.MiddleLayerPlaneTable[searchLayerIndex] = middleLayerPlane;
                        }

                        Task.Run(() =>
                        {
                            for (int coord_z = 0; coord_z < realMapSize.y; coord_z++)
                            {
                                for (int coord_x = 0; coord_x < realMapSize.x; coord_x++)
                                {
                                    Color curColor = colors[coord_z * realMapSize.x + coord_x];

                                    Tuple<float, float> curLayerValues = new Tuple<float, float>(curColor.r, curColor.g);
                                    byte curLayerValue = (byte)(Math.Ceiling(DataMutiBitSaveFactors.GetTwoChannelRestoredValue(curLayerValues) * (float)byte.MaxValue));

                                    middleLayerPlane[coord_z, coord_x] = curLayerValue;
                                }
                            }
                        });
                    }

                    if(GameSaveMetadataBuffer.Instance.GameSaveMetadata.BIsFirstInited)
                    {
                        byte[] fileData = File.ReadAllBytes(MapGenResourcePathInterface.OutputResourcePathData.TileKindOutputResourceFullPath + searchLayerIndex.ToString() + ".png");
                        Texture2D texture = new Texture2D(realMapSize.x, realMapSize.y, TextureFormat.RGBA32, false);
                        texture.LoadImage(fileData);
                        texture.Apply();

                        Color[] colors = texture.GetPixels();

                        TileKind[,] tileKindPlane = new TileKind[realMapSize.y, realMapSize.x];
                        if(!MapGenOutputResourceBuffer.Instance.TileKindPlaneTable.ContainsKey(searchLayerIndex))
                        {
                            MapGenOutputResourceBuffer.Instance.TileKindPlaneTable.Add(searchLayerIndex, tileKindPlane);
                        }
                        else
                        {
                            MapGenOutputResourceBuffer.Instance.TileKindPlaneTable[searchLayerIndex] = tileKindPlane;
                        }

                        Task.Run(() =>
                        {
                            for (int coord_z = 0; coord_z < realMapSize.y; coord_z++)
                            {
                                for (int coord_x = 0; coord_x < realMapSize.x; coord_x++)
                                {
                                    Color curColor = colors[coord_z * realMapSize.x + coord_x];

                                    Tuple<float, float> curLayerValues = new Tuple<float, float>(curColor.r, curColor.g);
                                    TileKind curLayerValue = (TileKind)(Math.Ceiling(DataMutiBitSaveFactors.GetTwoChannelRestoredValue(curLayerValues) * (float)byte.MaxValue));

                                    tileKindPlane[coord_z, coord_x] = curLayerValue;
                                }
                            }
                        });
                    }
                }
            }
        }
    }
}