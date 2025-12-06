using System;
using Shop.Config;
using Shop.Controllers;
using UnityEngine;

namespace Shop.Views
{
    public class ShopView : MonoBehaviour
    {
        [SerializeField] private Transform _bundleContainer;
        [SerializeField] private BundleCardView _bundleCardPrefab;

        private ShopController _controller;

        public event Action<BundleConfig> OnBundleInfoClicked;

        public void Initialize(ShopController controller)
        {
            _controller = controller;
            SpawnBundleCards();
        }

        private void SpawnBundleCards()
        {
            foreach (var bundle in _controller.GetBundles())
            {
                var card = Instantiate(_bundleCardPrefab, _bundleContainer);
                card.Initialize(bundle, _controller);
                card.OnInfoClicked += (b) => OnBundleInfoClicked?.Invoke(b);
            }
        }
    }
}