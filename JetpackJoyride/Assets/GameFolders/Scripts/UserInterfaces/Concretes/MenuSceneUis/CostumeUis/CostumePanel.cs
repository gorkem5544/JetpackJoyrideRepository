using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.MenuSceneUis.CostumeUis.CostumeButtons;
using UnityEngine.UI;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.MenuSceneUis.CostumeUis
{
    public class CostumePanel : MonoBehaviour
    {
        [SerializeField] private List<PlayerSelectButton> _playerSelectButtons;

        private void OnEnable() => ActivatePlayerSelectButtons();

        private void ActivatePlayerSelectButtons()
        {
            foreach (PlayerDetailSO playerDetailSO in ShopManager.Instance.PlayerDetailLists)
            {
                foreach (PlayerSelectButton playerSelectButton in _playerSelectButtons)
                {
                    if (playerDetailSO.PlayerTypeEnum == playerSelectButton._playerDetailSO.PlayerTypeEnum)
                    {
                        playerSelectButton.transform.gameObject.SetActive(true);
                    }
                }
            }
            foreach (var item in _playerSelectButtons)
            {
                item.onClick += HandleOnClick;
            }

        }

        private void HandleOnClick(PlayerSelectButton image)
        {
            foreach (var item in _playerSelectButtons)
            {
                item.SetDefaultColor();
            }
            image.SetSelectionColor();

        }
    }

}