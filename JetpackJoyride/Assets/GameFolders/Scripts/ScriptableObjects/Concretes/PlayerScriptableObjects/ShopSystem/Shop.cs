using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private const string PLAYER_DATA_JSON_KEY = "a";

    public List<ShopItem> shopItems;
    List<ShopItem> buyingList;
    [SerializeField] ShopTemplate[] _shopTemplates;
    [SerializeField] Transform _parent;

    private void Start()
    {
        ShopManager.Instance.BoughtBringCharacters();
        foreach (ShopTemplate item in _shopTemplates)
        {
            Debug.Log("Girdi");
            //item.action += HandleOn;
        }
    }
    private void OnDisable()
    {
        foreach (ShopTemplate item in _shopTemplates)
        {
            // item.action -= HandleOn;
        }
    }
    private void HandleOn(ShopItem ıtem)
    {
        buyingList.Add(ıtem);
        // string value = JsonConvert.SerializeObject(buyingList);
        // PlayerPrefs.SetString(PLAYER_DATA_JSON_KEY, value);

        //ShopManager.Instance.SetDAta(buyingList);
    }
    public void GetList()
    {
        if (PlayerPrefs.HasKey(PLAYER_DATA_JSON_KEY))
        {
            // jsonValue = PlayerPrefs.GetString(PLAYER_DATA_JSON_KEY);
            //_playerManager.PlayerDataSO = JsonConvert.DeserializeObject<PlayerDataSO>(jsonValue);
            //_currentGold = _playerManager.PlayerDataSO.Score;
            string jsonValue = PlayerPrefs.GetString(PLAYER_DATA_JSON_KEY);
            buyingList = JsonConvert.DeserializeObject<List<ShopItem>>(jsonValue);

        }
        else
        {
            //_playerManager.PlayerDataSO.Score = 0;
            buyingList = new List<ShopItem>();
        }
    }

}
