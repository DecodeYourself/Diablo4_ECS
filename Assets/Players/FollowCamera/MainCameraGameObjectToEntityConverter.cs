using Unity.Entities;
using UnityEngine;

namespace Players.FollowCamera
{
    public class MainCameraGameObjectToEntityConverter : GameObjectToEntityConverter
    {
        public override void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponent<FollowCameraComponent>(entity);
            base.Convert(entity, dstManager, conversionSystem);
        }
    }
}