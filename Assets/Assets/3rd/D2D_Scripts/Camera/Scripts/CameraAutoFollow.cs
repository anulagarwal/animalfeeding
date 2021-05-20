using System;
using Cinemachine;
using D2D.Gameplay;
using UnityEngine;

namespace D2D.Cameras
{
    public class CameraAutoFollow : MonoBehaviour
    {
        [SerializeField] private bool _follow;
        [SerializeField] private bool _lookAt;

        private void OnValidate()
        {
            UpdateCameraTarget();
        }

        private void Start()
        {
            UpdateCameraTarget();
        }
        
        private void UpdateCameraTarget()
        {
            var vcam = GetComponent<CinemachineVirtualCamera>();
            var player = FindObjectOfType<CameraMark>();

            if (vcam == null || player == null)
                return;

            if (_follow)
                vcam.Follow = player.transform;

            if (_lookAt)
                vcam.LookAt = player.transform;
        }
    }
}
