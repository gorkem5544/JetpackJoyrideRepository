using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShopPanel : MonoBehaviour
{
    [SerializeField] PlayerBuyButton[] _playerBuyButtons;
    private void Awake()
    {
        _playerBuyButtons = GetComponentsInChildren<PlayerBuyButton>();
    }

    private void Start()
    {
        // foreach (PlayerDetailSO item in PlayerManager.Instance.PlayerBuyingListSO._playerDetailSO)
        // {
        //     foreach (PlayerBuyButton button in _playerBuyButtons)
        //     {
        //         if (item == button._playerDetailSO)
        //         {
        //             button.gameObject.SetActive(false);
        //         }
        //     }
        // }
    }
}
