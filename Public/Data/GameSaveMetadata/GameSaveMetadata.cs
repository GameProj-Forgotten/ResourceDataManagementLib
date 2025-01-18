using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ResourceDataManagementLib.GameSaveData
{
    public struct GameSaveMetadata
    {
        public string SaveName;
        public int GameSeed;

        public bool BIsFirstInited;

        public DateTime LastSaveTime;


        internal static string DefaultSaveName
        {
            get
            {
                return "SaveData_";
            }
        }
    }

    public static class GameSaveMetadataExtension
    {
        public static void Init(ref this GameSaveMetadata metadata)
        {
            metadata.SaveName = GameSaveMetadata.DefaultSaveName + UnityEngine.Random.Range(0, int.MaxValue);
            metadata.GameSeed = UnityEngine.Random.Range(int.MinValue, int.MaxValue);

            metadata.BIsFirstInited = false;

            metadata.LastSaveTime = DateTime.Now;
        }
    }
}