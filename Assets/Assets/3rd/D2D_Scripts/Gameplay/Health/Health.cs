using System;
using D2D.Utils;
using UnityEditor;
using UnityEngine;

namespace D2D.Gameplay
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float _maxPoints;
        [SerializeField] private HealthData _healthData;
        
        [Space(10)]
        
        [SerializeField] private GameObject _hitEffect;
        [SerializeField] private GameObject _deathEffect;

        public event Action Died;
        public event Action Damaged;
        public event Action PointsChanged;
        
        public GameObject LastAttacker { get; private set; }

        public float CurrentPoints
        {
            get => _currentPoints;
            private set
            {
                _currentPoints = value;
                PointsChanged?.Invoke();
            }
        }

        public float MaxPoints
        {
            private set => _maxPoints = value;
            get
            {
                if (!IsHealthDataMode) 
                    return _maxPoints;
                
                // If health data:
                
                if (_healthData == null)
                    throw new Exception("Health data is not attached!");

                return _healthData.maxPoints;
            }
        }

        public bool IsHealthDataMode;

        public bool ParticlesAreEnabled = true;

        [ContextMenu("Toggle data mode")]
        private void ToggleDataMode() => IsHealthDataMode = !IsHealthDataMode;

        [ContextMenu("Toggle effects")]
        private void ToggleEffects() => ParticlesAreEnabled = !ParticlesAreEnabled;

        private float _currentPoints;

        private void OnDrawGizmos()
        {
            if (_maxPoints <= 0)
                _maxPoints = 1;
        }

        private void Awake()
        {
            CurrentPoints = MaxPoints;
        }

        public void ApplyDamage(GameObject attacker, float damagePoints)
        {
            // Validate inputs
            if (damagePoints <= 0)
            {
                throw new Exception("Damage points should be positive!");
            }
            
            // Object is already died => return
            if (CurrentPoints <= 0)
                return;

            CurrentPoints -= damagePoints;
            LastAttacker = attacker;
            
            if (CurrentPoints > 0)
            {
                Spawn(_hitEffect);

                Damaged?.Invoke();
            }
            else
            {
                Spawn(_deathEffect);

                Died?.Invoke();
                Destroy(gameObject);
            }
        }

        private void Spawn(GameObject prefab)
        {
            if (prefab == null)
                return;
            
            GameObject instance = Instantiate(prefab, transform.position, 
                transform.rotation, null);
        }

        public void Heal(float healPoints)
        {
            if (healPoints <= 0)
                throw new Exception("Heal points should be positive!");

            CurrentPoints = Math.Max(CurrentPoints+healPoints, _maxPoints);
        }

        public void SetMaxPoints(float newMaxPoints, bool needRefill = false)
        {
            if (newMaxPoints <= 0)
                throw new Exception("Max points should be positive!");

            MaxPoints = newMaxPoints;
            
            if (needRefill)
                CurrentPoints = MaxPoints;
        }
    }
}