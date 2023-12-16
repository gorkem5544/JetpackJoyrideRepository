using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.GameScneUis.Buttons
{
    public class PlayerReSpawnButton : BaseButton
    {
        protected override void ButtonOnClick()
        {
            PlayerManager.Instance.GetPlayer().PlayerHealth.OnReSpawn();
        }
    }

}
public abstract class BaseButton : MonoBehaviour
{
    [SerializeField] Button _button;
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