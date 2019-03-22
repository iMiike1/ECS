using System;
using Unity.Collections;
using Unity.Mathematics;

[Serializable]
public struct Color : Unity.Entities.IComponentData
{

    public float3 Value;
    private float v1;
    private float v2;
    private float v3;
    private float v4;

    public Color(float v1, float v2, float v3, float v4) : this()
    {
        this.v1 = v1;
        this.v2 = v2;
        this.v3 = v3;
        this.v4 = v4;
    }
}

public class ColorComponent : Unity.Entities.ComponentDataWrapper<Color> { }
