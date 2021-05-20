using D2D.Utilities;
using D2D.Utils;
using UnityEngine;

namespace D2D.Gameplay
{
    public class RandomSwiftApplier : MonoBehaviour
    {
        [SerializeField] private float _swiftRange;

        private void Start()
        {
            transform.position += DMath.RandomPointInsideBox(_swiftRange);
        }
    }
}
