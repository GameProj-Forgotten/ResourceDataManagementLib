using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

using CommonUtilLib.ThreadSafe;

using ResourceDataManagementLib.GameSaveData;


namespace ResourceDataManagementLib.DataBuffer
{
    internal sealed class GameSaveMetadataBuffer : SingleTon<GameSaveMetadataBuffer>, IDisposable
    {
        private GameSaveMetadata? m_gameSaveMetadata;


        ~GameSaveMetadataBuffer()
        {
            Dispose(false);
        }

        internal bool BIsGameSaveMetadataLoaded { get; set; } = false;

        internal GameSaveMetadata GameSaveMetadata
        {
            get
            {
                if(!BIsGameSaveMetadataLoaded)
                {
                    throw new Exception("GameSaveMetadata is not loaded yet.");
                }

                return m_gameSaveMetadata.Value;
            }
            set
            {
                m_gameSaveMetadata = value;

                BIsGameSaveMetadataLoaded = true;
            }
        }

        internal new void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(in bool bisDispose)
        {
            if (bisDispose)
            {
                m_gameSaveMetadata = null;

                BIsGameSaveMetadataLoaded = false;
            }
        }
    }
}