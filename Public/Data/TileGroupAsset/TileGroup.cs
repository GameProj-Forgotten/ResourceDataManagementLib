using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using UnityEngine.Tilemaps;


namespace ResourceDataManagementLib.MapGeneration.TileGroupAsset
{
    public enum TileKind : byte
    {
        #region Main Layer
        #region Fundamental Tiles
        /// <summary>
        /// Item Value Offset : 1
        /// </summary>
        BasicCommonAreaTile = 1,
        /// <summary>
        /// Item Value Offset : 2 ~ 5
        /// </summary>
        BasicDecorationAreaTile_0,
        BasicDecorationAreaTile_1,
        BasicDecorationAreaTile_2,
        BasicDecorationAreaTile_3,
        #endregion

        #region Functional Tiles
        // Trap Tiles
        /// <summary>
        /// Item Value Offset : 6
        /// </summary>
        FallingTile,
        /// <summary>
        /// Item Value Offset : 7
        /// </summary>
        ArrawTrapTile,
        /// <summary>
        /// Item Value Offset : 8
        /// </summary>
        SpearTrapTile,
        /// <summary>
        /// Item Value Offset : 9
        /// </summary>
        SpikeTrapTile,

        // Convenience Feature Tiles
        /// <summary>
        /// Item Value Offset : 10
        /// </summary>
        ChestTile,
        /// <summary>
        /// Item Value Offset : 11
        /// </summary>
        DoorTile,

        /// <summary>
        /// Item Value Offset : 12
        /// </summary>
        LadderTile,

        // Decoration Tiles
        /// <summary>
        /// Item Value Offset : 13
        /// </summary>
        GlowTile,

        // Movement Tiles
        /// <summary>
        /// Item Value Offset : 14
        /// </summary>
        MovementTile,
        #endregion
        #endregion

        #region Middle Layer
        // On Middle Layer
        /// <summary>
        /// Item Value Offset : 15
        /// </summary>
        PillarTile,
        /// <summary>
        /// Item Value Offset : 16
        /// </summary>
        BackgroundWallpaperTile,

        // Between the Middle Layer
        /// <summary>
        /// Item Value Offset : 17
        /// </summary>
        FloatingDecorationPropTile
        #endregion
    }

    #region Tile Group Asset
    [CreateAssetMenu(fileName = "TotalTileGroup", menuName = "MapGeneration/TotalTileGroup", order = 1)]
    public sealed class TotalTileGroup : ScriptableObject
    {
        [Header("Tile Groups")]
        public List<SingleTileGroup> SingleTileGroups;
    }

    [CreateAssetMenu(fileName = "SingleTileGroup", menuName = "MapGeneration/SingleTileGroup", order = 1)]
    public sealed class SingleTileGroup : ScriptableObject
    {
        [Serializable] public struct MainLayerTileGroupData
        {
            [Serializable] public struct  FundamentalDetailData
            {
                public BasicCommonAreaTileDetailData BasicCommonAreaTile;
                public BasicDecorationAreaTileDetailData BasicDecorationAreaTile;
            }
            [Serializable] public struct FunctionalDetailData
            {
                [Header("Trap Tiles")]
                public FallingTileDetailData FallingTile;
                public ArrawTrapTileDetailData ArrawTrapTile;
                public SpearTrapTileDetailData SpearTrapTile;
                public SpikeTrapTileDetailData SpikeTrapTile;

                [Header("Convenience Feature Tiles")]
                public ChestTileDetailData ChestTile;
                public DoorTileDetailData DoorTile;
                public LadderTileDetailData LadderTile;

                [Header("Decoration Tiles")]
                public GlowTileDetailData GlowTile;

                [Header("Movement Tiles")]
                public MovementTileDetailData MovementTile;
            }


            [Header("Fundamental Detail")]
            public FundamentalDetailData FundamentalDetail;

            [Header("Functional Detail")]
            public FunctionalDetailData FunctionalDetail;
        }
        [Serializable] public struct MiddleLayerTileGroupData
        {
            [Serializable]
            public struct OnMiddleLayerDetailData
            {
                public PillarTileDetailData PillarTile;
                public BackgroundWallpaperTileDetailData BackgroundWallpaperTile;
            }
            [Serializable]
            public struct BetweenTheMiddleLayerDetailData
            {
                public FloatingDecorationPropTileDetailData FloatingDecorationPropTile;
            }


            [Header("On Middle Layer Tiles")]
            public OnMiddleLayerDetailData OnMiddleLayerData;

            [Header("Between The Middle Layer Tiles")]
            public BetweenTheMiddleLayerDetailData BetweenTheMiddleLayerData;
        }


        [Header("Main Layer Tile Group")]
        public MainLayerTileGroupData MainLayerTileGroup;

        [Header("Middle Layer Tile Group")]
        public MiddleLayerTileGroupData MiddleLayerTileGroup;
    }
    #endregion

    #region Detail Data
    [Serializable] public struct BasicCommonAreaTileDetailData
    {
        [Serializable] public struct BorderTileDetailData
        {
            [Header("Border Main Tiles")]
            public List<TileBase> BorderMainTiles;

            [Header("Border Edgy Tiles - Horizontal")]
            public List<TileBase> BorderUpperHozirontalEdgyTiles;
            public List<TileBase> BorderLowerHorizontalEdgyTiles;

            [Header("Border Edgy Tiles - Vertical")]
            public List<TileBase> BorderVerticalEdgyTiles;
        }
        [Serializable] public struct BackgroundTileDetailData
        {
            [Header("Background Main Tiles")]
            public List<TileBase> BackgroundMainTiles;

            [Header("Background Edgy Tiles - Horizontal")]
            public List<TileBase> BackgroundUpperHozirontalEdgyTiles;
            public List<TileBase> BackgroundLowerHorizontalEdgyTiles;

            [Header("Background Edgy Tiles - Vertical")]
            public List<TileBase> BackgroundVerticalEdgyTiles;
        }
        [Serializable] public struct ToGoBackLayerGateTileDetailData
        {
            [Header("To Go Back Layer Gate Main Tiles")]
            public List<TileBase> GateMainTiles;

            [Header("To Go Back Layer Gate Edgy Tiles - Horizontal")]
            public List<TileBase> GateUpperHorizontalEdgtTiles;
            public List<TileBase> GateLowerHorizontalEdgyTiles;

            [Header("To Go Back Layer Gate Edgy Tiles - Vertical")]
            public List<TileBase> GateVerticalEdgyTiles;
        }
        [Serializable] public struct ToGoFrontLayerGateTileDetailData
        {
            [Header("To Go Front Layer Gate Main Tiles")]
            public List<TileBase> GateMainTiles;

            [Header("To Go Front Layer Gate Edgy Tiles - Horizontal")]
            public List<TileBase> GateUpperHorizontalEdgtTiles;
            public List<TileBase> GateLowerHorizontalEdgyTiles;

            [Header("To Go Front Layer Gate Edgy Tiles - Vertical")]
            public List<TileBase> GateVerticalEdgyTiles;
        }
        [Serializable] public struct GateStairTileDetailData
        {
            [Header("Gate Stair Tiles")]
            public List<TileBase> GateStairTiles;
        }


        [Header("Border")]
        public BorderTileDetailData BorderTileData;

        [Header("Background")]
        public BackgroundTileDetailData BackgroundTileData;

        [Header("To Go Back Layer Gate")]
        public ToGoBackLayerGateTileDetailData ToGoBackLayerGateTileData;

        [Header("To Go Front Layer Gate")]
        public ToGoFrontLayerGateTileDetailData ToGoFrontLayerGateTileData;

        [Header("Gate Stair Tile")]
        public GateStairTileDetailData GateStairTileData;
    }
    [Serializable] public struct BasicDecorationAreaTileDetailData
    {
        [Serializable] public struct BackgroundTileDetailData
        {
            [Header("Background Main Tiles")]
            public List<TileBase> BackgroundMainTiles;

            [Header("Background Edgy Tiles - Horizontal")]
            public List<TileBase> BackgroundUpperHozirontalEdgyTiles;
            public List<TileBase> BackgroundLowerHorizontalEdgyTiles;

            [Header("Background Edgy Tiles - Vertical")]
            public List<TileBase> BackgroundVerticalEdgyTiles;
        }


        public List<BackgroundTileDetailData> BackgroundTileDetailDatas;
    }

    [Serializable] public struct FallingTileDetailData
    {

    }
    [Serializable] public struct ArrawTrapTileDetailData
    {

    }
    [Serializable] public struct SpearTrapTileDetailData
    {

    }
    [Serializable] public struct SpikeTrapTileDetailData
    {

    }

    [Serializable] public struct ChestTileDetailData
    {

    }
    [Serializable] public struct DoorTileDetailData
    {

    }
    [Serializable] public struct LadderTileDetailData
    {

    }

    [Serializable] public struct GlowTileDetailData
    {

    }

    [Serializable] public struct MovementTileDetailData
    {

    }

    [Serializable] public struct PillarTileDetailData
    {

    }
    [Serializable] public struct BackgroundWallpaperTileDetailData
    {
        
    }

    [Serializable] public struct FloatingDecorationPropTileDetailData
    {
        
    }
    #endregion
}