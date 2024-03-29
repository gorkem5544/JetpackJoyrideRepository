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
        private void Start()
        {
            _playerGoldManager = PlayerManager.Instance.CurrentInstantiatePlayer.GoldManger;
            _playerGoldManager.GoldChangedEvent += HandleOnCoinChanged;
        }

        private void HandleOnCoinChanged(int obj) => _coinText.text = "GOLD: " + obj.ToString();


        private void OnDisable() => _playerGoldManager.GoldChangedEvent -= HandleOnCoinChanged;


    }

}