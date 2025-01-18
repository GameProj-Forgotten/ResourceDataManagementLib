using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using UnityEngine;

using ResourcePathManagementLib;

using ResourceDataManagementLib.MapGeneration.DataBuffer;
using ResourceDataManagementLib.MapGeneration.MapGenInputDataSpec;
using ResourceDataManagementLib.MapGeneration.DataAccessInterface;
using ResourceDataManagementLib.Utils;


namespace ResourceDataManagementLib.MapGeneration.DataSupplyAndSave
{
    public static class MapGenDataSaver
    {
        public static void SaveMapGenInputData(in MapGenInputDataType targetInputData)
        {
            string filePath = string.Empty;
            string directoryPath = string.Empty;

            if(targetInputData.HasFlag(MapGenInputDataType.AbstractInputData))
            {
                filePath = MapGenResourcePathInterface.InputResourcePathData.AbstractInputResourceFullPath;
                directoryPath = Path.GetDirectoryName(filePath);

                if(!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                File.WriteAllText(filePath, JsonUtility.ToJson(MapGenInputResourceBuffer.Instance.AbstractInputDataInstance));
            }
            if(targetInputData.HasFlag(MapGenInputDataType.BasicMapGenInputData))
            {
                filePath = MapGenResourcePathInterface.InputResourcePathData.BasicPathGenerationInputResourceFullPath;
                directoryPath = Path.GetDirectoryName(filePath);

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                File.WriteAllText(filePath, JsonUtility.ToJson(MapGenInputResourceBuffer.Instance.BasicMapGenInputDataInstance));
            }
            if (targetInputData.HasFlag(MapGenInputDataType.RegionSelectionInputData))
            {
                filePath = MapGenResourcePathInterface.InputResourcePathData.RegionSelectionInputResourceFullPath;
                directoryPath = Path.GetDirectoryName(filePath);

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                File.WriteAllText(filePath, JsonUtility.ToJson(MapGenInputResourceBuffer.Instance.RegionSelectionInputDataInstance));
            }
            if (targetInputData.HasFlag(MapGenInputDataType.MiddleLayersInputData))
            {
                filePath = MapGenResourcePathInterface.InputResourcePathData.MiddleLayerInputResourceFullPath;
                directoryPath = Path.GetDirectoryName(filePath);

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                File.WriteAllText(filePath, JsonUtility.ToJson(MapGenInputResourceBuffer.Instance.MiddleLayersInputDataInstance));
            }
        }

        public static void SaveMapGenData(in int targetLayerIndex)
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

            {
                Color[] colors = new Color[realMapSize.x * realMapSize.y];
                for (int coord_z = 0; coord_z < realMapSize.y; coord_z++)
                {
                    for (int coord_x = 0; coord_x < realMapSize.x; coord_x++)
                    {
                        Tuple<float, float> values = DataMutiBitSaveFactors.GetTwoChannelMultiBit((int)MapGenOutputResourceBuffer.Instance.MapActivePlaneTable[targetLayerIndex][coord_z, coord_x] / (float)byte.MaxValue);
                        colors[realMapSize.x * coord_z + coord_x] = new Color((byte)(values.Item1 * 255.0f) / 255.0f, (byte)(values.Item2 * 255.0f) / 255.0f, 1.0f);
                    }
                }

                Texture2D rawBitmap = new Texture2D(realMapSize.x, realMapSize.y, TextureFormat.RGBA32, false);
                rawBitmap.SetPixels(colors);

                File.WriteAllBytes(MapGenResourcePathInterface.OutputResourcePathData.BasicPathGenerationOutputResourceFullPath + targetLayerIndex.ToString() + ".png", rawBitmap.EncodeToPNG());
            }
            {
                Color[] colors = new Color[realMapSize.x * realMapSize.y];
                for (int coord_z = 0; coord_z < realMapSize.y; coord_z++)
                {
                    for (int coord_x = 0; coord_x < realMapSize.x; coord_x++)
                    {
                        Tuple<float, float> values = DataMutiBitSaveFactors.GetTwoChannelMultiBit((int)MapGenOutputResourceBuffer.Instance.RegionSelectionPlaneTable[targetLayerIndex][coord_z, coord_x] / (float)byte.MaxValue);
                        colors[realMapSize.x * coord_z + coord_x] = new Color((byte)(values.Item1 * 255.0f) / 255.0f, (byte)(values.Item2 * 255.0f) / 255.0f, 1.0f);
                    }
                }

                Texture2D rawBitmap = new Texture2D(realMapSize.x, realMapSize.y, TextureFormat.RGBA32, false);
                rawBitmap.SetPixels(colors);

                File.WriteAllBytes(MapGenResourcePathInterface.OutputResourcePathData.RegionSelectionOutputResourceFullPath + targetLayerIndex.ToString() + ".png", rawBitmap.EncodeToPNG());
            }
            {
                Color[] colors = new Color[realMapSize.x * realMapSize.y];
                for (int coord_z = 0; coord_z < realMapSize.y; coord_z++)
                {
                    for (int coord_x = 0; coord_x < realMapSize.x; coord_x++)
                    {
                        Tuple<float, float> values = DataMutiBitSaveFactors.GetTwoChannelMultiBit((int)MapGenOutputResourceBuffer.Instance.MiddleLayerPlaneTable[targetLayerIndex][coord_z, coord_x] / (float)byte.MaxValue);
                        colors[realMapSize.x * coord_z + coord_x] = new Color((byte)(values.Item1 * 255.0f) / 255.0f, (byte)(values.Item2 * 255.0f) / 255.0f, 1.0f);
                    }
                }

                Texture2D rawBitmap = new Texture2D(realMapSize.x, realMapSize.y, TextureFormat.RGBA32, false);
                rawBitmap.SetPixels(colors);

                File.WriteAllBytes(MapGenResourcePathInterface.OutputResourcePathData.MiddleLayerOutputResourceFullPath + targetLayerIndex.ToString() + ".png", rawBitmap.EncodeToPNG());
            }
            {
                Color[] colors = new Color[realMapSize.x * realMapSize.y];
                for (int coord_z = 0; coord_z < realMapSize.y; coord_z++)
                {
                    for (int coord_x = 0; coord_x < realMapSize.x; coord_x++)
                    {
                        Tuple<float, float> values = DataMutiBitSaveFactors.GetTwoChannelMultiBit((int)MapGenOutputResourceBuffer.Instance.TileKindPlaneTable[targetLayerIndex][coord_z, coord_x] / (float)byte.MaxValue);
                        colors[realMapSize.x * coord_z + coord_x] = new Color((byte)(values.Item1 * 255.0f) / 255.0f, (byte)(values.Item2 * 255.0f) / 255.0f, 1.0f);
                    }
                }

                Texture2D rawBitmap = new Texture2D(realMapSize.x, realMapSize.y, TextureFormat.RGBA32, false);
                rawBitmap.SetPixels(colors);

                File.WriteAllBytes(MapGenResourcePathInterface.OutputResourcePathData.TileKindOutputResourceFullPath + targetLayerIndex.ToString() + ".png", rawBitmap.EncodeToPNG());
            }
        }
    }
}