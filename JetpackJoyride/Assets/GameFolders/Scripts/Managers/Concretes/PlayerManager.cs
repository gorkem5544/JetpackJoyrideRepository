using System;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManager : SingletonDontDestroyMonoObject<PlayerManager>
{

    [SerializeField] private PlayerController _playerInstantiatePrefab;
    public PlayerController CurrentInstantiatePlayer { get; set; }
    [SerializeField] PlayerDetailSO _selectionPlayerDetailSO;

    public void SelectionPlayer(PlayerDetailSO playerDetailSO)
    {
        _selectionPlayerDetailSO = playerDetailSO;
    }
    public void InstantiatePlayer()
    {
        CurrentInstantiatePlayer = Instantiate(_playerInstantiatePrefab, new Vector3(-10, 0), Quaternion.identity);
        CurrentInstantiatePlayer.GetComponentInChildren<SpriteRenderer>().color = _selectionPlayerDetailSO.Color;
        GoldManager.Instance.GameInGoldAmount = 0;
    }
}

