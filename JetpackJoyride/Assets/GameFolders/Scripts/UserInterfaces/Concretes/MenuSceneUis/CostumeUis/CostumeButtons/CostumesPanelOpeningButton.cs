using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.MenuSceneUis.CostumeUis.CostumeButtons
{
    public class CostumesPanelOpeningButton : BaseButton
    {
        public System.Action<bool> CostumesPanelOpeningButtonClickedEvent;
        protected override void ButtonOnClick()
        {
            CostumesPanelOpeningButtonClickedEvent?.Invoke(true);
        }
    }
}