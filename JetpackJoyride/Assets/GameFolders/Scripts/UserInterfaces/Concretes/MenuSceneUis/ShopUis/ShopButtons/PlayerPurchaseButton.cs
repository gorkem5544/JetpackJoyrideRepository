using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using Newtonsoft.Json;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.MenuSceneUis.ShopUis.ShopButtons
{
    public class PlayerPurchaseButton : BaseButton
    {
        [SerializeField] public PlayerDetailSO _playerDetailSO;
        private GoldManager _goldManager;

        public void Installer(GoldManager goldManager)
        {
            _goldManager = goldManager;
        }
        protected override void ButtonOnClick()
        {
            _goldManager.LoadGoldData();
            if (_goldManager.GoldData.TotalGoldAmount > 1000)
            {
                _goldManager.MenuInDecreaseGoldAmount(1000);
                ShopManager.Instance.PlayerDetailSave(_playerDetailSO);
                gameObject.SetActive(false);
            }
        }
    }

}