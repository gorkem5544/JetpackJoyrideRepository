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