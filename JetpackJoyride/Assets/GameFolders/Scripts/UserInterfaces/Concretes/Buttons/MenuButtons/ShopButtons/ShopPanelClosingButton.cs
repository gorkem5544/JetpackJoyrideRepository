using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanelClosingButton : BaseButton
{
    public System.Action<bool> ShopPanelClosingButtonClickedEvent;
    protected override void ButtonOnClick()
    {
        ShopPanelClosingButtonClickedEvent?.Invoke(false);

    }
}