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
        IGoldManager _goldManager;
        public void Installer(IGoldManager goldManager)
        {
            _goldManager = goldManager;
            _goldManager.GoldChangedEvent += GoldManager_GoldChangedEvent;
            UpdateMenuGoldText(0);
        }
        private void OnDisable()
        {
            _goldManager.GoldChangedEvent -= GoldManager_GoldChangedEvent;
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