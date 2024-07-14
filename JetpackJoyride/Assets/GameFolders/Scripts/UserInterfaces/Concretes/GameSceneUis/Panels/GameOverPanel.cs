using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.GameScneUis.Buttons;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.GameScneUis.Panels
{
    public class GameOverPanel : MonoBehaviour
    {
        IPlayerController _playerController;
        [SerializeField] PlayerReSpawnButton _playerReSpawnButton;
        public void Initialize(IPlayerController playerController)
        {
            _playerController = playerController;
        }
        private void OnEnable()
        {
            _playerReSpawnButton.gameObject.SetActive(_playerController.GoldManger.GameInGoldAmount >= _playerController.PlayerHealth.HitCount * 5);
        }
    }
}