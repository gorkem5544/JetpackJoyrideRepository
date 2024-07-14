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
            _playerGoldManager.GoldChangedEvent += HandleOnCoinChanged;
        }

        private void HandleOnCoinChanged(int obj) => _coinText.text = "GOLD: " + obj.ToString();


        private void OnDisable() => _playerGoldManager.GoldChangedEvent -= HandleOnCoinChanged;


    }

}