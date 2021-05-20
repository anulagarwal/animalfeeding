using System;
using UnityEngine;

namespace D2D.Utilities
{
    public class FPSBooster : MonoBehaviour
    {
        [SerializeField] private int _desiredFPS = 60;

        private void Start()
        {
            Application.targetFrameRate = _desiredFPS;
        
            // #if UNITY_EDITOR
            //     Debug.unityLogger.logEnabled = true;
            // #else
            //     Debug.unityLogger.logEnabled = false;
            // #endif
        }
    }
}