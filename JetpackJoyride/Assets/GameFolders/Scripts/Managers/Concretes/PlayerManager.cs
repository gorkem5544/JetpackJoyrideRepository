using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;


public class PlayerManager : SingletonDontDestroyMonoObject<PlayerManager>, IPlayerManager
{
    public PlayerController Player => _playerPrefab;
    [SerializeField] PlayerDataSO _playerDataSO;
    public PlayerDataSO PlayerDataSO { get => _playerDataSO; set => _playerDataSO = value; }


    [SerializeField] private PlayerController _playerPrefab;
    public PlayerController _instantiatePlayer { get; set; }
    [SerializeField] PlayerDetailSO _selectionPlayerDetailSO;

    public void SelectionPlayer(PlayerDetailSO playerDetailSO)
    {
        _selectionPlayerDetailSO = playerDetailSO;
    }


    public void InstantiatePlayer()
    {
        _instantiatePlayer = Instantiate(_playerPrefab, new Vector3(-10, 0), Quaternion.identity);
        _instantiatePlayer.GetComponentInChildren<SpriteRenderer>().color = _selectionPlayerDetailSO.Color;
        GoldManager.Instance.GameInGoldAmount = 0;
    }
}

public interface IPlayerManager
{
    void InstantiatePlayer();
    void SelectionPlayer(PlayerDetailSO playerDetailSO);
    PlayerController _instantiatePlayer { get; set; }
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