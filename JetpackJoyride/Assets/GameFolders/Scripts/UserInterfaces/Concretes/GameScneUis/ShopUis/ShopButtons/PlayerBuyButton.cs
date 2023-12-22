using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.ScriptableObjects.Concretes.PlayerScriptableObjects;
using UnityEngine;

public class PlayerBuyButton : BaseButton
{
    [SerializeField] public PlayerDetailSO _playerDetailSO;
    public System.Action<PlayerDetailSO> OnClicked;
    protected override void ButtonOnClick()
    {
        //OnClicked?.Invoke(_playerDetailSO);
        ShopManager.Instance.PlayerDetailSave(_playerDetailSO);
        Destroy(this.gameObject);
    }
}
