using System;
using System.IO;
using Newtonsoft.Json;
using Unity.VisualScripting;
using UnityEngine;
public interface IGoldManger
{
    void IncreaseGoldAmount(int amount);
    void DecreaseGoldAmount(int amount);
    int PlayerReSpawnCost();
    void PlayerPrefsGetScore();
    System.Action<int> OnCoinChanged { get; set; }
    System.Action<int> GameInGoldChanged { get; set; }
    int CurrentGold { get; }
    int GameInGoldAmount { get; }
    void IncreaseGameInGoldAmount(int amount);
    void DecreaseGameInGoldAmount(int amount);
    int SumGameAndMenuScore();
}

public class GoldManager : SingletonDontDestroyMonoObject<GoldManager>, IGoldManger
{

    const string PLAYER_DATA_JSON_KEY = "PlayerDataJson";
    public Action<int> OnCoinChanged { get; set; }
    public Action<int> GameInGoldChanged { get; set; }

    PlayerManager _playerManager;
    public PlayerManager PlayerManager { get => _playerManager; set => _playerManager = value; }

    GoldDataSO _goldDataSO;

    private int _currentGold;
    public int CurrentGold => _currentGold;
    public GoldDataSO GoldDataSO { get => _goldDataSO; set => _goldDataSO = value; }


    private int _gameInGoldAmount;
    public int GameInGoldAmount { get => _gameInGoldAmount; set => _gameInGoldAmount = value; }

    string jsonValue;
    private void Start()
    {
        _playerManager = PlayerManager.Instance;
        PlayerPrefsGetScore();
        Debug.Log(_playerManager);
    }

    public void PlayerPrefsGetScore()
    {
        if (PlayerPrefs.HasKey(PLAYER_DATA_JSON_KEY))
        {
            // jsonValue = PlayerPrefs.GetString(PLAYER_DATA_JSON_KEY);
            //_playerManager.PlayerDataSO = JsonConvert.DeserializeObject<PlayerDataSO>(jsonValue);
            //_currentGold = _playerManager.PlayerDataSO.Score;
            jsonValue = PlayerPrefs.GetString(PLAYER_DATA_JSON_KEY);
            _goldDataSO = JsonConvert.DeserializeObject<GoldDataSO>(jsonValue);
            Debug.Log(_goldDataSO.GoldAmount);
        }
        else
        {
            //_playerManager.PlayerDataSO.Score = 0;
            _goldDataSO = new GoldDataSO();
            _goldDataSO.GoldAmount = 0;
        }
    }

    public void IncreaseGoldAmount(int amount)
    {
        _playerManager.PlayerDataSO.Score += amount;
        CoinChangedEvent();
    }
    public void DecreaseGoldAmount(int amount)
    {
        _playerManager.PlayerDataSO.Score -= amount;
        CoinChangedEvent();
    }

    public void IncreaseGameInGoldAmount(int amount)
    {
        _gameInGoldAmount += amount;
        _goldDataSO.GoldAmount += amount;
        CoinChangedEvent();
        GameInGoldChanged.Invoke(_gameInGoldAmount);
    }
    public void DecreaseGameInGoldAmount(int amount)
    {
        _gameInGoldAmount -= amount;
        _goldDataSO.GoldAmount -= amount;
        CoinChangedEvent();
        GameInGoldChanged.Invoke(_gameInGoldAmount);

    }
    private void CoinChangedEvent()
    {
        //string value = JsonConvert.SerializeObject(_playerManager.PlayerDataSO);
        //PlayerPrefs.SetString(PLAYER_DATA_JSON_KEY, value);
        string value = JsonConvert.SerializeObject(_goldDataSO);
        PlayerPrefs.SetString(PLAYER_DATA_JSON_KEY, value);
        Debug.Log(value);
        //PlayerPrefsGetScore();
        OnCoinChanged?.Invoke(_playerManager.PlayerDataSO.Score);

    }
    public int SumGameAndMenuScore()
    {
        return _currentGold + _gameInGoldAmount;
    }
    public int PlayerReSpawnCost()
    {
        Debug.Log(_playerManager.Player);
        return 10 * _playerManager.Player.PlayerHealth.HitCount;
    }
}
