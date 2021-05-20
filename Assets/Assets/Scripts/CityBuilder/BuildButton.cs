using System;
using D2D.Databases;
using D2D.UI;
using D2D.Utilities;
using TMPro;
using UnityEngine;

namespace D2D
{
    public class BuildButton : DButton
    {
        [SerializeField] private Builder _attachedBuilder;
        [SerializeField] private TMP_Text _costLabel;
        [SerializeField] private TMP_Text _levelLabel;

        private PlayerDatabase _playerDatabase;

        private void OnEnable()
        {
            _playerDatabase = this.FindLazy<PlayerDatabase>();
            
            _playerDatabase.MoneyContainer.Changed += UpdateButtonState;
            Clicked += LevelUp;

            UpdateButtonState(0);
        }

        private void OnDisable()
        {
            _playerDatabase.MoneyContainer.Changed -= UpdateButtonState;
            Clicked -= LevelUp;
        }
        
        private void UpdateButtonState(float money)
        {
            IsInteractive = _attachedBuilder.CanUpgrade;
            
            _costLabel.text = _attachedBuilder.NextUpgrade.cost + "";
            _levelLabel.text = $"Level: {_attachedBuilder.CurrentLevel}";
        }

        private void LevelUp()
        {
            _attachedBuilder.LevelUp();
        }
    }
}