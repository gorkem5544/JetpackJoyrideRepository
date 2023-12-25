using System;
using System.IO;
using Newtonsoft.Json;
using Unity.VisualScripting;
using UnityEngine;
public interface IGoldManger
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

public class GoldManager : SingletonDontDestroyMonoObject<GoldManager>, IGoldManger
{

    const string PLAYER_DATA_JSON_KEY = "PlayerDataJson";
    public Action<int> GoldChangedEvent { get; set; }


    GoldDataSO _goldDataSO;

    private int _currentGold;
    public int CurrentGold => _currentGold;
    public GoldDataSO GoldDataSO { get => _goldDataSO; set => _goldDataSO = value; }


    private int _gameInGoldAmount;
    public int GameInGoldAmount { get => _gameInGoldAmount; set => _gameInGoldAmount = value; }

    string jsonValue;
    private void Start()
    {

        PlayerPrefsGetScore();

    }

    public void PlayerPrefsGetScore()
    {
        if (PlayerPrefs.HasKey(PLAYER_DATA_JSON_KEY))
        {
            jsonValue = PlayerPrefs.GetString(PLAYER_DATA_JSON_KEY);
            _goldDataSO = JsonConvert.DeserializeObject<GoldDataSO>(jsonValue);
            Debug.Log(_goldDataSO.GoldAmount);
        }
        else
        {
            _goldDataSO = new GoldDataSO();
            _goldDataSO.GoldAmount = 0;
        }
    }


    public void IncreaseGameInGoldAmount(int amount)
    {
        _gameInGoldAmount += amount;
        _goldDataSO.GoldAmount += amount;
        GoldChangedEventMethod();
        SaveScore();
    }
    public void DecreaseGameInGoldAmount(int amount)
    {
        _gameInGoldAmount -= amount;
        _goldDataSO.GoldAmount -= amount;
        GoldChangedEventMethod();
        SaveScore();
    }
    private void SaveScore()
    {
        string value = JsonConvert.SerializeObject(_goldDataSO);
        PlayerPrefs.SetString(PLAYER_DATA_JSON_KEY, value);
    }
    private void GoldChangedEventMethod()
    {
        GoldChangedEvent.Invoke(_gameInGoldAmount);
    }
    public int SumGameAndMenuScore()
    {
        return _currentGold + _gameInGoldAmount;
    }
    public int PlayerReSpawnCost()
    {
        return 5 * PlayerManager.Instance.CurrentInstantiatePlayer.PlayerHealth.HitCount;
    }

}
