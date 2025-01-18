using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

using ResourceDataManagementLib.MapGeneration.DataBuffer;
using ResourceDataManagementLib.MapGeneration.TileGroupAsset;


namespace ResourceDataManagementLib.MapGeneration.DataAccessInterface
{
    public static class TileBaseResourceInterface
    {
#if FOR_EDITOR
        public static bool BGetIsTotalTileGroupLoaded()
        {
            return TileBaseResourceBuffer.Instance.BIsTotalTileGroupLoaded;
        }
#endif

        public static TotalTileGroup GetTotalTileGroupInstance()
        {
            CheckTotalTileGroupInstance();

            return TileBaseResourceBuffer.Instance.TotalTileGroupInstance;
        }

        private static void CheckTotalTileGroupInstance()
        {
            if (!TileBaseResourceBuffer.Instance.BIsTotalTileGroupLoaded)
            {
                throw new InvalidOperationException("TotalTileGroup is not loaded yet.");
            }
        }
    }
}