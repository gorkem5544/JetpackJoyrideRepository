using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.Buttons.MenuButtons
{

    public class CostumesPanelOpeningButton : BaseButton
    {
        public System.Action CostumesPanelOpeningButtonClickedEvent;
        protected override void ButtonOnClick()
        {
            CostumesPanelOpeningButtonClickedEvent?.Invoke();

        }
    }

}