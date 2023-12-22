using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class ShopManager : SingletonDontDestroyMonoObject<ShopManager>
{
    private const string PLAYER_DATA_JSON_KEY = "a";
    public List<ShopItem> buyingList { get; set; }
    public Action action { get; set; }
    public List<PlayerDetailSO> PlayerDetailLists { get => playerDetailLists; set => playerDetailLists = value; }

    public void BoughtBringCharacters()
    {
        if (PlayerPrefs.HasKey(PLAYER_DATA_JSON_KEY))
        {
            string jsonValue = PlayerPrefs.GetString(PLAYER_DATA_JSON_KEY);
            buyingList = JsonConvert.DeserializeObject<List<ShopItem>>(jsonValue);
        }
        else
        {
            buyingList = new List<ShopItem>();
        }



    }
    public void SetDAta(ShopItem shopItems)
    {
        buyingList.Add(shopItems);
        action?.Invoke();
        string value = JsonConvert.SerializeObject(buyingList);
        PlayerPrefs.SetString(PLAYER_DATA_JSON_KEY, value);
    }


    private List<PlayerDetailSO> playerDetailLists = new List<PlayerDetailSO>();
    public System.Action<PlayerDetailSO> playerDetailListsAction;
    public void PlayerDetailSave(PlayerDetailSO playerDetailSO)
    {
        Debug.Log(playerDetailSO);
        PlayerDetailLists.Add(playerDetailSO);
        foreach (var item in PlayerDetailLists)
        {
            Debug.Log(item);
        }
        playerDetailListsAction?.Invoke(playerDetailSO);
    }
}
