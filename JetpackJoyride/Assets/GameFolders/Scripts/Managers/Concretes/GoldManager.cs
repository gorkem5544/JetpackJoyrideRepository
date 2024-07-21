using System;
using System.IO;
using Newtonsoft.Json;
using Unity.VisualScripting;
using UnityEngine;
public interface IGoldManager
{

    void GameInIncreaseGoldAmount(int amount);
    System.Action<int> MenuInGoldChangedEvent { get; set; }
    System.Action<int> GameInGoldChangedEvent { get; set; }
    GoldData GoldData { get; }

    int CurrentGold { get; }
    int GameInGoldAmount { get; }
    //void IncreaseTotalGoldAmount(int amount);
    //void DecreaseGameInGoldAmount(int amount);

    void ResetGameInGoldAmount();
}

public class GoldManager : IGoldManager
{

    const string PLAYER_DATA_JSON_KEY = "PlayerDataJson";
    public Action<int> MenuInGoldChangedEvent { get; set; }
    public Action<int> GameInGoldChangedEvent { get; set; }

    private GoldData _goldData;
    private int _gameInCurrentGoldAmount;

    public GoldManager()
    {
        LoadGoldData();
    }

    public int CurrentGold => _goldData?.TotalGoldAmount ?? 0;

    public GoldData GoldData => _goldData;

    public int GameInGoldAmount => _gameInCurrentGoldAmount;



    public void LoadGoldData()
    {
        _goldData = JsonHelper.Load<GoldData>(PLAYER_DATA_JSON_KEY) ?? new GoldData() { GameInCurrentGoldAmount = 0, TotalGoldAmount = 0 };
    }
    private void SaveGoldData()
    {
        JsonHelper.Save(PLAYER_DATA_JSON_KEY, _goldData);
    }
    public void ResetGameInGoldAmount()
    {
        _goldData.GameInCurrentGoldAmount = 0;
        MenuInGoldChangedEvent?.Invoke(_goldData.GameInCurrentGoldAmount);
    }



    public void GameInIncreaseGoldAmount(int increaseAmount)
    {
        _goldData.GameInCurrentGoldAmount += increaseAmount;
        MenuInIncreaseGoldAmount(increaseAmount);
        SaveGoldData();
        GameInGoldChangedEvent?.Invoke(_goldData.GameInCurrentGoldAmount);
    }
    public void GameInDecreaseGoldAmount(int decreaseAmount)
    {
        _goldData.GameInCurrentGoldAmount -= decreaseAmount;
        SaveGoldData();
        GameInGoldChangedEvent?.Invoke(_goldData.GameInCurrentGoldAmount);
    }


    public void MenuInIncreaseGoldAmount(int increaseAmount)
    {
        _goldData.TotalGoldAmount += increaseAmount;
        MenuInGoldChangedEvent?.Invoke(_goldData.TotalGoldAmount);
    }
    public void MenuInDecreaseGoldAmount(int decreaseAmount)
    {
        _goldData.TotalGoldAmount -= decreaseAmount;
        SaveGoldData();
        MenuInGoldChangedEvent?.Invoke(_goldData.TotalGoldAmount);
    }

    public void GameInIncreaseGoldAmount()
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