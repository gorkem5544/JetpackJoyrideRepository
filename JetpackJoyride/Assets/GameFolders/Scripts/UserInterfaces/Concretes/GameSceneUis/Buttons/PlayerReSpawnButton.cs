using System;
using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using TMPro;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.GameScneUis.Buttons
{
    public class PlayerReSpawnButton : BaseButton
    {
        [SerializeField] TextMeshProUGUI _playerReviveCostInfoText;
        protected override void ButtonOnClick()
        {
            PlayerManager.Instance.CurrentInstantiatePlayer.PlayerHealth.PlayerReviveEvent?.Invoke();
            GameManager.Instance.ChangeGameState(GameManagerStateEnum.GameState);
            GoldManager.Instance.DecreaseGameInGoldAmount(GoldManager.Instance.PlayerReSpawnCost());
        }
    }
}
