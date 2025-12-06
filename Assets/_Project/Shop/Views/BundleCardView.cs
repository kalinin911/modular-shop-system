using System;
using Shop.Config;
using Shop.Controllers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop.Views
{
    public class BundleCardView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private Button _buyButton;
        [SerializeField] private Button _infoButton;
        [SerializeField] private TextMeshProUGUI _buyButtonText;

        private BundleConfig _bundle;
        private ShopController _controller;
        private bool _isPurchasing;

        public event Action<BundleConfig> OnInfoClicked;

        public void Initialize(BundleConfig bundle, ShopController controller)
        {
            _bundle = bundle;
            _controller = controller;
            
            _nameText.text = _bundle.Name;
            
            _buyButton.onClick.AddListener(OnBuyClicked);
            _infoButton?.onClick.AddListener(() => OnInfoClicked?.Invoke(_bundle));
        }

        private void OnBuyClicked()
        {
            if (_isPurchasing) return;
            
            _controller.TryPurchase(_bundle);
        }

        private void HandlePurchaseStarted(BundleConfig bundle)
        {
            if (bundle != _bundle) return;

            _isPurchasing = true;
            _buyButton.interactable = false;
            _buyButtonText.text = "Working...";
        }

        private void HandlePurchaseCompleted(BundleConfig bundle, bool success)
        {
            if(bundle != _bundle) return;
            
            _isPurchasing = false;
            _buyButtonText.text = "Buy";
            UpdateAffordability();
        }

        private void UpdateAffordability()
        {
            if(_isPurchasing) return;

            _buyButton.interactable = _controller.CanAfford(_bundle);
        }

        public void HideInfoButton()
        {
            if (_infoButton != null)
                _infoButton.gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            if (_controller == null) return;
            
            _controller.OnPurchaseStarted -= HandlePurchaseStarted;
            _controller.OnPurchaseCompleted -= HandlePurchaseCompleted;
            _controller.OnAffordabilityChanged -= UpdateAffordability;
        }
    }
}