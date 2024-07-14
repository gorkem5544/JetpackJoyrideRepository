using System;
using System.IO;
using Newtonsoft.Json;
using Unity.VisualScripting;
using UnityEngine;
public interface IGoldManager
{
    int PlayerReSpawnCost();
    void PlayerPrefsGetScore();
    System.Action<int> GoldChangedEvent { get; set; }
    int CurrentGold { get; }
    int GameInGoldAmount { get; }
    void IncreaseGameInGoldAmount(int amount);
    void DecreaseGameInGoldAmount(int amount);
    int SumGameAndMenuScore();
}

public class GoldManager : IGoldManager
{

    const string PLAYER_DATA_JSON_KEY = "PlayerDataJson";
    public Action<int> GoldChangedEvent { get; set; }

    private GoldDataSO _goldDataSO;
    private int _gameInGoldAmount;

    public GoldManager()
    {
        LoadGoldData();
    }

    public int CurrentGold => _goldDataSO?.GoldAmount ?? 0;
    public GoldDataSO GoldDataSO => _goldDataSO;

    public int GameInGoldAmount
    {
        get => _gameInGoldAmount;
        set
        {
            _gameInGoldAmount = value;
            SaveGoldData();
            GoldChangedEvent?.Invoke(_gameInGoldAmount);
        }
    }

    public void LoadGoldData()
    {
        _goldDataSO = JsonHelper.Load<GoldDataSO>(PLAYER_DATA_JSON_KEY) ?? new GoldDataSO { GoldAmount = 0 };
    }

    public void IncreaseGameInGoldAmount(int amount)
    {
        _gameInGoldAmount += amount;
        _goldDataSO.GoldAmount += amount;
        SaveGoldData();
        GoldChangedEvent?.Invoke(_goldDataSO.GoldAmount);
    }

    public void DecreaseGameInGoldAmount(int amount)
    {
        _gameInGoldAmount -= amount;
        _goldDataSO.GoldAmount -= amount;
        SaveGoldData();
        GoldChangedEvent?.Invoke(_goldDataSO.GoldAmount);
    }

    public void SaveGoldData()
    {
        JsonHelper.Save(PLAYER_DATA_JSON_KEY, _goldDataSO);
    }
    public int PlayerReSpawnCost()
    {
        throw new NotImplementedException();
    }

    public void PlayerPrefsGetScore()
    {
        throw new NotImplementedException();
    }

    public int SumGameAndMenuScore()
    {
        throw new NotImplementedException();
    }
}


public static class JsonHelper
{
    public static void Save<T>(string key, T data)
    {
        try
        {
            string json = JsonConvert.SerializeObject(data);
            PlayerPrefs.SetString(key, json);
            PlayerPrefs.Save();
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to save data to PlayerPrefs: {e}");
        }
    }

    public static T Load<T>(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            try
            {
                string json = PlayerPrefs.GetString(key);
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to load data from PlayerPrefs: {e}");
                return default;
            }
        }
        return default;
    }

    public static bool HasKey(string key)
    {
        return PlayerPrefs.HasKey(key);
    }

    public static void DeleteKey(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            PlayerPrefs.DeleteKey(key);
        }
    }
}