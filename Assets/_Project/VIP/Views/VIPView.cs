using System;
using Core.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VIP.Controllers;
using VIP.Data;

namespace VIP.Views
{
    public class VIPView :MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _vipText;
        [SerializeField] private Button _cheatButton;
        [SerializeField] private int _cheatSeconds = 60;

        private IPlayerData _playerData;
        private VIPController _controller;

        public void Initialize(IPlayerData playerData, VIPController controller)
        {
            _playerData = playerData;
            _controller = controller;

            var property = _playerData.GetProperty<TimeSpan>(VIPKeys.VIP);
            property.OnChanged += UpdateDisplay;
            UpdateDisplay(property.Value);

            _cheatButton.onClick.AddListener(OnCheatClicked);
        }

        private void UpdateDisplay(TimeSpan value)
        {
            _vipText.text = $"VIP: {(int)value.TotalSeconds} sec";
        }

        private void OnCheatClicked()
        {
            _controller.AddTime(_cheatSeconds);
        }

        private void OnDestroy()
        {
            if (_playerData != null && _playerData.HasKey(VIPKeys.VIP))
            {
                _playerData.GetProperty<TimeSpan>(VIPKeys.VIP).OnChanged -= UpdateDisplay;
            }
        }
    }
}