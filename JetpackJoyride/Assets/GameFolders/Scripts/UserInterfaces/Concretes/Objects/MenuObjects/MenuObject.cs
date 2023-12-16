using System;
using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.Objects.MenuObjects;
using UnityEngine;

public class MenuObject : MonoBehaviour
{
    [SerializeField] CostumesObject _costumesObject;
    [SerializeField] ShopObject _shopObject;
    [SerializeField] MenuPanel _menuPanel;
    private void OnEnable()
    {
        _costumesObject.CostumesPanelOpeningButton.CostumesPanelOpeningButtonClickedEvent += ClosingMenuPanel;
        _costumesObject.CostumesPanelClosingButton.CostumesPanelClosingButtonClickedEvent += OpeningMenuPanel;

        _shopObject.ShopPanelOpeningButton.ShopPanelOpeningButtonClickedEvent += ClosingMenuPanel;
        _shopObject.ShopPanelClosingButton.ShopPanelClosingButtonClickedEvent += OpeningMenuPanel;
    }

    private void OnDisable()
    {
        _costumesObject.CostumesPanelOpeningButton.CostumesPanelOpeningButtonClickedEvent -= ClosingMenuPanel;
        _costumesObject.CostumesPanelClosingButton.CostumesPanelClosingButtonClickedEvent -= OpeningMenuPanel;

        _shopObject.ShopPanelOpeningButton.ShopPanelOpeningButtonClickedEvent -= ClosingMenuPanel;
        _shopObject.ShopPanelClosingButton.ShopPanelClosingButtonClickedEvent -= OpeningMenuPanel;

    }
    private void OpeningMenuPanel()
    {
        ChangePanelObjectActive(true);
    }

    private void ClosingMenuPanel()
    {
        ChangePanelObjectActive(false);
    }

    public void ChangePanelObjectActive(bool canActive)
    {
        _menuPanel.gameObject.SetActive(canActive);
    }
}
