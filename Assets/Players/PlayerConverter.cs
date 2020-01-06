using System;
using Players.FollowCamera;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Players
{
    public class PlayerConverter : GameObjectToEntityConverter
    {
        [SerializeField] private float3 CameraPosition;
        [SerializeField] private float3 TargetOffset;
        
        
        public override void Convert(Entity entity, EntityManager dstManager,
            GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponent<FollowTargetComponent>(entity);
            dstManager.SetComponentData(entity, new FollowTargetComponent
            {
                CameraPosition = CameraPosition,
                TargetOffset = TargetOffset
            });
            base.Convert(entity, dstManager, conversionSystem);
        }
    }
}