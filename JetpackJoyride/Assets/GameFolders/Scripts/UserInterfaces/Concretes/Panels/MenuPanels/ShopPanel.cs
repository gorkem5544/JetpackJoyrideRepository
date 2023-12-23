using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] List<PlayerPurchaseButton> playerDetailSOs = new List<PlayerPurchaseButton>();
    private void OnEnable()
    {
        foreach (var b in playerDetailSOs)
        {
            foreach (var a in ShopManager.Instance.PlayerDetailLists)
            {
                if (a.PlayerTypeEnum == b._playerDetailSO.PlayerTypeEnum)
                {
                    b.gameObject.SetActive(false);
                }
            }
        }
    }
}
