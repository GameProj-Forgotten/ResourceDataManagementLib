using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ResourceDataManagementLib.MapGeneration.MapGenInputDataSpec
{
    [Flags] public enum MapGenInputDataType : byte
    {
        AbstractInputData           = 0b0000_0001,
        BasicMapGenInputData        = 0b0000_0010,
        RegionSelectionInputData    = 0b0000_0100,
        MiddleLayersInputData       = 0b0000_1000,
    }
}