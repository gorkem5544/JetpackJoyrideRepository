using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using Newtonsoft.Json;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.MenuSceneUis.ShopUis.ShopButtons
{
    public class PlayerPurchaseButton : BaseButton
    {
        const string PLAYER_DATA_JSON_KEY = "PlayerDataJson";
        [SerializeField] public PlayerDetailSO _playerDetailSO;
        private GoldManager _goldManager;

        public void Installer(GoldManager goldManager)
        {
            _goldManager = goldManager;
        }
        protected override void ButtonOnClick()
        {
            _goldManager.LoadGoldData();
            GoldDataSO _goldDataSO = JsonHelper.Load<GoldDataSO>(PLAYER_DATA_JSON_KEY) ?? new GoldDataSO { GoldAmount = 0 };
            Debug.Log("aa");
            if (_goldManager.CurrentGold > 1000)
            {
                Debug.Log("bb"); _goldManager.DecreaseGameInGoldAmount(1000);
                Debug.Log(_goldManager.CurrentGold);
                ShopManager.Instance.PlayerDetailSave(_playerDetailSO);
                gameObject.SetActive(false);
            }
        }
    }

}