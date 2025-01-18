using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

using CommonUtilLib.ThreadSafe;

using ResourceDataManagementLib.MapGeneration.MapGenInputDataSpec;


namespace ResourceDataManagementLib.MapGeneration.DataBuffer
{
    internal sealed class MapGenInputResourceBuffer : SingleTon<MapGenInputResourceBuffer>, IDisposable
    {
        private AbstractInputDataSpec? m_abstractInputData;
        private BasicMapGenInputDataSpec? m_basicMapGenInputData;
        private RegionSelectionInputDataSpec? m_regionSelectionInputData;
        private MiddleLayersInputDataSpec? m_middleLayersInputData;


        ~MapGenInputResourceBuffer()
        {
            Dispose(false);
        }

        internal bool BIsAbstractInputDataLoaded { get; set; } = false;
        internal bool BIsBasicMapGenInputDataLoaded { get; set; } = false;
        internal bool BIsRegionSelectionInputDataLoaded { get; set; } = false;
        internal bool BIsMiddleLayersInputDataLoaded { get; set; } = false;

        internal AbstractInputDataSpec AbstractInputDataInstance
        {
            get
            {
                if(!BIsAbstractInputDataLoaded)
                {
                    throw new InvalidOperationException("AbstractInputDataSpec is not loaded yet.");
                }

                return m_abstractInputData.Value;
            }
            set
            {
                if(value.BIsValid())
                {
                    m_abstractInputData = value;
                    BIsAbstractInputDataLoaded = true;
                }
            }
        }
        internal BasicMapGenInputDataSpec BasicMapGenInputDataInstance
        {
            get
            {
                if (!BIsBasicMapGenInputDataLoaded)
                {
                    throw new InvalidOperationException("BasicMapGenInputDataSpec is not loaded yet.");
                }

                return m_basicMapGenInputData.Value;
            }
            set
            {
                if (value.BIsValid())
                {
                    m_basicMapGenInputData = value;
                    BIsBasicMapGenInputDataLoaded = true;
                }
            }
        }
        internal RegionSelectionInputDataSpec RegionSelectionInputDataInstance
        {
            get
            {
                if (!BIsRegionSelectionInputDataLoaded)
                {
                    throw new InvalidOperationException("RegionSelectionInputDataSpec is not loaded yet.");
                }

                return m_regionSelectionInputData.Value;
            }
            set
            {
                if (value.BIsValid())
                {
                    m_regionSelectionInputData = value;
                    BIsRegionSelectionInputDataLoaded = true;
                }
            }
        }
        internal MiddleLayersInputDataSpec MiddleLayersInputDataInstance
        {
            get
            {
                if (!BIsMiddleLayersInputDataLoaded)
                {
                    throw new InvalidOperationException("MiddleLayersInputDataSpec is not loaded yet.");
                }

                return m_middleLayersInputData.Value;
            }
            set
            {
                if (value.BIsValid())
                {
                    m_middleLayersInputData = value;
                    BIsMiddleLayersInputDataLoaded = true;
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
                m_abstractInputData = null;
                m_basicMapGenInputData = null;
                m_regionSelectionInputData = null;
                m_middleLayersInputData = null;

                BIsAbstractInputDataLoaded = false;
                BIsBasicMapGenInputDataLoaded = false;
                BIsRegionSelectionInputDataLoaded = false;
                BIsMiddleLayersInputDataLoaded = false;
            }
        }
    }
}