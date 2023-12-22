using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "ShopItem", menuName = "JetpackJoyride/ShopItem", order = 0)]
public class ShopItem : ScriptableObject
{
    //public Color Color;
    //public Sprite Image;
    public int Price = 100;
    public bool IsPurchased = false;
    public PlayerTypeEnum playerTypeEnum;
}