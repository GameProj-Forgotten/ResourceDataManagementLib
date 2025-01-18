using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ResourceDataManagementLib.GameSaveData;
using ResourceDataManagementLib.DataBuffer;


namespace ResourceDataManagementLib.DataAccessInterface
{
    public static class GameSaveMetadataInterface
    {
#if FOR_EDITOR
        public static bool BGetIsGameSaveMetadataLoaded()
        {
            return GameSaveMetadataBuffer.Instance.BIsGameSaveMetadataLoaded;
        }
#endif

        public static GameSaveMetadata GetGameSaveMetadataInstance()
        {
            CheckGameSaveMetadataInstance();

            return GameSaveMetadataBuffer.Instance.GameSaveMetadata;
        }

        private static void CheckGameSaveMetadataInstance()
        {
            if (!GameSaveMetadataBuffer.Instance.BIsGameSaveMetadataLoaded)
            {
                throw new InvalidOperationException("GameSaveMetadata is not loaded yet.");
            }
        }
    }
}