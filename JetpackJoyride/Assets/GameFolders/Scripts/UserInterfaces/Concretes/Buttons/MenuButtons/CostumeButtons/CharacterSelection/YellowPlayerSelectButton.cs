using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerTypeEnum
{
    White, Yellow, Blue, Red
}
namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.Buttons.MenuButtons.CostumeButtons.CharacterSelection
{
    public class YellowPlayerSelectButton : BaseButton
    {
        [SerializeField] PlayerDetailSO _playerDetailSO;

        public PlayerDetailSO PlayerDetailSO { get => _playerDetailSO; set => _playerDetailSO = value; }

        protected override void ButtonOnClick()
        {
            PlayerManager.Instance.SelectionPlayer(_playerDetailSO);
        }


    }

}