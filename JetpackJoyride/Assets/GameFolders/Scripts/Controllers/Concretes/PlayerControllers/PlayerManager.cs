using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;


public class PlayerManager : SingletonDontDestroyMonoObject<PlayerManager>, IPlayerManager
{
    private const string PLAYER_DATA_JSON_KEY = "BuyingPlayer";
    private PlayerController _playerController;
    public PlayerController Player => _playerController;
    public PlayerController PlayerController { get; set; }

    [SerializeField] PlayerDataSO _playerDataSO;
    public PlayerDataSO PlayerDataSO { get => _playerDataSO; set => _playerDataSO = value; }

    [SerializeField] PlayerDetailListSO _playerDetailListSO;
    List<PlayerDetailSO> playerDetailSOs;
    PlayerBuyingListSO _playerBuyingListSO;
    public PlayerBuyingListSO PlayerBuyingListSO { get => _playerBuyingListSO; set => _playerBuyingListSO = value; }
    protected override void Awake()
    {
        base.Awake();

    }
    private void Start()
    {
        SaveData();
    }
    public void SelectionPlayer(PlayerDetailSO playerDetailSO)
    {
        _playerController = playerDetailSO.playerController;
        Debug.Log(_playerDataSO.Score);
    }
    public void GetData()
    {
        string value = PlayerPrefs.GetString(PLAYER_DATA_JSON_KEY);
        playerDetailSOs = JsonConvert.DeserializeObject<List<PlayerDetailSO>>(value);
        Debug.Log(value + "||" + playerDetailSOs);
    }
    public void SaveData()
    {
        if (PlayerPrefs.HasKey(PLAYER_DATA_JSON_KEY))
        {
            string jsonValue = JsonConvert.SerializeObject(playerDetailSOs);
            PlayerPrefs.SetString(PLAYER_DATA_JSON_KEY, jsonValue);
            Debug.Log(jsonValue);

        }
        else
        {
            playerDetailSOs = new List<PlayerDetailSO>();

        }
    }
    public void InstantiatePlayer()
    {
        if (_playerController == null)
        {
            _playerController = _playerDetailListSO.playerDetailSOs[0].playerController;
        }
        PlayerController = Instantiate(_playerController, new Vector3(-10, 0), Quaternion.identity);
        GoldManager.Instance.GameInGoldAmount = 0;
    }
}

public interface IPlayerManager
{
    void InstantiatePlayer();
    void SelectionPlayer(PlayerDetailSO playerDetailSO);
    PlayerController PlayerController { get; set; }
}

public interface IPlayerFactory
{
    void InstantiatePlayer();
}
public class PlayerFactory : IPlayerFactory
{
    PlayerManager _playerManager;
    public PlayerFactory(PlayerManager playerManager)
    {
        _playerManager = playerManager;
    }
    public void InstantiatePlayer()
    {
        // Object.Instantiate(_playerManager.Player, new Vector3(-10, 0), Quaternion.identity);
    }
}