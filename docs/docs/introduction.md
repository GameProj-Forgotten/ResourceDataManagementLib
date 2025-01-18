# Introduction
This library manages all data and resources of the Forgotten project.

In particular, it defines and provides interfaces for storing, loading, and accessing resources, Asset Files, etc.

<br>

Please note that this library is built based on .Net Framework 4.8.

<br><br>
<div align="center">
  <img src="https://github.com/user-attachments/assets/9f2e8c0d-7701-4050-ae0e-4d59992ec7b6" width="20%">
</div>
<br><br>

The representative functions provided by this library are as follows:
```
GameSaveData
└── struct GameSaveMetadata
MapGeneration
├── MapGenInputDataSpec
│   ├── [Flags] enum MapGenInputDataType : byte
│   ├── [Flags] enum PathDirection : byte
│   ├── [Flags]enum MapActiveType : byte
│   ├── struct AbstractInputDataSpec
│   ├── struct BasicMapGenInputDataSpec
│   ├── struct MiddleLayersInputDataSpec
│   └── struct RegionSelectionInputDataSpec
├── TileGroupAsset
│   ├── enum TileKind : byte
│   ├── sealed class TotalTileGroup : ScriptableObject
│   ├── sealed class SingleTileGroup : ScriptableObject
│   ├── struct BasicCommonAreaTileDetailData
│   ├── struct BasicDecorationAreaTileDetailData
│   ├── struct FallingTileDetailData
│   ├── struct ArrawTrapTileDetailData
│   ├── struct SpearTrapTileDetailData
│   ├── struct SpikeTrapTileDetailData
│   ├── struct ChestTileDetailData
│   ├── struct DoorTileDetailData
│   ├── struct LadderTileDetailData
│   ├── struct GlowTileDetailData
│   ├── struct MovementTileDetailData
│   ├── struct PillarTileDetailData
│   ├── struct BackgroundWallpaperTileDetailData
│   └── struct FloatingDecorationPropTileDetailData
├── DataAccessInterface
│   ├── static class MapGenInputResourceInterface
│   │   ├── static class AbstractInputDataInterface
│   │   ├── static class BasicMapGenInputDataInterface
│   │   ├── static class RegionSelectionInputDataInterface
│   │   └── static class MiddleLayersInputDataInterface
│   ├── static class GameSaveMetadataInterface
│   ├── static class MapGenOutputResourceInterface
│   └── static class TileBaseResourceInterface
└── DataSupplyAndSave
    ├── static class GameSaveMetadataSaver
    ├── static class GameSaveMetadataSupplier
    ├── static class MapGenDataSaver
    └── static class MapGenDataSupplier
SerializableType
├── struct SerializableVector2
├── struct SerializableVector3
└── struct SerializableVector4
```