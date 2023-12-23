using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.MenuSceneUis.CostumeUis.CostumeButtons
{
    public class PlayerSelectButton : BaseButton
    {
        [SerializeField] public PlayerDetailSO _playerDetailSO;

        protected override void ButtonOnClick()
        {
            PlayerManager.Instance.SelectionPlayer(_playerDetailSO);
        }


    }

}