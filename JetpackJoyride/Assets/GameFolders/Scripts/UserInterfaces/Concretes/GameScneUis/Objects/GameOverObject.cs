using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.GameScneUis.Objects
{
    public class GameOverObject : MonoBehaviour
    {
        [SerializeField] GameObject _gameOverPanel;

        private void Start()
        {
            ChangeGameOverPanelActive(false);
            PlayerManager.Instance.GetPlayer().PlayerHealth.OnDead += HandleOnTakeHit;
            PlayerManager.Instance.GetPlayer().PlayerHealth.OnReSpawn += HandleOnReSpawn;
        }

        private void OnDisable()
        {
            ChangeGameOverPanelActive(false);
            PlayerManager.Instance.GetPlayer().PlayerHealth.OnDead -= HandleOnTakeHit;
            PlayerManager.Instance.GetPlayer().PlayerHealth.OnReSpawn -= HandleOnReSpawn;

        }
        private void HandleOnReSpawn()
        {
            ChangeGameOverPanelActive(false);
        }

        private void HandleOnTakeHit()
        {
            ChangeGameOverPanelActive(true);
        }

        private void ChangeGameOverPanelActive(bool canActive)
        {
            _gameOverPanel.SetActive(canActive);

        }
    }

}