using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.MenuSceneUis.ShopUis.ShopButtons
{
    public class ShopPanelClosingButton : BaseButton
    {
        public System.Action<bool> ShopPanelClosingButtonClickedEvent;
        protected override void ButtonOnClick()
        {
            ShopPanelClosingButtonClickedEvent?.Invoke(false);

        }
    }
}