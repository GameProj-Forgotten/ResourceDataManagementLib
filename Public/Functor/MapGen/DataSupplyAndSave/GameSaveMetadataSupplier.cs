using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using UnityEngine;

using ResourcePathManagementLib;

using ResourceDataManagementLib.DataBuffer;
using ResourceDataManagementLib.GameSaveData;


namespace ResourceDataManagementLib.DataSupplyAndSave
{
    public static class GameSaveMetadataSupplier
    {
        public static void SupplyGameSaveMetadata()
        {
            string path = MapGenResourcePathInterface.GameSaveMetadataPathData.GameSaveMetadataFullPath;

            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                GameSaveMetadataBuffer.Instance.GameSaveMetadata = JsonUtility.FromJson<GameSaveMetadata>(File.ReadAllText(path));
            }
            else
            {
                GameSaveMetadata gameSaveMetadata = new GameSaveMetadata();
                gameSaveMetadata.Init();

                GameSaveMetadataBuffer.Instance.GameSaveMetadata = gameSaveMetadata;

                GameSaveMetadataSaver.SaveGameSaveMetadata();
            }
        }
    }
}