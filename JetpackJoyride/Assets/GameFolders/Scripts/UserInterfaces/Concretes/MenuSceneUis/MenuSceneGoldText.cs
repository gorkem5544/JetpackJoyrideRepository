using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.MenuUis
{
    public class MenuSceneGoldText : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _goldInformationText;
        private IGoldManager _goldManager;

        public void Initialize(IGoldManager goldManager)
        {
            _goldManager = goldManager;
            UpdateMenuGoldText(_goldManager.GoldData.TotalGoldAmount);
            _goldManager.MenuInGoldChangedEvent += GoldManager_GoldChangedEvent;
        }
        private void Start()
        {
            _goldManager.MenuInGoldChangedEvent += GoldManager_GoldChangedEvent;
        }
        private void OnDisable()
        {
            _goldManager.MenuInGoldChangedEvent -= GoldManager_GoldChangedEvent;
        }

        private void GoldManager_GoldChangedEvent(int goldAmount)
        {
            UpdateMenuGoldText(goldAmount);
        }

        private void UpdateMenuGoldText(int goldAmount = 0)
        {
            _goldInformationText.text = $"GOLD: {goldAmount}";
        }
    }

}