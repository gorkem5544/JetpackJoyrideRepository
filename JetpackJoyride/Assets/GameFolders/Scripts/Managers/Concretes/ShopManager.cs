using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class ShopManager : SingletonDontDestroyMonoObject<ShopManager>
{
    private const string PURCHASED_COSTUME_JSON_KEY = "PurchasedCostumes";
    private List<PlayerDetailSO> _playerDetailLists = new List<PlayerDetailSO>();
    public List<PlayerDetailSO> PlayerDetailLists { get => _playerDetailLists; set => _playerDetailLists = value; }

    private void Start()
    {
        BoughtBringCharacters();
    }
    public void BoughtBringCharacters()
    {
        if (PlayerPrefs.HasKey(PURCHASED_COSTUME_JSON_KEY))
        {
            string jsonValue = PlayerPrefs.GetString(PURCHASED_COSTUME_JSON_KEY);
            _playerDetailLists = JsonConvert.DeserializeObject<List<PlayerDetailSO>>(jsonValue, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
        }
    }
    public void SetDAta()
    {
        string value = JsonConvert.SerializeObject(_playerDetailLists, new JsonSerializerSettings()
        {
            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        });
        PlayerPrefs.SetString(PURCHASED_COSTUME_JSON_KEY, value);
    }

    public void PlayerDetailSave(PlayerDetailSO playerDetailSO)
    {
        _playerDetailLists.Add(playerDetailSO);
        SetDAta();
    }
}
