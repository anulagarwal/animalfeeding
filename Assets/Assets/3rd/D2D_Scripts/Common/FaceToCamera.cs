using System;
using UnityEngine;

namespace D2D
{
    public class FaceToCamera : MonoBehaviour
    {
        private void Update()
        {
            transform.LookAt(Camera.main.transform);
        }
    }
}