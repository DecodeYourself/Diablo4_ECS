using Players.FollowCamera;
using Unity.Entities;
using Unity.Mathematics;

namespace Players
{
    public class PlayerConverter : GameObjectToEntityConverter
    {
        public override void Convert(Entity entity, EntityManager dstManager,
            GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponent<FollowTargetComponent>(entity);
            dstManager.SetComponentData(entity, new FollowTargetComponent
            {
                CameraPosition = new float3(10, 10, 10),
                TargetOffset = new float3(0, 0, 0)
            });
            base.Convert(entity, dstManager, conversionSystem);
        }
    }
}