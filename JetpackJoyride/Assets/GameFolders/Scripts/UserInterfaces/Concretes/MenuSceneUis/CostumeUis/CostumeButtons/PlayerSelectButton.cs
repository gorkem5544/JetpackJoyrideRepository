using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.MenuSceneUis.CostumeUis.CostumeButtons
{
    public class PlayerSelectButton : BaseButton
    {
        [SerializeField] public PlayerDetailSO _playerDetailSO;
        [SerializeField] Image _selectionImage;
        public System.Action<PlayerSelectButton> onClick;

        protected override void ButtonOnClick()
        {
            onClick?.Invoke(this);
            PlayerManager.Instance.SelectionPlayer(_playerDetailSO);
        }

        public void SetDefaultColor()
        {
            SetColorImage(Color.black);
        }
        public void SetSelectionColor()
        {
            SetColorImage(Color.yellow);
        }
        private void SetColorImage(Color color)
        {
            _selectionImage.color = color;
        }


    }

}