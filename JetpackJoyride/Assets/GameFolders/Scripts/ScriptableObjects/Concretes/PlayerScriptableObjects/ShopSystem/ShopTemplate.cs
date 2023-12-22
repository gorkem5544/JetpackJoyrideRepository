using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTemplate : BaseButton
{
    [SerializeField] private ShopItem shopItem;
    public System.Action<ShopItem> action;

    public ShopItem ShopItem { get => shopItem; set => shopItem = value; }

    protected override void ButtonOnClick()
    {
        Debug.Log("A");
        ShopManager.Instance.SetDAta(shopItem);
        Destroy(this.gameObject);
        //action?.Invoke(ShopItem);
    }
}
