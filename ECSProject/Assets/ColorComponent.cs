using System;
using Unity.Collections;
using Unity.Mathematics;

[Serializable]
public struct Color : Unity.Entities.IComponentData
{

    public float3 Value;

}

public class ColorComponent : Unity.Entities.ComponentDataWrapper<Color> { }
