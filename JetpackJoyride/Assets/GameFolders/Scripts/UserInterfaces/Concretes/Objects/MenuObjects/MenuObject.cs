using System;
using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.Objects.MenuObjects;
using UnityEngine;

public class MenuObject : MonoBehaviour
{
    [SerializeField] CostumeObject _costumesObject;
    [SerializeField] ShopObject _shopObject;
    [SerializeField] MenuPanel _menuPanel;
    private void OnEnable()
    {
        _costumesObject.CostumesPanelOpeningButton.CostumesPanelOpeningButtonClickedEvent += ChangePanelVisibility;
        _costumesObject.CostumesPanelClosingButton.CostumesPanelClosingButtonClickedEvent += ChangePanelVisibility;

        _shopObject.ShopPanelOpeningButton.ShopPanelOpeningButtonClickedEvent += ChangePanelVisibility;
        _shopObject.ShopPanelClosingButton.ShopPanelClosingButtonClickedEvent += ChangePanelVisibility;
    }

    private void OnDisable()
    {
        _costumesObject.CostumesPanelOpeningButton.CostumesPanelOpeningButtonClickedEvent -= ChangePanelVisibility;
        _costumesObject.CostumesPanelClosingButton.CostumesPanelClosingButtonClickedEvent -= ChangePanelVisibility;

        _shopObject.ShopPanelOpeningButton.ShopPanelOpeningButtonClickedEvent -= ChangePanelVisibility;
        _shopObject.ShopPanelClosingButton.ShopPanelClosingButtonClickedEvent -= ChangePanelVisibility;

    }
    private void ChangePanelVisibility(bool canActive)
    {
        _menuPanel.gameObject.SetActive(!canActive);
    }
}
