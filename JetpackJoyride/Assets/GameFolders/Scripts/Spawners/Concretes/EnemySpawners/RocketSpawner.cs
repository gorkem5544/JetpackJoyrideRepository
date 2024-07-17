using System;
using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Pools.Concretes.EnemyPools;
using UnityEngine;

public class RocketSpawner : MonoBehaviour
{
    [SerializeField] AlertController _alertController;
    [SerializeField] RocketController _rocketController;
    public RocketController RocketController { get => newRocketController; set => newRocketController = value; }
    public AlertController AlertController { get => _alertController; set => _alertController = value; }
    RocketController newRocketController;

    private void Start()
    {
        ChangeAlertVisibility(false);
    }
    public void ChangeAlertVisibility(bool canActive)
    {
        AlertController.gameObject.SetActive(canActive);
    }
    private void HandleOnSpawn()
    {
        Spawn();
    }
    private void OnDisable()
    {
        _alertController.AlertVerticalMove.OnStopEvent -= HandleOnSpawn;
    }

    public void Spawn()
    {
        newRocketController = RocketPool.Instance.Get();
        newRocketController.transform.position = new Vector3(25, AlertController.transform.position.y);
        newRocketController.gameObject.SetActive(true);
    }
}
