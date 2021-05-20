using D2D.Utilities;
using D2D.Utils;
using UnityEngine;

namespace D2D.Gameplay
{
    [RequireComponent(typeof(Physics))]
    public class RandomForcesApplier : MonoBehaviour
    {
        [SerializeField] private float _forceRange;
        [SerializeField] private float _torqueRange;

        private void Start()
        {
            var body = GetComponent<Rigidbody>();
            
            body.AddForce(DMath.RandomPointInsideBox(_forceRange), ForceMode.Impulse);
            body.AddTorque(DMath.RandomPointInsideBox(_torqueRange), ForceMode.Impulse);
        }
    }
}