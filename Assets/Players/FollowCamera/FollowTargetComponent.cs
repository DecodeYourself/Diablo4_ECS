using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public struct FollowTargetComponent : IComponentData
{
    public float3 TargetOffset;
    public float3 CameraPosition;
}
