using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.GameScneUis.Buttons;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.GameScneUis.Panels
{
    public class GameOverPanel : MonoBehaviour
    {
        [SerializeField] PlayerReSpawnButton _playerReSpawnButton;
        private void OnEnable()
        {
            _playerReSpawnButton.gameObject.SetActive(PlayerManager.Instance.CurrentInstantiatePlayer.GoldManger.GameInGoldAmount >= PlayerManager.Instance.CurrentInstantiatePlayer.PlayerHealth.HitCount * 5);
        }
    }
}