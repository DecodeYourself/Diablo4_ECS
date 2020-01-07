using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace Players.FollowCamera
{
    public class FollowCameraSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            var followTargetEntity = GetSingletonEntity<FollowTargetComponent>();
            var translations = GetComponentDataFromEntity<Translation>();
            var followTargetComponents = GetComponentDataFromEntity<FollowTargetComponent>();

            var targetTranslation = translations[followTargetEntity];
            var followTarget = followTargetComponents[followTargetEntity];

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