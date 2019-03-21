using System;
using Unity.Collections;

[Serializable]
public struct Speed : Unity.Entities.IComponentData {

    public float Value;
    public float RValue;
    

}

public class MoveSpeedComponent : Unity.Entities.ComponentDataWrapper<Speed> { }
