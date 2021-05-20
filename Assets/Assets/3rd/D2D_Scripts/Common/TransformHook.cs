using System;
using UnityEngine;

namespace D2D.Common
{
    /// <summary>
    /// Laggy and deprecated stuff, not so good to use.
    /// </summary>
    public class TransformHook : MonoBehaviour
    {
        [SerializeField] private Transform target;
        public bool hookRotation = true;
        public bool deattachParentOnStart = true;
        public bool useInitialSwift = true;
        public bool destroyOnParentNull = true;

        public event Action Unhooked;

        public Transform Target
        {
            set
            {
                if (deattachParentOnStart)
                    transform.parent = null;

                IsHooked = transform.parent != null;

                target = value;
            }
        }

        public bool IsHooked { get; private set; }

        private Vector3 initialSwift;

        private void Start()
        {
            if (useInitialSwift)
                initialSwift = transform.position - target.position;

            Target = target;
        }

        private void Update()
        {
            if (target == null)
            {
                if (IsHooked)
                    Unhooked?.Invoke();

                IsHooked = false;

                if (destroyOnParentNull)
                    Destroy(gameObject);

                return;
            }

            transform.position = target.position + initialSwift;

            if (hookRotation)
                transform.rotation = target.rotation;
        }
    }
}