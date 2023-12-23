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

        private IGoldManger _playerGoldManager;
        IPlayerManager _playerManager;
        private void Awake()
        {
            _playerManager = new PlayerManager();
        }
        private void Start()
        {
            _playerGoldManager = PlayerManager.Instance._instantiatePlayer.GoldManger;
            //_playerGoldManager.OnCoinChanged += HandleOnCoinChanged;
            _playerGoldManager.GoldChangedEvent += HandleOnCoinChanged;
        }

        private void HandleOnCoinChanged(int obj)
        {
            _coinText.text = "GOLD: " + obj.ToString();
        }

        private void OnDisable()
        {
            _playerGoldManager.GoldChangedEvent -= HandleOnCoinChanged;
        }

    }

}