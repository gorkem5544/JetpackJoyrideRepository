using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanelOpeningButton : BaseButton
{
    public System.Action ShopPanelOpeningButtonClickedEvent;
    protected override void ButtonOnClick()
    {
        ShopPanelOpeningButtonClickedEvent?.Invoke();

    }
}