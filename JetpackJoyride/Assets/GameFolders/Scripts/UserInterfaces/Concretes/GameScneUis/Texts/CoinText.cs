using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.GameScneUis.Texts
{
    public class CoinText : MonoBehaviour
    {
        IPlayerController _playerController;
        [SerializeField] TextMeshProUGUI _coinText;
        private void Awake()
        {
            _playerController = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<IPlayerController>();
        }
        private void Start()
        {
            _playerController.GoldManger.OnCoinChanged += HandleOnCoinChanged;
        }

        private void HandleOnCoinChanged(int obj)
        {
            _coinText.text = obj.ToString();
        }

        private void OnDisable()
        {
            _playerController.GoldManger.OnCoinChanged -= HandleOnCoinChanged;

        }
    }

}