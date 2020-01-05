using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Players.FollowCamera
{
    public class FollowCameraSystem : ComponentSystem
    {
        // protected override void OnCreate()

        // {

        //     Translation targetTranslation = default;

        //     FollowTargetComponent followTarget = default;

        //     Entities.ForEach((ref FollowTargetComponent followTargetComponent, ref Translation translation) =>

        //     {

        //         targetTranslation = translation;

        //         followTarget = followTargetComponent;

        //     });

        //

        //     Entities.ForEach((Transform cameraTranslation, ref FollowCameraComponent cameraComponent) =>

        //     {

        //         cameraTranslation.position = targetTranslation.Value + followTarget.CameraPosition;

        //         cameraTranslation.rotation = quaternion.Euler(Vector3.Angle(cameraTranslation.position, targetTranslation.Value));

        //     });

        // }
        
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
                cameraTranslation.position = targetTranslation.Value + followTarget.CameraPosition;

                var relativePos = targetTranslation.Value - (float3) cameraTranslation.position;
                cameraTranslation.rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            });
        }
    }
}