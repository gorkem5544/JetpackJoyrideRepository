using System;
using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.Buttons.MenuButtons;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.Objects.MenuObjects
{
    public class CostumesObject : MonoBehaviour
    {
        [SerializeField] GameObject _panel;
        [SerializeField] CostumesPanelOpeningButton _costumesPanelOpeningButton;
        [SerializeField] CostumesPanelClosingButton _costumesPanelClosingButton;

        public CostumesPanelOpeningButton CostumesPanelOpeningButton => _costumesPanelOpeningButton;
        public CostumesPanelClosingButton CostumesPanelClosingButton => _costumesPanelClosingButton;

        private void Start()
        {
            ChangePanelObjectActive(false);
        }
        private void OnEnable()
        {
            CostumesPanelOpeningButton.CostumesPanelOpeningButtonClickedEvent += OpeningCostumesPanel;
            CostumesPanelClosingButton.CostumesPanelClosingButtonClickedEvent += ClosingCostumesPanel;
        }


        private void OnDisable()
        {
            CostumesPanelOpeningButton.CostumesPanelOpeningButtonClickedEvent -= OpeningCostumesPanel;
            CostumesPanelClosingButton.CostumesPanelClosingButtonClickedEvent -= ClosingCostumesPanel;

        }
        private void ClosingCostumesPanel()
        {
            ChangePanelObjectActive(false);


        }

        private void OpeningCostumesPanel()
        {

            ChangePanelObjectActive(true);
        }


        public void ChangePanelObjectActive(bool canActive)
        {
            _panel.SetActive(canActive);
        }
    }

}