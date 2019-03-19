using System;
using Unity.Collections;

[Serializable]
public struct Speed : Unity.Entities.IComponentData {

    public float Value;

}

public class MoveSpeedComponent : Unity.Entities.ComponentDataWrapper<Speed> { }
