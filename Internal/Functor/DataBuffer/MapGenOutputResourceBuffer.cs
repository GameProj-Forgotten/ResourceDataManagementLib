using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

using CommonUtilLib.ThreadSafe;

using ResourceDataManagementLib.MapGeneration.MapGenInputDataSpec;
using ResourceDataManagementLib.MapGeneration.TileGroupAsset;


namespace ResourceDataManagementLib.MapGeneration.DataBuffer
{
    internal sealed class MapGenOutputResourceBuffer : SingleTon<MapGenOutputResourceBuffer>, IDisposable
    {
        private Dictionary<int, MapActiveType[,]> m_mapActivePlaneTable = new Dictionary<int, MapActiveType[,]>();
        private Dictionary<int, byte[,]> m_regionSelectionPlaneTable = new Dictionary<int, byte[,]>();
        private Dictionary<int, byte[,]> m_middleLayerPlaneTable = new Dictionary<int, byte[,]>();
        private Dictionary<int, TileKind[,]> m_tileKindPlaneTable = new Dictionary<int, TileKind[,]>();


        ~MapGenOutputResourceBuffer()
        {
            Dispose(false);
        }

        internal Dictionary<int, MapActiveType[,]> MapActivePlaneTable
        {
            get
            {
                return m_mapActivePlaneTable;
            }
        }
        internal Dictionary<int, byte[,]> RegionSelectionPlaneTable
        {
            get
            {
                return m_regionSelectionPlaneTable;
            }
        }
        internal Dictionary<int, byte[,]> MiddleLayerPlaneTable
        {
            get
            {
                return m_middleLayerPlaneTable;
            }
        }
        internal Dictionary<int, TileKind[,]> TileKindPlaneTable
        {
            get
            {
                return m_tileKindPlaneTable;
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
                m_mapActivePlaneTable.Clear();
                m_regionSelectionPlaneTable.Clear();
                m_middleLayerPlaneTable.Clear();
                m_tileKindPlaneTable.Clear();
            }
        }
    }
}