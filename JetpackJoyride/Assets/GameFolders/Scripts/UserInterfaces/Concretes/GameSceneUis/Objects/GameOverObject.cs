using System;
using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Combats.Concretes.PlayerCombats;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.GameScneUis.Objects
{
    public class GameOverObject : MonoBehaviour
    {
        [SerializeField] GameObject _gameOverPanel;
        private PlayerHealth _playerHealth;
        private void Start()
        {
            _playerHealth = PlayerManager.Instance._instantiatePlayer.PlayerHealth;
            ChangeGameOverPanelActive(false);

            _playerHealth.PlayerHitEvent += HandleOnTakeHit;
            _playerHealth.PlayerReviveEvent += HandleOnReSpawn;
        }

        private void OnDisable()
        {
            ChangeGameOverPanelActive(false);

            _playerHealth.PlayerHitEvent -= HandleOnTakeHit;
            _playerHealth.PlayerReviveEvent -= HandleOnReSpawn;
        }


        private void HandleOnReSpawn() => ChangeGameOverPanelActive(false);
        private void HandleOnTakeHit() => ChangeGameOverPanelActive(true);

        private void ChangeGameOverPanelActive(bool canActive) => _gameOverPanel.SetActive(canActive);

    }

}