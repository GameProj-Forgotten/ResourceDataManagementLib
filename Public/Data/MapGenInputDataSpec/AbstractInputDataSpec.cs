using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;


namespace ResourceDataManagementLib.MapGeneration.MapGenInputDataSpec
{
    [Flags] public enum PathDirection : byte
    {
        None    = 0b0000_0000,
        Origin  = 0b0000_0001,
        Left    = 0b0000_0010,
        Right   = 0b0000_0100,
        Front   = 0b0000_1000,
        Back    = 0b0001_0000,
        Top     = 0b0010_0000,
        Bottom  = 0b0100_0000,
    }

    public struct AbstractInputDataSpec
    {
        public Vector3Int SingleChunkSize, MapSize;
        public Vector2Int SingleRoomSize;

        public Dictionary<Guid, string> AreaNameTable;


        internal static Vector3Int DefaultSingleChunkSize
        {
            get
            {
                return new Vector3Int(50, 1, 50);
            }
        }
        internal static Vector3Int DefaultMapSize
        {
            get
            {
                return new Vector3Int(1, 3, 1);
            }
        }

        internal static Vector2Int DefaultSingleRoomSize
        {
            get
            {
                return new Vector2Int(24, 24);
            }
        }

        internal static int MaxAreaCount
        {
            get
            {
                return 20;
            }
        }
    }

    public static class AbstractInputDataSpecExtension
    {
        public static void Init(ref this AbstractInputDataSpec inputData)
        {
            inputData.SingleChunkSize = AbstractInputDataSpec.DefaultSingleChunkSize;
            inputData.MapSize = AbstractInputDataSpec.DefaultMapSize;
            inputData.SingleRoomSize = AbstractInputDataSpec.DefaultSingleRoomSize;

            inputData.AreaNameTable = new Dictionary<Guid, string>();
        }

        public static bool BIsValid(in this AbstractInputDataSpec inputData)
        {
            if(inputData.SingleChunkSize.x <= 0 || inputData.SingleChunkSize.y <= 0 || inputData.SingleChunkSize.z <= 0)
            {
                return false;
            }
            if (inputData.MapSize.x <= 0 || inputData.MapSize.y <= 0 || inputData.MapSize.z <= 0)
            {
                return false;
            }
            if (inputData.SingleRoomSize.x <= 0 || inputData.SingleRoomSize.y <= 0)
            {
                return false;
            }

            if (inputData.AreaNameTable.Count > AbstractInputDataSpec.MaxAreaCount)
            {
                return false;
            }

            return true;
        }
    }
}