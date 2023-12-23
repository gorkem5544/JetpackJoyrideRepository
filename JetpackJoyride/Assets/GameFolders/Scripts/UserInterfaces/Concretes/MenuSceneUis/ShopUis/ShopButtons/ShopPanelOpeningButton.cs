using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.MenuSceneUis.ShopUis.ShopButtons
{
    public class ShopPanelOpeningButton : BaseButton
    {
        public System.Action<bool> ShopPanelOpeningButtonClickedEvent;
        protected override void ButtonOnClick()
        {
            ShopPanelOpeningButtonClickedEvent?.Invoke(true);

        }
    }
}