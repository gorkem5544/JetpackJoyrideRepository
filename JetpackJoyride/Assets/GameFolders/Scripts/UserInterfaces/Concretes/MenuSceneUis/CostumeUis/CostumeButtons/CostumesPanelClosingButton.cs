using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.MenuSceneUis.CostumeUis.CostumeButtons
{
    public class CostumesPanelClosingButton : BaseButton
    {
        public System.Action<bool> CostumesPanelClosingButtonClickedEvent;

        protected override void ButtonOnClick()
        {
            CostumesPanelClosingButtonClickedEvent?.Invoke(false);
        }
    }
}