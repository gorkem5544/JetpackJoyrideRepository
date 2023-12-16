using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopObject : MonoBehaviour
{
    [SerializeField] ShopPanel _panel;
    [SerializeField] ShopPanelOpeningButton _shopPanelOpeningButton;
    [SerializeField] ShopPanelClosingButton _shopPanelClosingButton;

    public ShopPanelOpeningButton ShopPanelOpeningButton => _shopPanelOpeningButton;
    public ShopPanelClosingButton ShopPanelClosingButton => _shopPanelClosingButton;

    private void Start()
    {
        ChangePanelObjectActive(false);
    }
    private void OnEnable()
    {
        _shopPanelOpeningButton.ShopPanelOpeningButtonClickedEvent += OpeningShopPanel;
        _shopPanelClosingButton.ShopPanelClosingButtonClickedEvent += ClosingShopPanel;
    }


    private void OnDisable()
    {
        _shopPanelOpeningButton.ShopPanelOpeningButtonClickedEvent -= OpeningShopPanel;
        _shopPanelClosingButton.ShopPanelClosingButtonClickedEvent -= ClosingShopPanel;

    }
    private void ClosingShopPanel()
    {
        ChangePanelObjectActive(false);
    }

    private void OpeningShopPanel()
    {
        ChangePanelObjectActive(true);
    }


    public void ChangePanelObjectActive(bool canActive)
    {
        _panel.gameObject.SetActive(canActive);
    }
}
