using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.GameScneUis.Buttons;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.GameScneUis.Panels
{
    public class GameOverPanel : MonoBehaviour
    {
        [SerializeField] PlayerReSpawnButton _playerReSpawnButton;
        IGoldManger _playerGoldManager;
        private void Start()
        {
            _playerGoldManager = PlayerManager.Instance.PlayerController.GoldManger;
            _playerReSpawnButton.gameObject.SetActive(_playerGoldManager.CurrentGold > _playerGoldManager.PlayerReSpawnCost());
        }
    }
}