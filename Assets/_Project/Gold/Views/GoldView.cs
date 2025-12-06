using Gold.Controllers;
using Core.Interfaces;
using Gold.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gold.Views
{
    public class GoldView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _goldText;
        [SerializeField] private Button _cheatButton;
        [SerializeField] private int _cheatAmount = 50;
        
        private IPlayerData _playerData;
        private GoldController _controller;

        public void Initialize(IPlayerData playerData, GoldController controller)
        {
            _playerData = playerData;
            _controller = controller;

            var property = _playerData.GetProperty<int>(GoldKeys.Gold);
            property.OnChanged += UpdateDisplay;
            UpdateDisplay(property.Value);
            
            _cheatButton.onClick.AddListener(OnCheatClicked);
        }

        private void UpdateDisplay(int value)
        {
            _goldText.text = $"Gold: {value}";
        }

        private void OnCheatClicked()
        {
            _controller.AddGold(_cheatAmount);
        }
        
        private void OnDestroy()
        {
            if (_playerData != null && _playerData.HasKey(GoldKeys.Gold))
            {
                _playerData.GetProperty<int>(GoldKeys.Gold).OnChanged -= UpdateDisplay;
            }
        }
    }
}