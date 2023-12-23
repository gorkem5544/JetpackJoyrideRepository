using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.MenuSceneUis.ShopUis.ShopButtons
{
    public class PlayerPurchaseButton : BaseButton
    {
        [SerializeField] public PlayerDetailSO _playerDetailSO;
        protected override void ButtonOnClick()
        {
            if (GoldManager.Instance.GoldDataSO.GoldAmount > 10)
            {
                ShopManager.Instance.PlayerDetailSave(_playerDetailSO);
                gameObject.SetActive(false);
            }
        }
    }

}