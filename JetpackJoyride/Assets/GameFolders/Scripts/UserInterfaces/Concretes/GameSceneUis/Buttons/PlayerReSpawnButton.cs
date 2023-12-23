using System;
using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.GameScneUis.Buttons
{
    public class PlayerReSpawnButton : BaseButton
    {
        [SerializeField] TextMeshProUGUI _playerReviveCostInfoText;
        private void Start()
        {
            // PlayerManager.Instance.PlayerController.GoldManger.OnCoinChanged += HandlePlayerReviveCost;
        }

        private void HandlePlayerReviveCost(int obj)
        {
            //_playerReviveCostInfoText.text = obj.ToString();
        }

        private void OnDisable()
        {
            //PlayerManager.Instance.PlayerController.GoldManger.OnCoinChanged -= HandlePlayerReviveCost;

        }
        protected override void ButtonOnClick()
        {
            //PlayerManager.Instance.PlayerController.PlayerHealth.PlayerReviveEvent?.Invoke();
            //Debug.Log(PlayerManager.Instance.PlayerController.GoldManger.PlayerReSpawnCost());
            //PlayerManager.Instance.PlayerController.GoldManger.DecreaseGoldAmount(PlayerManager.Instance.PlayerController.GoldManger.PlayerReSpawnCost());
            //Debug.Log(PlayerManager.Instance.PlayerController.GoldManger.PlayerReSpawnCost());
            GameManager.Instance.ChangeGameState(GameManagerState.GameState);
        }
    }

}
public abstract class BaseButton : MonoBehaviour
{
    [SerializeField] protected Button _button;
    private void OnEnable()
    {
        _button.onClick.AddListener(ButtonOnClick);
    }
    private void OnDisable()
    {
        _button.onClick.RemoveListener(ButtonOnClick);
    }
    protected abstract void ButtonOnClick();
}
public abstract class BaseMenuButton : BaseButton
{
    [SerializeField] GameObject _panel;
    protected virtual void Start()
    {
        ChangePanelObjectActive(false);
    }
    public void ChangePanelObjectActive(bool canActive)
    {
        _panel.SetActive(canActive);
    }
}