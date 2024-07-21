using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.GameScneUis.Texts
{
    public class GameSceneGoldInfoText : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _coinText;
        private IGoldManager _playerGoldManager;

        public void Initialize(IPlayerController playerController)
        {
            _playerGoldManager = playerController.GoldManger;
        }

        private void Start()
        {
            _playerGoldManager.GameInGoldChangedEvent += HandleOnCoinChanged;
            HandleOnCoinChanged(000);
        }

        private void HandleOnCoinChanged(int obj)
        {
            Debug.Log("Current Gold: " + obj);
            _coinText.text = "GOLD: " + obj.ToString();
        }

        private void OnDisable() => _playerGoldManager.GameInGoldChangedEvent -= HandleOnCoinChanged;

    }

}