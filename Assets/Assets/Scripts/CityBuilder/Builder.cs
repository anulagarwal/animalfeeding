using System;
using D2D.Databases;
using D2D.Utilities;
using UnityEngine;

namespace D2D
{
    public class Builder : MonoBehaviour
    {
        [SerializeField] private UpgradeChain _upgradeChain;
        [SerializeField] private Transform _buildPoint;

        public Upgrade NextUpgrade => 
            _upgradeChain[_currentLevel.Value + 1];

        public bool CanUpgrade => 
            _playerDatabase.MoneyContainer.Value >= _upgradeChain[_currentLevel.Value + 1].cost;

        public int CurrentLevel => _currentLevel.Value;

        private DataContainer<int> _currentLevel;

        private GameObject _lastBuilding;

        private PlayerDatabase _playerDatabase;

        private void Awake()
        {
            _currentLevel = new DataContainer<int>(gameObject.name, 1);
            
            _playerDatabase = this.FindLazy<PlayerDatabase>();
            
            Redraw();
        }
        
        public void LevelUp()
        {
            _currentLevel.Value++;
            
            float upgradeCost = _upgradeChain[_currentLevel.Value].cost;
            _playerDatabase.MoneyContainer.Value -= upgradeCost.Round();

            Redraw();
        }

        private void Redraw()
        {
            if (_lastBuilding != null)
                Destroy(_lastBuilding);

            GameObject newBuildingPrefab = _upgradeChain[_currentLevel.Value].prefab;
            _lastBuilding = Instantiate(newBuildingPrefab, 
                _buildPoint.position, _buildPoint.rotation, _buildPoint);
        }
    }
}