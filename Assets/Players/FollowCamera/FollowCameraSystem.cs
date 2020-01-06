using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Players.FollowCamera
{
    public class FollowCameraSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            Translation targetTranslation = default;
            FollowTargetComponent followTarget = default;
            Entities.ForEach((ref FollowTargetComponent followTargetComponent, ref Translation translation) =>
            {
                targetTranslation = translation;
                followTarget = followTargetComponent;
            });

            Entities.ForEach((Transform cameraTranslation, ref FollowCameraComponent cameraComponent) =>
            {
                var newCameraPosition = targetTranslation.Value + followTarget.CameraPosition;
                var relativePos = targetTranslation.Value - newCameraPosition;
                cameraTranslation.rotation = Quaternion.LookRotation(relativePos, Vector3.up) *
                                             Quaternion.Euler(followTarget.TargetOffset);
                cameraTranslation.position = newCameraPosition;
            });
        }
    }
}