using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.GameScneUis.Texts
{
    public class CoinText : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _coinText;

        private IGoldManger _playerGoldManager;
        private void Start()
        {
            _playerGoldManager = PlayerManager.Instance.PlayerController.GoldManger;
            _playerGoldManager.OnCoinChanged += HandleOnCoinChanged;
        }

        private void HandleOnCoinChanged(int obj)
        {
            _coinText.text = obj.ToString();
        }

        private void OnDisable()
        {
            _playerGoldManager.OnCoinChanged -= HandleOnCoinChanged;

        }
    }

}