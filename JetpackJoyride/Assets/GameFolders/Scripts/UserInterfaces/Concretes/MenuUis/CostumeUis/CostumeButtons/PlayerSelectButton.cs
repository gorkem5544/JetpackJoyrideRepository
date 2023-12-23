using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerTypeEnum
{
    White, Yellow, Blue, Red
}
namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.Buttons.MenuButtons.CostumeButtons.CharacterSelection
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