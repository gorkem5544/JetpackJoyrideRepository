using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.GameScneUis.Texts
{
    public class GoldInformationText : MonoBehaviour
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
            _playerGoldManager = PlayerManager.Instance.PlayerController.GoldManger;
            //_playerGoldManager.OnCoinChanged += HandleOnCoinChanged;
            _playerGoldManager.GameInGoldChanged += HandleOnCoinChanged;
        }

        private void HandleOnCoinChanged(int obj)
        {
            _coinText.text = obj.ToString();
        }

        private void OnDisable()
        {
            _playerGoldManager.GameInGoldChanged -= HandleOnCoinChanged;

        }

    }

}