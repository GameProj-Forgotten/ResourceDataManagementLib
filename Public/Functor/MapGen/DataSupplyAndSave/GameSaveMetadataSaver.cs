using ResourcePathManagementLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

using ResourceDataManagementLib.DataBuffer;


namespace ResourceDataManagementLib.DataSupplyAndSave
{
    public static class GameSaveMetadataSaver
    {
        public static void SaveGameSaveMetadata()
        {
            string path = MapGenResourcePathInterface.GameSaveMetadataPathData.GameSaveMetadataFullPath;
            string directoryPath = Path.GetDirectoryName(path);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            File.WriteAllText(path, JsonUtility.ToJson(GameSaveMetadataBuffer.Instance.GameSaveMetadata));
        }
    }
}