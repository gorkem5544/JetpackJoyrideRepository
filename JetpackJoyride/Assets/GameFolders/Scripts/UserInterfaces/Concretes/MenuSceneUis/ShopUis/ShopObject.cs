using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.MenuSceneUis.ShopUis.ShopButtons;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.MenuSceneUis.ShopUis
{
    public class ShopObject : MonoBehaviour
    {
        [SerializeField] ShopPanel _panel;
        [SerializeField] ShopPanelOpeningButton _shopPanelOpeningButton;
        [SerializeField] ShopPanelClosingButton _shopPanelClosingButton;

        public ShopPanelOpeningButton ShopPanelOpeningButton => _shopPanelOpeningButton;
        public ShopPanelClosingButton ShopPanelClosingButton => _shopPanelClosingButton;

        private void Start()
        {
            ChangePanelVisibility(false);
        }
        private void OnEnable()
        {
            _shopPanelOpeningButton.ShopPanelOpeningButtonClickedEvent += ChangePanelVisibility;
            _shopPanelClosingButton.ShopPanelClosingButtonClickedEvent += ChangePanelVisibility;
        }


        private void OnDisable()
        {
            _shopPanelOpeningButton.ShopPanelOpeningButtonClickedEvent -= ChangePanelVisibility;
            _shopPanelClosingButton.ShopPanelClosingButtonClickedEvent -= ChangePanelVisibility;

        }

        public void ChangePanelVisibility(bool canActive)
        {
            _panel.gameObject.SetActive(canActive);
        }
    }

}