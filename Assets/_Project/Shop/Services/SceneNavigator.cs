using Shop.Config;
using UnityEngine.SceneManagement;

namespace Shop.Services
{
    public static class SceneNavigator
    {
        private const string ShopListScene = "ShopListScene";
        private const string DetailScene = "BundleDetailScene";
        
        public static BundleConfig SelectedBundle { get; private set; }

        public static void OpenBundleDetail(BundleConfig bundle)
        {
            SelectedBundle = bundle;
            SceneManager.LoadScene(DetailScene);
        }

        public static void ReturnToShopList()
        {
            SelectedBundle = null;
            SceneManager.LoadScene(ShopListScene);
        }
    }
}