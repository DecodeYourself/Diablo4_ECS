using Unity.Entities;
using UnityEngine;

namespace Players.FollowCamera
{
    public abstract class GameObjectToEntityConverter : MonoBehaviour, IConvertGameObjectToEntity
    {
        public virtual void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.SetName(entity, gameObject.name);
        }
    }
}