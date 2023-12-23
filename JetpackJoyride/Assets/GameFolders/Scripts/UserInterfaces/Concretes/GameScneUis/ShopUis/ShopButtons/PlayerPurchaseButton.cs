using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.ScriptableObjects.Concretes.PlayerScriptableObjects;
using UnityEngine;

public class PlayerPurchaseButton : BaseButton
{
    [SerializeField] public PlayerDetailSO _playerDetailSO;
    protected override void ButtonOnClick()
    {
        ShopManager.Instance.PlayerDetailSave(_playerDetailSO);
        gameObject.SetActive(false);
    }
}
