using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ResourceDataManagementLib.MapGeneration.DataBuffer;
using ResourceDataManagementLib.MapGeneration.MapGenInputDataSpec;
using ResourceDataManagementLib.MapGeneration.TileGroupAsset;


namespace ResourceDataManagementLib.MapGeneration.DataAccessInterface
{
    public static class MapGenOutputResourceInterface
    {
        public static Dictionary<int, MapActiveType[,]> GetMapActivePlaneTable()
        {
            return MapGenOutputResourceBuffer.Instance.MapActivePlaneTable;
        }
        public static Dictionary<int, byte[,]> GetRegionSelectionPlaneTable()
        {
            return MapGenOutputResourceBuffer.Instance.RegionSelectionPlaneTable;
        }
        public static Dictionary<int, byte[,]> GetMiddleLayerPlaneTable()
        {
            return MapGenOutputResourceBuffer.Instance.MiddleLayerPlaneTable;
        }
        public static Dictionary<int, TileKind[,]> GetTileKindPlaneTable()
        {
            return MapGenOutputResourceBuffer.Instance.TileKindPlaneTable;
        }
    }
}