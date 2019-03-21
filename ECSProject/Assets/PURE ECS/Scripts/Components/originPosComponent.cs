﻿using System;
using Unity.Entities;
using Unity.Mathematics;

namespace Unity.Transforms
{
    /// <summary>
    /// If Attached, in local space (relative to parent)
    /// If not Attached, in world space.
    /// </summary>
    [Serializable]
    public struct originPosition : IComponentData
    {
        public float3 Value;
    }

    [UnityEngine.DisallowMultipleComponent]
    public class originPosComponent : ComponentDataWrapper<originPosition>
    {
    }
}
