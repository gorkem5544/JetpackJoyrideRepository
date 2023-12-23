using System;
using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.Buttons.MenuButtons;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.Objects.MenuObjects
{
    public class CostumeObject : MonoBehaviour
    {
        [SerializeField] GameObject _panel;
        [SerializeField] CostumesPanelOpeningButton _costumesPanelOpeningButton;
        [SerializeField] CostumesPanelClosingButton _costumesPanelClosingButton;

        public CostumesPanelOpeningButton CostumesPanelOpeningButton => _costumesPanelOpeningButton;
        public CostumesPanelClosingButton CostumesPanelClosingButton => _costumesPanelClosingButton;

        private void Start()
        {
            ChangePanelVisibility(false);
        }
        private void OnEnable()
        {
            CostumesPanelOpeningButton.CostumesPanelOpeningButtonClickedEvent += ChangePanelVisibility;
            CostumesPanelClosingButton.CostumesPanelClosingButtonClickedEvent += ChangePanelVisibility;
        }


        private void OnDisable()
        {
            CostumesPanelOpeningButton.CostumesPanelOpeningButtonClickedEvent -= ChangePanelVisibility;
            CostumesPanelClosingButton.CostumesPanelClosingButtonClickedEvent -= ChangePanelVisibility;
        }
        private void ChangePanelVisibility(bool canActive)
        {
            _panel.SetActive(canActive);
        }
    }

}