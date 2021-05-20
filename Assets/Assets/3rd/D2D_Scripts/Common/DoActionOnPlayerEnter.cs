using D2D.Gameplay;
using D2D.Utilities;
using D2D.Utils;
using UltEvents;
using UnityEngine;

namespace D2D
{
    public class DoActionOnPlayerEnter : MonoBehaviour
    {
        [SerializeField] private UltEvent _action;

        private int _playerEntersCount;

        private void OnTriggerEnter(Collider other)
        {
            if (other.Is<Player>() && _playerEntersCount == 0)
            {
                _playerEntersCount++;
                _action?.Invoke();
            }
        }
    }
}