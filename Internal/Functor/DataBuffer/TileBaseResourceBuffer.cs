using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

using CommonUtilLib.ThreadSafe;

using ResourceDataManagementLib.MapGeneration.TileGroupAsset;


namespace ResourceDataManagementLib.MapGeneration.DataBuffer
{
    internal sealed class TileBaseResourceBuffer : SingleTon<TileBaseResourceBuffer>, IDisposable
    {
        private TotalTileGroup m_totalTileGroup;


        ~TileBaseResourceBuffer()
        {
            Dispose(false);
        }

        internal bool BIsTotalTileGroupLoaded { get; set; } = false;

        internal TotalTileGroup TotalTileGroupInstance
        {
            get
            {
                if (!BIsTotalTileGroupLoaded)
                {
                    throw new InvalidOperationException("TotalTileGroup is not loaded yet.");
                }

                return m_totalTileGroup;
            }
            set
            {
                if (value != null)
                {
                    m_totalTileGroup = value;
                    BIsTotalTileGroupLoaded = true;
                }
            }
        }

        internal new void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(in bool bisDispose)
        {
            if(bisDispose)
            {
                m_totalTileGroup = null;

                BIsTotalTileGroupLoaded = false;
            }
        }
    }
}