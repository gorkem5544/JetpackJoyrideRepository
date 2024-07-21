using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.MenuSceneUis;
using Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.MenuSceneUis.CostumeUis.CostumeButtons;
using Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.MenuSceneUis.ShopUis.ShopButtons;
using Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.MenuUis;
using UnityEngine;

public class MenuUnitializer : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManagerPrefab;
    [SerializeField] private PlayerSelectButton[] playerSelectButtons;
    private GoldManager _goldManager;

    [SerializeField] private PlayerPurchaseButton[] _playerPurchaseButtons;
    [SerializeField] private MenuSceneGoldText _menuSceneGoldText;

    [SerializeField] private GameStartButtonInMenuScene _menuSceneGameStartButton;
    [SerializeField] private LevelManager _levelManager;
    private void Awake()
    {
        _goldManager = new GoldManager();
        _menuSceneGoldText.Initialize(_goldManager);
        _menuSceneGameStartButton.Installer(_levelManager);


        foreach (var playerPurchaseButton in _playerPurchaseButtons)
        {
            playerPurchaseButton.Installer(_goldManager);
        }
        //LevelManager.Instance(playerManagerPrefab);
        foreach (var button in playerSelectButtons)
        {
            button.Initialize();
        }
    }
}
