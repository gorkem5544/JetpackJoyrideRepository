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
        int _reSpawnConst = 0;
        protected override void OnEnable()
        {
            base.OnEnable();
            _reSpawnConst = PlayerManager.Instance.CurrentInstantiatePlayer.PlayerHealth.HitCount * 5;
        }
        protected override void ButtonOnClick()
        {
            PlayerManager.Instance.CurrentInstantiatePlayer.PlayerHealth.PlayerReviveEvent?.Invoke();
            GameManager.Instance.ChangeGameState(GameManagerState.GameState);
            Debug.Log(GoldManager.Instance.PlayerReSpawnCost());
            GoldManager.Instance.DecreaseGameInGoldAmount(GoldManager.Instance.PlayerReSpawnCost());
        }
    }

}
public abstract class BaseButton : MonoBehaviour
{
    [SerializeField] protected Button _button;
    protected virtual void OnEnable()
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