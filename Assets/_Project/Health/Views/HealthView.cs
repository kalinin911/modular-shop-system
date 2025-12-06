using _Project.Health.Controllers;
using Core.Interfaces;
using Health.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Health.Views
{
    public class HealthView :MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _healthText;
        [SerializeField] private Button _cheatButton;
        [SerializeField] private int _cheatAmount = 50;
        
        private IPlayerData _playerData;
        private HealthController _controller;

        public void Initialize(IPlayerData playerData, HealthController controller)
        {
            _playerData = playerData;
            _controller = controller;

            var property = _playerData.GetProperty<int>(HealthKeys.Health);
            property.OnChanged += UpdateDisplay;
            UpdateDisplay(property.Value);
            
            _cheatButton.onClick.AddListener(OnCheatClicked);
        }

        private void UpdateDisplay(int value)
        {
            _healthText.text = $"Health: {value}";
        }

        private void OnCheatClicked()
        {
            _controller.AddHealth(_cheatAmount);
        }

        private void OnDestroy()
        {
            if (_playerData != null && _playerData.HasKey(HealthKeys.Health))
            {
                _playerData.GetProperty<int>(HealthKeys.Health).OnChanged -= UpdateDisplay;
            }
        }
    }
}