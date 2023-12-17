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
        ChangePanelVisibility(false);
    }
    private void OnEnable()
    {
        _shopPanelOpeningButton.ShopPanelOpeningButtonClickedEvent += ChangePanelVisibility;
        _shopPanelClosingButton.ShopPanelClosingButtonClickedEvent += ChangePanelVisibility;
    }


    private void OnDisable()
    {
        _shopPanelOpeningButton.ShopPanelOpeningButtonClickedEvent -= ChangePanelVisibility;
        _shopPanelClosingButton.ShopPanelClosingButtonClickedEvent -= ChangePanelVisibility;

    }

    public void ChangePanelVisibility(bool canActive)
    {

        _panel.gameObject.SetActive(canActive);
    }
}
