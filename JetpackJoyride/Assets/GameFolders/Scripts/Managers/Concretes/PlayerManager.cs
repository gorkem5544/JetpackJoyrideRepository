using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerManager : SingletonDontDestroyMonoObject<PlayerManager>
{

    [SerializeField] private PlayerController _playerInstantiatePrefab;
    public PlayerController CurrentInstantiatePlayer { get; set; }
    [SerializeField] PlayerDetailSO _selectionPlayerDetailSO;
    protected override void Awake()
    {
        base.Awake();
        // CurrentInstantiatePlayer = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<PlayerController>();
    }
    public void SelectionPlayer(PlayerDetailSO playerDetailSO)
    {
        _selectionPlayerDetailSO = playerDetailSO;
    }
    private void Start()
    {
        //InstantiatePlayer();
    }
    public void InstantiatePlayer()
    {
        CurrentInstantiatePlayer = Instantiate(_playerInstantiatePrefab, new Vector3(-10, 0), Quaternion.identity);
        //CurrentInstantiatePlayer.GetComponentInChildren<SpriteRenderer>().color = _selectionPlayerDetailSO.Color;
        //GoldManager.Instance.GameInGoldAmount = 0;
    }
}