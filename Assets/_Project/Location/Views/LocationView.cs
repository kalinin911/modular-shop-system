using Core.Interfaces;
using Location.Controllers;
using Location.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Location.Views
{
    public class LocationView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _locationText;
        [SerializeField] private Button _cheatButton;
        
        private IPlayerData _playerData;
        private LocationController _controller;

        public void Initialize(IPlayerData playerData, LocationController controller)
        {
            _playerData = playerData;
            _controller = controller;

            var property = _playerData.GetProperty<string>(LocationKeys.Location);
            property.OnChanged += UpdateDisplay;
            UpdateDisplay(property.Value);
            
            _cheatButton.onClick.AddListener(OnCheatClicked);
        }

        private void UpdateDisplay(string value)
        {
            _locationText.text = $"Location: {value}";
        }
        
        private void OnCheatClicked()
        {
            _controller.ResetToDefault();
        }
        
        private void OnDestroy()
        {
            if (_playerData != null && _playerData.HasKey(LocationKeys.Location))
            {
                _playerData.GetProperty<string>(LocationKeys.Location).OnChanged -= UpdateDisplay;
            }
        }
    }
}