using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.GameScneUis.Buttons;
using UnityEngine;
using UnityEngine.UI;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.GameScneUis.Panels
{
    public class GameOverPanel : MonoBehaviour
    {
        [SerializeField] PlayerReSpawnButton _playerReSpawnButton;

        private void OnEnable()
        {
            if (PlayerManager.Instance.GetPlayer().GoldManger.GoldAmount > 15)
            {
                _playerReSpawnButton.enabled = true;
            }
            else
            {
                _playerReSpawnButton.enabled = false;

            }
        }
    }

}